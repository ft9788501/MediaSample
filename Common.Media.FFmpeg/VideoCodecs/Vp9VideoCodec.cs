using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal class Vp9VideoCodec : FFmpegPostProcessingCodec
    {
        protected override string PostProcessingName { get; } = "Vp9";

        protected override string PostProcessingDescription { get; } = "";

        public override void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 63 (lowest) to 0 (highest)
            var crf = (63 * (100 - videoWriterArgs.VideoQuality)) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libvpx_vp9)
                .AddArg("crf", crf)
                .SetVideoBitrate(0);
        }
    }
}