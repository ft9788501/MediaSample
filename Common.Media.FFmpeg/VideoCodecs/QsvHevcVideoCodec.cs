using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Media.FFmpeg.Codecs;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal class QsvHevcVideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "HEVC(H.265)";

        public override string Description { get; } = "";
        
        public override void Apply(VideoWriterArgs writerArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.hevc_qsv)
                .AddArg("load_plugin", "hevc_hw")
                .AddArg("q", 2)
                .AddArg("preset:v", "veryfast");
        }
    }
}