using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Options
{
    public class FFmpegVideoAspect
    {
        public static FFmpegVideoAspect VA4_3 = "4:3";
        public static FFmpegVideoAspect VA16_9 = "16:9";
        private string videoAspect = string.Empty;
        private FFmpegVideoAspect(string videoAspect)
        {
            this.videoAspect = videoAspect;
        }
        public static implicit operator string(FFmpegVideoAspect videoAspect)
        {
            return videoAspect.videoAspect;
        }
        public static implicit operator FFmpegVideoAspect(string videoAspect)
        {
            return new FFmpegVideoAspect(videoAspect);
        }
        public override string ToString()
        {
            return this.videoAspect;
        }
    }
}
