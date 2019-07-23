using Common.Media.FFmpeg.Args;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.AudioCodecs
{
    internal class Mp3AudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Mp3";

        public override string Description { get; } = "Mp3";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 9 (lowest) to 0 (highest)
            var qscale = (100 - audioWriterArgs.AudioQuality) / 11;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libmp3lame)
                .AddArg("qscale:a", qscale);
        }
    }
}
