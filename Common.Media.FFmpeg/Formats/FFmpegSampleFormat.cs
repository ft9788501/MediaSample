using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Formats
{
    //I.... = Supported Input format for conversion
    //.O... = Supported Output format for conversion
    //..H.. = Hardware accelerated format
    //...P. = Paletted format
    //....B = Bitstream format
    public class FFmpegSampleFormat
    {
        /// <summary>
        /// 8
        /// </summary>
        public static FFmpegSampleFormat u8 = "u8";
        /// <summary>
        /// 16
        /// </summary>
        public static FFmpegSampleFormat s16 = "s16";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat s32 = "s32";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat flt = "flt";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat dbl = "dbl";
        /// <summary>
        /// 8
        /// </summary>
        public static FFmpegSampleFormat u8p = "u8p";
        /// <summary>
        /// 16
        /// </summary>
        public static FFmpegSampleFormat s16p = "s16p";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat s32p = "s32p";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat fltp = "fltp";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat dblp = "dblp";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat s64 = "s64";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat s64p = "s64p";
        private string format = string.Empty;
        private FFmpegSampleFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegSampleFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegSampleFormat(string format)
        {
            return new FFmpegSampleFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
}