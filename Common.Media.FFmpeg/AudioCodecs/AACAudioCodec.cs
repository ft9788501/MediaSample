using Common.Media.FFmpeg.Args;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.AudioCodecs
{
    internal class AACAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "AAC";

        public override string Description { get; } = "aac";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // bitrate: 32k to 512k (steps of 32k)
            var b = 32 * (1 + (15 * (audioWriterArgs.AudioQuality - 1)) / 99);
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.aac)
                .AddArg("-strict -2")
                .SetAudioBitrate($"{b}k")
                ;
        }
    }
}
