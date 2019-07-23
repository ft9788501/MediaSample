using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Medias.Args;
using Common.Medias.Interfaces;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal abstract class VideoCodecBase : IDisplayItem
    {
        public abstract string Name { get; }

        public abstract string Description { get; }

        public abstract void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputArgs);

        public override string ToString() => Name;
    }
}
