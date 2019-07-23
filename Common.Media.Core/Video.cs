using Common.Media.Args;
using Common.Media.Core.Args;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class Video : Media<Video>
    {
        private VideoFileReader videoFileReader = null;
        public int Width => this.videoFileReader.Width;
        public int Height => this.videoFileReader.Height;
        public int FrameCount => this.videoFileReader.FrameCount;
        public double FPS { get => this.videoFileReader.FPS; set => this.videoFileReader.FPS = value; }
        public override TimeSpan Duration => this.videoFileReader.Duration;

        private IEnumerator<Bitmap> enumerator = null;
        private CancellationTokenSource cancellationTokenSource = null;
        private Video(string filePath) : base(filePath)
        {
            this.videoFileReader = new VideoFileReader();
            this.videoFileReader.Open(filePath);
            this.videoFileReader.FPS = 25;
        }
        public Bitmap ReadVideoFrameNext(int frameIndex = 0, Size? size = null)
        {
            if (enumerator == null)
            {
                cancellationTokenSource = new CancellationTokenSource();
                cancellationTokenSource.Token.Register(() =>
                {
                    enumerator.Dispose();
                    enumerator = null;
                });
                enumerator = this.ReadVideoFramesFast(frameIndex, size, cancellationTokenSource.Token).GetEnumerator();
            }
            if (enumerator.MoveNext())
            {
                cancellationTokenSource.CancelAfter(5000); //Timeout
                return enumerator.Current;
            }
            else
            {
                cancellationTokenSource.Cancel();
                return null;
            }
        }
        public IEnumerable<Bitmap> ReadVideoFramesFast(int frameIndex = 0, Size? size = null, CancellationToken? cancellationToken = null)
        {
            foreach (var videoFrameImageArg in this.videoFileReader.ReadVideoFrames(TimeSpan.FromMilliseconds(frameIndex * 1000.0 / this.FPS), readByNativeFrame: false, size: size, cancellationToken: cancellationToken))
            {
                yield return videoFrameImageArg.FrameBitmap;
            }
        }
        public IEnumerable<Bitmap> ReadVideoFrames(int frameIndex = 0, Size? size = null, CancellationToken? cancellationToken = null)
        {
            foreach (var videoFrameImageArg in this.videoFileReader.ReadVideoFrames(TimeSpan.FromMilliseconds(frameIndex * 1000.0 / this.FPS), size: size, cancellationToken: cancellationToken))
            {
                yield return videoFrameImageArg.FrameBitmap;
            }
        }
        public Bitmap ReadVideoFrame(int frameIndex = 0, Size? size = null)
        {
            return this.videoFileReader.ReadVideoFrame(TimeSpan.FromMilliseconds(frameIndex * 1000.0 / this.FPS), size);
        }
        public override void Dispose()
        {
            this.videoFileReader.Dispose();
        }
    }
}
