using Common.Media.FFmpeg.Args;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.AudioCodecs
{
    internal class OpusAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Opus";

        public override string Description { get; } = "Opus";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 0 (lowest) to 10 (highest)
            var qscale = (10 * (audioWriterArgs.AudioQuality - 1)) / 99;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libopus)
                .AddArg("compression_level", qscale);
        }
    }
}
