using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Codecs
{
    public class FFmpegVideoCodec
    {
        public static FFmpegVideoCodec libvpx = "libvpx";
        public static FFmpegVideoCodec libvpx_vp9 = "libvpx-vp9";
        public static FFmpegVideoCodec libx264 = "libx264";
        public static FFmpegVideoCodec libxvid = "libxvid";
        public static FFmpegVideoCodec rawvideo = "rawvideo";
        public static FFmpegVideoCodec hevc_qsv = "hevc_qsv";
        public static FFmpegVideoCodec copy = "copy";
        public static FFmpegVideoCodec png = "png";
        private string codec = string.Empty;
        private FFmpegVideoCodec(string codec)
        {
            this.codec = codec;
        }
        public static implicit operator string(FFmpegVideoCodec codec)
        {
            return codec.codec;
        }
        public static implicit operator FFmpegVideoCodec(string codec)
        {
            return new FFmpegVideoCodec(codec);
        }
        public override string ToString()
        {
            return this.codec;
        }
    }
}
