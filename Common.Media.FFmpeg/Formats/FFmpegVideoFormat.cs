using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Formats
{
    public class FFmpegVideoFormat
    {
        public static FFmpegVideoFormat rawvideo = "rawvideo";
        public static FFmpegVideoFormat image2 = "image2"; 
        public static FFmpegVideoFormat image2pipe = "image2pipe"; 
        public static FFmpegVideoFormat flv = "flv";
        public static FFmpegVideoFormat live_flv = "live_flv";
        private string format = string.Empty;
        private FFmpegVideoFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegVideoFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegVideoFormat(string format)
        {
            return new FFmpegVideoFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
}
