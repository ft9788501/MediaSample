using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal class Vp8VideoCodec : FFmpegPostProcessingCodec
    {
        protected override string PostProcessingName { get; } = "Vp8";

        protected override string PostProcessingDescription { get; } = "";

        public override void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 63 (lowest) to 4 (highest)
            var crf = 63 - ((videoWriterArgs.VideoQuality - 1) * 59) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libvpx)
                .AddArg("crf", crf)
                .SetVideoBitrate("1M");
        }
    }
}