using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Codecs
{
    public class FFmpegAudioCodec
    {
        public static FFmpegAudioCodec pcm_s16le = "pcm_s16le";
        public static FFmpegAudioCodec pcm_s24le = "pcm_s24le";
        public static FFmpegAudioCodec pcm_u8 = "pcm_u8";
        public static FFmpegAudioCodec ac3_fixed = "ac3_fixed";
        public static FFmpegAudioCodec aac = "aac";
        public static FFmpegAudioCodec ac3 = "ac3";
        public static FFmpegAudioCodec mp2fixed = "mp2fixed";
        public static FFmpegAudioCodec libmp3lame = "libmp3lame";
        public static FFmpegAudioCodec libfdk_aac = "libfdk_aac";
        public static FFmpegAudioCodec libvorbis = "libvorbis"; 
        public static FFmpegAudioCodec libopus = "libopus"; 
        public static FFmpegAudioCodec copy = "copy";
        private string codec = string.Empty;
        private FFmpegAudioCodec(string codec)
        {
            this.codec = codec;
        }
        public static implicit operator string(FFmpegAudioCodec codec)
        {
            return codec.codec;
        }
        public static implicit operator FFmpegAudioCodec(string codec)
        {
            return new FFmpegAudioCodec(codec);
        }
        public override string ToString()
        {
            return this.codec;
        }
    }
}
