using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Formats;
using System;

namespace Common.Media.FFmpeg.Args
{
    public class FFmpegOutputArgs : FFmpegArgs<FFmpegOutputArgs>
    {
        public FFmpegOutputOptionArgs FFmpegOutputOptionArgs { get; } = new FFmpegOutputOptionArgs();
        public FFmpegOutputArgs()
        {
        }
        public override string Args => $"{this.FFmpegOutputOptionArgs.Args} {base.Args}";
        public void SetOutputFile(string fileName)
        {
            AddArg($"\"{fileName}\"");
        }
        public void SetOutputImagePipe(string pipeName)
        {
            AddArg($"{"pipe:"}{pipeName}");
        }
    }
}
