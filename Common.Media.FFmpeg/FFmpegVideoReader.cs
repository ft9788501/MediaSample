using Common.Media.Args;
using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Exceptions;
using Common.Media.FFmpeg.Formats;
using Common.Media.Handlers;
using Common.Medias.Interfaces;
using Microsoft.Win32.SafeHandles;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;

namespace Common.Media.FFmpeg
{
    public class FFmpegVideoReader : IVideoFileReader
    {
        private Process ffmpegProcess;
        private string videoPipeName = $"videoR-{Guid.NewGuid()}";
        private string filePath = string.Empty;
        private FFmpegMediaInfo fFmpegMediaInfo = null;
        public int FrameCount => (int)(Duration.TotalMilliseconds / (1000.0 / this.FPS));

        public double FPS { get; set; }

        public int Width => this.fFmpegMediaInfo.Width;

        public int Height => this.fFmpegMediaInfo.Height;

        public TimeSpan Duration => this.fFmpegMediaInfo.Duration;

        public FFmpegVideoReader()
        {
            if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
        }
        public void Dispose()
        {
            try
            {
                this.ffmpegProcess?.WaitForExit(3000);
                this.ffmpegProcess?.Kill();
            }
            catch (Exception ex)
            {

            }
        }

        public bool Open(string filePath)
        {
            try
            {
                this.filePath = filePath;
                fFmpegMediaInfo = new FFmpegMediaInfo();
                fFmpegMediaInfo.Open(this.filePath);
                return true;
            }
            catch { return false; }
        }

        public Stream ReadVideoFrame(TimeSpan seek, Size? size)
        {
            this.Dispose();
            try
            {
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .SetThreadQueueSize(512)
                    ;
                fFmpegArgsBuilder.SetInputFile(this.filePath)
                    .SeekAccurate()
                    .ReadByNativeFrame()
                    .SetSeek(seek)
                    ;
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputImagePipe(videoPipeName)
                    .SetPixFormat(Formats.FFmpegPixFormat.rgb24)
                    .SetOutputVideoFrame(1)
                    .SetVideoFormat(FFmpegVideoFormat.image2)
                    .SetFramerate(this.FPS)
                    ;
                if (size != null)
                {
                    outputOptionArgs
                       .SetVideoSize(size.Value);
                }
                this.ffmpegProcess = FFmpegService.StartFFmpegStandardOutput(fFmpegArgsBuilder.Args);
                return this.ffmpegProcess.StandardOutput.BaseStream;
            }
            catch
            {

            }
            return null;
        }
        public IEnumerable<VideoFrameArgs> ReadVideoFrames(TimeSpan? seek = null, TimeSpan? seekEnd = null, Size? size = null, bool readByNativeFrame = true, CancellationToken? cancellationToken = null)
        {
            this.Dispose();
            TimeSpan startSeek = seek ?? TimeSpan.FromSeconds(0);
            FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
            fFmpegArgsBuilder.GlobalOptionArgs
                .SetThreadQueueSize(512)
                .SetNoStandardInput()
                ;
            var inputOptionArgs = fFmpegArgsBuilder.SetInputFile(this.filePath)
                .SeekAccurate()
                .SetSeek(startSeek)
                .ReadByNativeFrame(() => readByNativeFrame)
                ;
            var outputOptionArgs = fFmpegArgsBuilder.SetOutputImagePipe(videoPipeName)
                .SetVideoFormat(FFmpegVideoFormat.image2pipe)
                .SetVideoCodec(FFmpegVideoCodec.rawvideo)
                .SetPixFormat(Formats.FFmpegPixFormat.rgb24)
                .SetFramerate(this.FPS)
                .SetSeekEnd(seekEnd ?? TimeSpan.MinValue, () => seekEnd != null)
                .SetVideoSize(this.GetSize(size))
                ;
            this.ffmpegProcess = FFmpegService.StartFFmpegStandardOutput(fFmpegArgsBuilder.Args);
            cancellationToken?.Register(() =>
            {
                this.Dispose();
            });
            int frameIndex = (int)(startSeek.TotalMilliseconds / (1000.0 / this.FPS));
            Size bitmapSize = this.GetSize(size);
            byte[] frameDataBuffer = new byte[bitmapSize.Width * bitmapSize.Height * 3];
            byte[] buffer = new byte[32768]; //ffmpeg的缓冲区大小被限定在32k 32768 似乎没有办法修改？
            int read;
            int readed = 0;
            while ((read = this.ffmpegProcess.StandardOutput.BaseStream.Read(buffer, 0, Math.Min(buffer.Length, frameDataBuffer.Length - readed))) > 0)
            {
                if (cancellationToken?.IsCancellationRequested ?? false)
                {
                    this.Dispose();
                    yield break;
                }
                Array.Copy(buffer, 0, frameDataBuffer, readed, read);
                readed += read;
                if (readed == frameDataBuffer.Length)
                {
                    //对每一个像素的颜色进行转化
                    for (int i = 0; i < frameDataBuffer.Length; i += 3)
                    {
                        byte temp = frameDataBuffer[i + 2];
                        frameDataBuffer[i + 2] = frameDataBuffer[i];
                        frameDataBuffer[i] = temp;
                    }
                    yield return new VideoFrameArgs(frameIndex++, frameDataBuffer);
                    readed = 0;
                }
            }
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
