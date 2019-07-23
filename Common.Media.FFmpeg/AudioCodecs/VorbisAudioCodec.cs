using Common.Media.FFmpeg.Args;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.AudioCodecs
{
    internal class VorbisAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Vorbis";

        public override string Description { get; } = "Vorbis";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 0 (lowest) to 10 (highest)
            var qscale = (10 * (audioWriterArgs.AudioQuality - 1)) / 99;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libvorbis)
                .AddArg("qscale:a", qscale);
        }
    }
}
