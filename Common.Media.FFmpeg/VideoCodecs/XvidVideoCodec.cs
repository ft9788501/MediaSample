using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Media.FFmpeg.Codecs;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal class XvidVideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "MPEG4(Xvid)";

        public override string Description { get; } = "";

        public override void Apply(VideoWriterArgs writerArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 31 (lowest) to 1 (highest)
            var qscale = 31 - ((writerArgs.VideoQuality - 1) * 30) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libxvid)
                .AddArg("qscale:v", qscale);
        }
    }
}