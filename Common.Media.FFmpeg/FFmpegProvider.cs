using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Media.FFmpeg.VideoCodecs;
using Common.Medias.Args;
using Common.Medias.Interfaces;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace Common.Media.FFmpeg
{
    public static class FFmpegProvider
    {
        public static IVideoFileWriter GetVideoFileWriter()
        {
            return new FFmpegVideoWriter();
        }
        public static IVideoFileReader GetVideoFileReader()
        {
            return new FFmpegVideoReader();
        }
        public static IMediaHelper GetMediaHelper()
        {
            return new FFmpegMediaHelper();
        }
        public static IMediaInfo GetMediaInfo()
        {
            return new FFmpegMediaInfo();
        }
        public static IEnumerable<IDisplayItem> VideoCodecItems
        {
            get
            {
                yield return new X264VideoCodec();
                yield return new XvidVideoCodec();
                //yield return new QsvHevcVideoCodec();
                //yield return new Vp8VideoCodec();
                yield return new Vp9VideoCodec();
            }
        }
        public static IEnumerable<IDisplayItem> AudioCodecItems
        {
            get
            {
                yield return new AACAudioCodec();
                yield return new Mp3AudioCodec();
                yield return new OpusAudioCodec();
                yield return new VorbisAudioCodec();
            }
        }
    }
}
