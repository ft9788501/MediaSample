using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Formats;
using System.Drawing;

namespace Common.Media.FFmpeg.Args
{
    public class FFmpegInputArgs : FFmpegArgs<FFmpegInputArgs>
    {
        public FFmpegInputOptionArgs FFmpegInputOptionArgs { get; } = new FFmpegInputOptionArgs();
        public FFmpegInputArgs()
        {
        }
        public override string Args => $"{this.FFmpegInputOptionArgs.Args} {base.Args}";

        public void SetInputFile(string fileName)
        {
            AddArg($"-i \"{fileName}\"");
        }
        public void SetInputPipe(string pipeName)
        {
            if (pipeName == null)
            {
                AddArg($"-i -");
            }
            else
            {
                AddArg($"-i {@"\\.\pipe\"}{pipeName}");
            }
        }
    }
}
