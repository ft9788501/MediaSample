using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Media.FFmpeg.Codecs;
using Common.Medias.Args;

namespace Common.Media.FFmpeg.VideoCodecs
{
    internal class X264VideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "X264(H.264)";

        public override string Description { get; } = "";

        public override void Apply(VideoWriterArgs writerArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 51 (lowest) to 0 (highest)
            var crf = (51 * (100 - writerArgs.VideoQuality)) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libx264)
                .AddArg("crf", crf)
                //"yuv420p", "yuv444p"
                .SetPixFormat(Formats.FFmpegPixFormat.yuv420p)
                //"veryslow", "slower", "slow", "medium", "fast", "faster", "veryfast", "superfast", "ultrafast" 
                .AddArg("preset", "ultrafast");
        }
    }
}