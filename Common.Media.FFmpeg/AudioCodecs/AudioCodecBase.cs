using Common.Media.FFmpeg.Args;
using Common.Medias.Args;
using Common.Medias.Interfaces;

namespace Common.Media.FFmpeg.AudioCodecs
{
    internal abstract class AudioCodecBase : IDisplayItem
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs);

        public override string ToString() => Name;
    }
}
