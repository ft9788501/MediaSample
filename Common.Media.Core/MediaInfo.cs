using Common.Media.FFmpeg;
using Common.Medias.Interfaces;
using System;

namespace Common.Media.Core
{
    public class MediaInfo 
    {
        private IMediaInfo mediaInfo = null;
        public int Width => this.mediaInfo.Width;
        public int Height => this.mediaInfo.Height;
        public string AudioFormat => this.mediaInfo.AudioFormat;
        public string VideoFormat => this.mediaInfo.VideoFormat;
        public string PixFormat => this.mediaInfo.PixFormat;
        public TimeSpan Duration => this.mediaInfo.Duration;
        public double Framerate => this.mediaInfo.Framerate;
        public string VideoBitrate => this.mediaInfo.VideoBitrate;
        public string AudioBitrate => this.mediaInfo.AudioBitrate;
        public int AudioFrequency => this.mediaInfo.AudioFrequency;
        public string Bitrate => this.mediaInfo.Bitrate;
        public MediaInfo(string filePath)
        {
            this.mediaInfo = FFmpegProvider.GetMediaInfo();
            this.mediaInfo.Open(filePath);
        }
    }
}
