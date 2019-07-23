using Common.Media.FFmpeg;
using Common.Medias.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class VideoFileWriter : IDisposable
    {
        private IVideoFileWriter videoFileWriter = null;
        private byte[] writeBuffer = null;
        public int? FileLength { get => this.videoFileWriter.CommonWriterArgs.FileLength; set => this.videoFileWriter.CommonWriterArgs.FileLength = value; }

        public IDisplayItem VideoCodec { get => this.videoFileWriter.VideoWriterArgs.VideoCodec; set => this.videoFileWriter.VideoWriterArgs.VideoCodec = value; }
        public float ScaleWidth { get => this.videoFileWriter.VideoWriterArgs.ScaleWidth; set => this.videoFileWriter.VideoWriterArgs.ScaleWidth = value; }
        public float ScaleHeight { get => this.videoFileWriter.VideoWriterArgs.ScaleHeight; set => this.videoFileWriter.VideoWriterArgs.ScaleHeight = value; }
        public int Width { get => this.videoFileWriter.VideoWriterArgs.Width; set => this.videoFileWriter.VideoWriterArgs.Width = value; }
        public int Height { get => this.videoFileWriter.VideoWriterArgs.Height; set => this.videoFileWriter.VideoWriterArgs.Height = value; }
        public int FPS { get => this.videoFileWriter.VideoWriterArgs.FrameRate; set => this.videoFileWriter.VideoWriterArgs.FrameRate = value; }
        public int VideoQuality { get => this.videoFileWriter.VideoWriterArgs.VideoQuality; set => this.videoFileWriter.VideoWriterArgs.VideoQuality = value; }

        public IDisplayItem AudioCodec { get => this.videoFileWriter.AudioWriterArgs.AudioCodec; set => this.videoFileWriter.AudioWriterArgs.AudioCodec = value; }
        public int AudioQuality { get => this.videoFileWriter.AudioWriterArgs.AudioQuality; set => this.videoFileWriter.AudioWriterArgs.AudioQuality = value; }
        public int AudioFrequency { get => this.videoFileWriter.AudioWriterArgs.AudioFrequency; set => this.videoFileWriter.AudioWriterArgs.AudioFrequency = value; }
        public int AudioChannels { get => this.videoFileWriter.AudioWriterArgs.AudioChannels; set => this.videoFileWriter.AudioWriterArgs.AudioChannels = value; }
        public VideoFileWriter()
        {
            this.videoFileWriter = FFmpegProvider.GetVideoFileWriter();
            this.Width = 1024;
            this.Height = 768;
            this.ScaleWidth = 1;
            this.ScaleHeight = 1;
            this.FPS = 25;
            this.VideoQuality = 55;
            this.AudioQuality = 55;
            this.AudioFrequency = 16000;
            this.AudioChannels = 2;
        }
        public bool Open(string filePath)
        {
            bool b = this.videoFileWriter.Open(filePath);
            return b;
        }

        public void Dispose()
        {
            videoFileWriter.Dispose();
        }

        public void FlushAudio()
        {
            videoFileWriter.FlushAudio();
        }

        public void FlushVideo()
        {
            videoFileWriter.FlushVideo();
        }

        public void WriteAudio(byte[] buffer)
        {
            videoFileWriter.WriteAudio(buffer);
        }

        public Task WriteAudioAsync(byte[] buffer)
        {
            return videoFileWriter.WriteAudioAsync(buffer);
        }

        public void WriteVideo(Bitmap bitmap)
        {
            if (this.writeBuffer == null || this.writeBuffer.Length != bitmap.Width * bitmap.Height * 4)
            {
                this.writeBuffer = new byte[bitmap.Width * bitmap.Height * 4];
            }
            var bits = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                Marshal.Copy(bits.Scan0, this.writeBuffer, 0, this.writeBuffer.Length);
            }
            finally
            {
                bitmap.UnlockBits(bits);
            }
            videoFileWriter.WriteVideo(this.writeBuffer);
        }

        public Task WriteVideoAsync(Bitmap bitmap)
        {
            if (this.writeBuffer == null || this.writeBuffer.Length != bitmap.Width * bitmap.Height * 4)
            {
                this.writeBuffer = new byte[bitmap.Width * bitmap.Height * 4];
            }
            var bits = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);
            try
            {
                Marshal.Copy(bits.Scan0, this.writeBuffer, 0, this.writeBuffer.Length);
            }
            finally
            {
                bitmap.UnlockBits(bits);
            }
            return videoFileWriter.WriteVideoAsync(this.writeBuffer);
        }
    }
}
