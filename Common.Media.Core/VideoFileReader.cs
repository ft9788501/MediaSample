using Common.Media.Args;
using Common.Media.Core.Args;
using Common.Media.Core.Handlers;
using Common.Media.FFmpeg;
using Common.Media.Handlers;
using Common.Medias.Interfaces;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class VideoFileReader : IDisposable
    {
        private IVideoFileReader videoFileReader = null;
        public int FrameCount => videoFileReader.FrameCount;

        public double FPS { get => videoFileReader.FPS; set => videoFileReader.FPS = value; }

        public int Width => videoFileReader.Width;

        public int Height => videoFileReader.Height;

        public TimeSpan Duration => videoFileReader.Duration;
        public VideoFileReader()
        {
            this.videoFileReader = FFmpegProvider.GetVideoFileReader();
        }
        public bool Open(string filePath)
        {
            return this.videoFileReader.Open(filePath);
        }

        public Bitmap ReadVideoFrame(TimeSpan seek, Size? size = null)
        {
            try
            {
                return (Bitmap)Image.FromStream(this.videoFileReader.ReadVideoFrame(seek, size));
            }
            catch
            {
                return null;
            }
        }
        public IEnumerable<VideoFrameImageArgs> ReadVideoFrames(TimeSpan? seek = null, TimeSpan? seekEnd = null, Size? size = null, bool readByNativeFrame = true, CancellationToken? cancellationToken = null)
        {
            foreach (var videoFrame in this.videoFileReader.ReadVideoFrames(seek, seekEnd, size, readByNativeFrame, cancellationToken))
            {
                VideoFrameImageArgs videoFrameImageArgs = null;
                try
                {
                    Size bitmapSize = this.GetSize(size);
                    Bitmap bitmap = new Bitmap(bitmapSize.Width, bitmapSize.Height);
                    var bits = bitmap.LockBits(new Rectangle(Point.Empty, bitmapSize), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                    try
                    {
                        Marshal.Copy(videoFrame.FrameData, 0, bits.Scan0, videoFrame.FrameData.Length);
                    }
                    finally
                    {
                        bitmap.UnlockBits(bits);
                    }
                    videoFrameImageArgs = new Args.VideoFrameImageArgs(videoFrame.FrameIndex, bitmap);
                }
                catch (Exception ex)
                {
                    videoFrameImageArgs = new Args.VideoFrameImageArgs(videoFrame.FrameIndex, null);
                }
                yield return videoFrameImageArgs;
            }
        }

        public void Dispose()
        {
            this.videoFileReader.Dispose();
        }
        /// <summary>
        /// 获取位图的宽度只能是四的整数倍
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private Size GetSize(Size? size)
        {
            Size returnSize = size ?? new Size(this.Width, this.Height);
            return new Size(returnSize.Width + (returnSize.Width % 4 == 0 ? 0 : (4 - returnSize.Width % 4)), returnSize.Height);
        }
    }
}
