using System.Collections.Generic;
using System.Linq;

namespace Common.Media.FFmpeg.Args
{
    /// <summary>
    /// ffmpeg [global_options] {[input_file_options] -i input_url} ... {[output_file_options] output_url} ...
    /// </summary>
    public class FFmpegArgsBuilder : BaseArgs
    {
        public FFmpegGlobalOptionArgs GlobalOptionArgs { get; } = new FFmpegGlobalOptionArgs();
        private List<FFmpegInputArgs> InputArgs { get; } = new List<FFmpegInputArgs>();
        private List<FFmpegOutputArgs> OutputArgs { get; } = new List<FFmpegOutputArgs>();
        public FFmpegInputOptionArgs SetInputFile(string fileName)
        {
            FFmpegInputArgs fFmpegInputArgs = new FFmpegInputArgs();
            fFmpegInputArgs.SetInputFile(fileName);
            this.InputArgs.Add(fFmpegInputArgs);
            return fFmpegInputArgs.FFmpegInputOptionArgs;
        }
        public FFmpegInputOptionArgs SetInputPipe(string pipeName)
        {
            FFmpegInputArgs fFmpegInputArgs = new FFmpegInputArgs();
            fFmpegInputArgs.SetInputPipe(pipeName);
            this.InputArgs.Add(fFmpegInputArgs);
            return fFmpegInputArgs.FFmpegInputOptionArgs;
        }
        public FFmpegOutputOptionArgs SetOutputFile(string fileName)
        {
            FFmpegOutputArgs fFmpegOutputArgs = new FFmpegOutputArgs();
            fFmpegOutputArgs.SetOutputFile(fileName);
            this.OutputArgs.Add(fFmpegOutputArgs);
            return fFmpegOutputArgs.FFmpegOutputOptionArgs;
        }
        public FFmpegOutputOptionArgs SetOutputImagePipe(string pipeName)
        {
            FFmpegOutputArgs fFmpegOutputArgs = new FFmpegOutputArgs();
            fFmpegOutputArgs.SetOutputImagePipe(pipeName);
            this.OutputArgs.Add(fFmpegOutputArgs);
            return fFmpegOutputArgs.FFmpegOutputOptionArgs;
        }
        public override string Args
        {
            get
            {
                IEnumerable<string> Args()
                {
                    yield return this.GlobalOptionArgs.Args;
                    yield return string.Join(" ", this.InputArgs.Select(i => i.Args));
                    yield return string.Join(" ", this.OutputArgs.Select(i => i.Args));
                }
                return string.Join(" ", Args());
            }
        }
    }
}
