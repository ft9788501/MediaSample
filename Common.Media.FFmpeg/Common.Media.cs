using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg
{
    public abstract class BaseArgs
    {
        public abstract string Args { get; }
    }
    public abstract class FFmpegArgs<TOwner> : BaseArgs
        where TOwner : FFmpegArgs<TOwner>
    {
        protected readonly List<string> args = new List<string>();
        public override string Args => string.Join(" ", this.args);
        public TOwner AddArg(string arg)
        {
            this.args.Add(arg);
            return (TOwner)this;
        }
        public TOwner AddArg<T>(string key, T value)
        {
            return AddArg($"-{key} {value}");
        }
        #region Main
        /// <summary>
        /// -f fmt (input/output)
        /// Force input or output file format. The format is normally auto detected for input files and guessed from the file extension for output files, so this option is not needed in most cases.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner f<T>(T value) { return AddArg("f", value); }
        /// <summary>
        /// -y (global)
        /// Overwrite output files without asking.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner y() { return AddArg("-y"); }
        /// <summary>
        /// -t duration (input/output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner t<T>(T value) { return AddArg("t", value); }
        /// <summary>
        /// -to position (input/output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner to<T>(T value) { return AddArg("to", value); }
        /// <summary>
        /// -fs limit_size (output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner fs<T>(T value) { return AddArg("fs", value); }
        /// <summary>
        /// -ss position (input/output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner ss<T>(T value) { return AddArg("ss", value); }
        /// <summary>
        /// -sseof position (input) 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner sseof<T>(T value) { return AddArg("sseof", value); }
        #endregion
        #region Video
        /// <summary>
        /// -vframes number (output)
        /// Set the number of video frames to output. This is an obsolete alias for -frames:v, which you should use instead.
        /// 设置要输出的视频帧数。这是一个过时的-frames:v别名，您应该使用它来代替。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner vframes<T>(T value) { return AddArg("frames:v", value); }
        /// <summary>
        /// -r[:stream_specifier] fps (input/output,per-stream)
        /// Set frame rate (Hz value, fraction or abbreviation).
        /// As an input option, ignore any timestamps stored in the file and instead generate timestamps assuming constant frame rate fps.This is not the same as the -framerate option used for some input formats like image2 or v4l2(it used to be the same in older versions of FFmpeg). If in doubt use -framerate instead of the input option -r.
        /// As an output option, duplicate or drop input frames to achieve constant output frame rate fps.
        /// 设置帧速率（赫兹值、分数或缩写）。
        /// 作为一个输入选项，忽略存储在文件中的任何时间戳，而是在假设恒定帧速率fps的情况下生成时间戳。这与用于某些输入格式（如image2或v4l2）的-framerate选项不同（在旧版本的ffmpeg中，它以前是相同的）。如果有疑问，请使用-framerate而不是输入选项-r。
        /// 作为输出选项，复制或删除输入帧以获得恒定的输出帧速率fps。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner r<T>(T value) { return AddArg("r", value); }
        /// <summary>
        /// -s[:stream_specifier] size (input/output,per-stream)
        /// Set frame size.
        /// As an input option, this is a shortcut for the video_size private option, recognized by some demuxers for which the frame size is either not stored in the file or is configurable – e.g.raw video or video grabbers.
        /// As an output option, this inserts the scale video filter to the end of the corresponding filtergraph.Please use the scale filter directly to insert it at the beginning or some other place.
        /// The format is ‘wxh’ (default - same as source).
        /// 设置帧大小。
        /// 作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。
        /// 作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。
        /// 格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner s<T>(T value) { return AddArg("s", value); }
        /// <summary>
        /// -aspect[:stream_specifier] aspect (output,per-stream)
        /// Set the video display aspect ratio specified by aspect.
        /// aspect can be a floating point number string, or a string of the form num:den, where num and den are the numerator and denominator of the aspect ratio.For example "4:3", "16:9", "1.3333", and "1.7777" are valid argument values.
        /// If used together with -vcodec copy, it will affect the aspect ratio stored at container level, but not the aspect ratio stored in encoded frames, if it exists.
        /// 设置由纵横比指定的视频显示纵横比。
        /// 纵横比可以是浮点数字符串，也可以是num:den格式的字符串，其中num和den是纵横比的分子和分母。例如，“4:3”、“16:9”、“1.3333”和“1.7777”是有效的参数值。
        /// 如果与-vcodec copy一起使用，它将影响存储在容器级别的纵横比，但不会影响存储在编码帧中的纵横比（如果存在）。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner aspect<T>(T value) { return AddArg("aspect", value); }
        /// <summary>
        /// -vn (input/output)
        /// As an input option, blocks all video streams of a file from being filtered or being automatically selected or mapped for any output. See -discard option to disable streams individually.
        /// As an output option, disables video recording i.e.automatic selection or mapping of any video stream.For full manual control see the -map option.
        /// 作为输入选项，阻止对文件的所有视频流进行筛选或自动为任何输出选择或映射。请参见-discard选项单独禁用流。
        /// 作为输出选项，禁用视频录制，即自动选择或映射任何视频流。有关完全手动控制，请参见-map选项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner vn() { return AddArg("-vn"); }
        /// <summary>
        /// -vcodec codec (output)
        /// Set the video codec. This is an alias for -codec:v.
        /// 设置视频编解码器。这是-codec:v的别名。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner vcodec<T>(T value) { return AddArg("codec:v", value); }
        /// <summary>
        /// -pass[:stream_specifier] n (output,per-stream)
        /// Select the pass number (1 or 2). It is used to do two-pass video encoding. The statistics of the video are recorded in the first pass into a log file (see also the option -passlogfile), and in the second pass that log file is used to generate the video at the exact requested bitrate. On pass 1, you may just deactivate audio and set output to null, examples for Windows and Unix:
        /// 选择密码（1或2）。它用来做两通视频编码。视频的统计信息记录在第一次传送到日志文件中（另请参见选项-pass log file），在第二次传送中，日志文件用于以准确的请求比特率生成视频。在步骤1中，您可以停用音频并将输出设置为空，例如Windows和Unix：
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner pass<T>(T value) { return AddArg("pass", value); }
        /// <summary>
        /// -passlogfile[:stream_specifier] prefix (output,per-stream)
        /// Set two-pass log file name prefix to prefix, the default file name prefix is “ffmpeg2pass”. The complete file name will be PREFIX-N.log, where N is a number specific to the output stream
        /// 将两遍日志文件名前缀设置为前缀，默认文件名前缀为“ffmpeg2pass”。完整的文件名将是prefix-n.log，其中n是特定于输出流的数字。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner passlogfile<T>(T value) { return AddArg("passlogfile", value); }
        /// <summary>
        /// -vf filtergraph (output)
        /// Create the filtergraph specified by filtergraph and use it to filter the stream.This is an alias for -filter:v, see the -filter option.
        /// 创建由filtergraph指定的filtergraph并使用它来筛选流。这是-filter:v的别名，请参见-filter选项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner vf<T>(T value) { return AddArg("filter:v", value); }
        #endregion
        #region Advanced Video **未完成
        /// <summary>
        /// -pix_fmt[:stream_specifier] format (input/output,per-stream)
        /// Set pixel format. Use -pix_fmts to show all the supported pixel formats. If the selected pixel format can not be selected, ffmpeg will print a warning and select the best pixel format supported by the encoder. If pix_fmt is prefixed by a +, ffmpeg will exit with an error if the requested pixel format can not be selected, and automatic conversions inside filtergraphs are disabled. If pix_fmt is a single +, ffmpeg selects the same pixel format as the input (or graph output) and automatic conversions are disabled.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner pix_fmt<T>(T value) { return AddArg("pix_fmt", value); }
        /// <summary>
        /// -sws_flags flags (input/output)
        /// Set SwScaler flags.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner sws_flags<T>(T value) { return AddArg("sws_flags ", value); }
        /// <summary>
        /// -rc_override[:stream_specifier] override (output,per-stream)
        /// Rate control override for specific intervals, formatted as "int,int,int" list separated with slashes. Two first values are the beginning and end frame numbers, last one is quantizer to use if positive, or quality factor if negative.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner rc_override<T>(T value) { return AddArg("rc_override", value); }
        /// <summary>
        /// -ilme
        /// Force interlacing support in encoder (MPEG-2 and MPEG-4 only). Use this option if your input file is interlaced and you want to keep the interlaced format for minimum losses. The alternative is to deinterlace the input stream with -deinterlace, but deinterlacing introduces losses.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner ilme<T>(T value) { return AddArg("ilme", value); }
        #endregion
        #region Audio
        /// <summary>
        /// -aframes number (output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner aframes<T>(T value) { return AddArg("frames:a", value); }
        /// <summary>
        /// -ar[:stream_specifier] freq (input/output,per-stream)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner ar<T>(T value) { return AddArg("ar", value); }
        /// <summary>
        /// -aq q (output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner aq<T>(T value) { return AddArg("aq", value); }
        /// <summary>
        /// -ac[:stream_specifier] channels (input/output,per-stream)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner ac<T>(T value) { return AddArg("ac", value); }
        /// <summary>
        /// -an (input/output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner an() { return AddArg("-an"); }
        /// <summary>
        /// -acodec codec (input/output)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner acodec<T>(T value) { return AddArg("codec:a", value); }
        /// <summary>
        /// sample_fmt[:stream_specifier] sample_fmt (output,per-stream)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner sample_fmt<T>(T value) { return AddArg("sample_fmt", value); }
        /// <summary>
        /// -af filtergraph (output)
        /// Create the filtergraph specified by filtergraph and use it to filter the stream.
        /// This is an alias for -filter:a, see the -filter option.
        /// 创建由filtergraph指定的filtergraph并使用它来筛选流。
        /// 这是-filter:a的别名，请参见-filter选项。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner af<T>(T value) { return AddArg("filter:a", value); }
        #endregion
        #region Advanced **未完成
        /// <summary>
        /// -thread_queue_size size (input)
        /// This option sets the maximum number of queued packets when reading from the file or device. With low latency / high rate live streams, packets may be discarded if they are not read in a timely manner; raising this value can avoid it.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner thread_queue_size<T>(T value) { return AddArg("thread_queue_size", value); }
        /// <summary>
        /// -re (input)
        /// Read input at native frame rate. Mainly used to simulate a grab device, or live input stream (e.g. when reading from a file). Should not be used with actual grab devices or live input streams (where it can cause packet loss). By default ffmpeg attempts to read the input(s) as fast as possible. This option will slow down the reading of the input(s) to the native frame rate of the input(s). It is useful for real-time output (e.g. live streaming).
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        protected TOwner re() { return AddArg("-re"); }
        /// <summary>
        /// -accurate_seek (input)
        /// This option enables or disables accurate seeking in input files with the -ss option. It is enabled by default, so seeking is accurate when transcoding. Use -noaccurate_seek to disable it, which may be useful e.g. when copying some streams and transcoding the others.
        /// </summary>
        /// <returns></returns>
        protected TOwner accurate_seek() { return AddArg("-accurate_seek"); }
        /// <summary>
        /// -noaccurate_seek (input)
        /// </summary>
        /// <returns></returns>
        protected TOwner noaccurate_seek() { return AddArg("-noaccurate_seek "); }
        #endregion
    }
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
    public class FFmpegGlobalOptionArgs : FFmpegArgs<FFmpegGlobalOptionArgs>
    {
        public FFmpegGlobalOptionArgs()
        {
        }
        public FFmpegGlobalOptionArgs SetThreadQueueSize(int threadQueueSize)
        {
            return thread_queue_size(threadQueueSize);
        }
        /// <summary>
        /// 输出文件存在的时候，是否覆盖输出？
        /// </summary>
        /// <param name="threadQueueSize"></param>
        /// <returns></returns>
        public FFmpegGlobalOptionArgs OverwriteOutput()
        {
            return y();
        }
    }
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
    public class FFmpegInputOptionArgs : FFmpegArgs<FFmpegInputOptionArgs>
    {
        public FFmpegInputOptionArgs()
        {
        }
        #region Video
        /// <summary>
        /// FPS
        /// 设置帧速率（赫兹值、分数或缩写）。作为一个输入选项，忽略存储在文件中的任何时间戳，而是在假设恒定帧速率fps的情况下生成时间戳。这与用于某些输入格式（如image2或v4l2）的-framerate选项不同（在旧版本的ffmpeg中，它以前是相同的）。如果有疑问，请使用-framerate而不是输入选项-r。
        /// </summary>
        /// <param name="framerate"></param>
        /// <returns></returns>
        public FFmpegInputOptionArgs SetFramerate(double framerate)
        {
            return r(framerate);
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public FFmpegInputOptionArgs SetVideoSize(Size size)
        {
            return s($"{size.Width}x{size.Height}");
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public FFmpegInputOptionArgs SetVideoSize(int width, int height)
        {
            return s($"{width}x{height}");
        }
        /// <summary>
        /// 作为输入选项，阻止对文件的所有视频流进行筛选或自动为任何输出选择或映射。请参见-discard选项单独禁用流。作为输出选项，禁用视频录制，即自动选择或映射任何视频流。有关完全手动控制，请参见-map选项。
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SetVideoDisable()
        {
            return vn();
        }
        public FFmpegInputOptionArgs SetAudioFormat(FFmpegAudioFormat format)
        {
            return f(format);
        }
        public FFmpegInputOptionArgs SetVideoFormat(FFmpegVideoFormat format)
        {
            return f(format);
        }
        public FFmpegInputOptionArgs SetPixFormat(FFmpegPixFormat format)
        {
            return pix_fmt(format);
        }
        public FFmpegInputOptionArgs SetAudioCodec(FFmpegAudioCodec audioCodec)
        {
            return acodec(audioCodec);
        }
        public FFmpegInputOptionArgs SetAudioFrequency(int frequency)
        {
            return ar(frequency);
        }
        public FFmpegInputOptionArgs SetAudioChannels(int channels)
        {
            return ac(channels);
        }
        public FFmpegInputOptionArgs SetSeek(TimeSpan seek)
        {
            return ss(seek);
        }
        public FFmpegInputOptionArgs SetSeekEnd(TimeSpan seek)
        {
            return to(seek);
        }
        /// <summary>
        /// 只seek在关键帧上
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SeekKeyframe()
        {
            return noaccurate_seek();
        }
        /// <summary>
        /// seek在精确的时间点上
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SeekAccurate()
        {
            return accurate_seek();
        }
        public FFmpegInputOptionArgs SetDuration(TimeSpan seek)
        {
            return t(seek);
        }
        public FFmpegInputOptionArgs DisableAudio()
        {
            return an();
        }
        /// <summary>
        /// 以视频的帧速率读取数据
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs ReadByNativeFrame()
        {
            return re();
        }
        #endregion
    }
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
    public class FFmpegOutputOptionArgs : FFmpegArgs<FFmpegOutputOptionArgs>
    {
        public FFmpegOutputOptionArgs()
        {
        }
        #region Video
        /// <summary>
        /// 设置要输出的视频帧数。这是一个过时的-frames:v别名，您应该使用它来代替。
        /// </summary>
        /// <param name="frameNum"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetOutputVideoFrame(int frameNum = 1)
        {
            return vframes(frameNum);
        }
        /// <summary>
        /// FPS
        /// 设置帧速率（赫兹值、分数或缩写）。作为一个输入选项，忽略存储在文件中的任何时间戳，而是在假设恒定帧速率fps的情况下生成时间戳。这与用于某些输入格式（如image2或v4l2）的-framerate选项不同（在旧版本的ffmpeg中，它以前是相同的）。如果有疑问，请使用-framerate而不是输入选项-r。
        /// </summary>
        /// <param name="framerate"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetFramerate(double framerate)
        {
            return r(framerate);
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoSize(Size size)
        {
            return s($"{size.Width}x{size.Height}");
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoSize(int width, int height)
        {
            return s($"{width}x{height}");
        }
        /// <summary>
        /// 设置由纵横比指定的视频显示纵横比。纵横比可以是浮点数字符串，也可以是num:den格式的字符串，其中num和den是纵横比的分子和分母。例如，“4:3”、“16:9”、“1.3333”和“1.7777”是有效的参数值。如果与-vcodec copy一起使用，它将影响存储在容器级别的纵横比，但不会影响存储在编码帧中的纵横比（如果存在）。
        /// </summary>
        /// <param name="videoAspect"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoAspect(FFmpegVideoAspect videoAspect)
        {
            return aspect($"{videoAspect}");
        }
        /// <summary>
        /// 作为输入选项，阻止对文件的所有视频流进行筛选或自动为任何输出选择或映射。请参见-discard选项单独禁用流。作为输出选项，禁用视频录制，即自动选择或映射任何视频流。有关完全手动控制，请参见-map选项。
        /// </summary>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoDisable()
        {
            return vn();
        }
        public FFmpegOutputOptionArgs SetVideoCodec(FFmpegVideoCodec videoCodec)
        {
            return vcodec(videoCodec);
        }
        #endregion
        public FFmpegOutputOptionArgs SetAudioFormat(FFmpegAudioFormat format)
        {
            return f(format);
        }
        public FFmpegOutputOptionArgs SetVideoFormat(FFmpegVideoFormat format)
        {
            return f(format);
        }
        public FFmpegOutputOptionArgs SetPixFormat(FFmpegPixFormat format)
        {
            return pix_fmt(format);
        }
        public FFmpegOutputOptionArgs SetAudioCodec(FFmpegAudioCodec audioCodec)
        {
            return acodec(audioCodec);
        }
        public FFmpegOutputOptionArgs SetAudioFrequency(int frequency)
        {
            return ar(frequency);
        }
        public FFmpegOutputOptionArgs SetAudioChannels(int channels)
        {
            return ac(channels);
        }
        public FFmpegOutputOptionArgs SetAudioSampleFormat(Formats.FFmpegSampleFormat sampleFormat)
        {
            return sample_fmt(sampleFormat);
        }
        public FFmpegOutputOptionArgs SetSeek(TimeSpan seek)
        {
            return ss(seek);
        }
        public FFmpegOutputOptionArgs SetSeekEnd(TimeSpan seek)
        {
            return to(seek);
        }
        public FFmpegOutputOptionArgs SetDuration(TimeSpan seek)
        {
            return t(seek);
        }
        public FFmpegOutputOptionArgs SetOutputAudioFrame(int frameNum = 1)
        {
            return aframes(frameNum);
        }
        public FFmpegOutputOptionArgs SetOutputAllFrame()
        {
            return AddArg("update", 1);
        }
        public FFmpegOutputOptionArgs SetVideoBitrate(int bitrate)
        {
            return AddArg("b:v", bitrate);
        }
        public FFmpegOutputOptionArgs SetVideoBitrate(string bitrate)
        {
            return AddArg("b:v", bitrate);
        }
        public FFmpegOutputOptionArgs SetAudioBitrate(int bitrate)
        {
            return AddArg("b:a", bitrate);
        }
        public FFmpegOutputOptionArgs SetAudioBitrate(string bitrate)
        {
            return AddArg("b:a", bitrate);
        }
    }
    internal class AACAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "AAC";

        public override string Extension { get; } = ".aac";

        public override string Description { get; } = "aac";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // bitrate: 32k to 512k (steps of 32k)
            var b = 32 * (1 + (15 * (audioWriterArgs.AudioQuality - 1)) / 99);
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.aac)
                .AddArg("-strict -2")
                .SetAudioBitrate($"{b}k");
        }
    }
    internal abstract class AudioCodecBase : IWriterItem
    {
        public abstract string Name { get; }

        public abstract string Extension { get; }

        public abstract string Description { get; }

        public abstract void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs);

        public override string ToString() => Name;
    }
    internal class Mp3AudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Mp3";

        public override string Extension { get; } = ".mp3";

        public override string Description { get; } = "Mp3";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 9 (lowest) to 0 (highest)
            var qscale = (100 - audioWriterArgs.AudioQuality) / 11;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libmp3lame)
                .AddArg("qscale:a", qscale);
        }
    }
    internal class OpusAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Opus";

        public override string Extension { get; } = ".opus";

        public override string Description { get; } = "Opus";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 0 (lowest) to 10 (highest)
            var qscale = (10 * (audioWriterArgs.AudioQuality - 1)) / 99;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libopus)
                .AddArg("compression_level", qscale);
        }
    }
    internal class VorbisAudioCodec : AudioCodecBase
    {
        public override string Name { get; } = "Vorbis";

        public override string Extension { get; } = ".ogg";

        public override string Description { get; } = "Vorbis";

        public override void Apply(AudioWriterArgs audioWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 0 (lowest) to 10 (highest)
            var qscale = (10 * (audioWriterArgs.AudioQuality - 1)) / 99;
            outputOptionArgs.SetAudioCodec(Codecs.FFmpegAudioCodec.libvorbis)
                .AddArg("qscale:a", qscale);
        }
    }
    public class FFmpegAudioCodec
    {
        public static FFmpegAudioCodec pcm_s16le = "pcm_s16le";
        public static FFmpegAudioCodec pcm_s24le = "pcm_s24le";
        public static FFmpegAudioCodec pcm_u8 = "pcm_u8";
        public static FFmpegAudioCodec ac3_fixed = "ac3_fixed";
        public static FFmpegAudioCodec aac = "aac";
        public static FFmpegAudioCodec ac3 = "ac3";
        public static FFmpegAudioCodec mp2 = "mp2";
        public static FFmpegAudioCodec libfdk_aac = "libfdk_aac";
        public static FFmpegAudioCodec libvorbis = "libvorbis";
        public static FFmpegAudioCodec libopus = "libopus";
        public static FFmpegAudioCodec libmp3lame = "libmp3lame";
        public static FFmpegAudioCodec copy = "copy";
        private string codec = string.Empty;
        private FFmpegAudioCodec(string codec)
        {
            this.codec = codec;
        }
        public static implicit operator string(FFmpegAudioCodec codec)
        {
            return codec.codec;
        }
        public static implicit operator FFmpegAudioCodec(string codec)
        {
            return new FFmpegAudioCodec(codec);
        }
        public override string ToString()
        {
            return this.codec;
        }
    }
    public class FFmpegVideoCodec
    {
        public static FFmpegVideoCodec libvpx = "libvpx";
        public static FFmpegVideoCodec libvpx_vp9 = "libvpx-vp9";
        public static FFmpegVideoCodec libx264 = "libx264";
        public static FFmpegVideoCodec libxvid = "libxvid";
        public static FFmpegVideoCodec hevc_qsv = "hevc_qsv";
        public static FFmpegVideoCodec copy = "copy";
        private string codec = string.Empty;
        private FFmpegVideoCodec(string codec)
        {
            this.codec = codec;
        }
        public static implicit operator string(FFmpegVideoCodec codec)
        {
            return codec.codec;
        }
        public static implicit operator FFmpegVideoCodec(string codec)
        {
            return new FFmpegVideoCodec(codec);
        }
        public override string ToString()
        {
            return this.codec;
        }
    }
    public class FFmpegException : Exception
    {
        public FFmpegException(int exitCode, Exception innerException = null)
            : base($"FFmpeg发生错误,错误代码: {exitCode}.\r\n查看FFmpeg日志获取更多信息", innerException) { }
    }
    public class FFmpegNotFoundException : Exception
    {
    }
    /// <summary>
    //s means "signed" (for the integer representations)= u would mean "unsigned"
    //16 means 16 Bits per sample
    //le means "little endian" coding for the samples
    /// https://trac.ffmpeg.org/wiki/audio%20types
    /// </summary>
    public class FFmpegAudioFormat
    {
        /// <summary>                                                              
        /// PCM A-law                                                              
        /// </summary>                                                             
        public static FFmpegAudioFormat alaw = "alaw";
        /// <summary>                                                           
        /// PCM 32-bit floating-point big-endian                                
        /// </summary>                                                          
        public static FFmpegAudioFormat f32be = "f32be";
        /// <summary>                                                             
        /// PCM 32-bit floating-point little-endian                               
        /// </summary>                                                            
        public static FFmpegAudioFormat f32le = "f32le";
        /// <summary>                                                              
        /// PCM 64-bit floating-point big-endian                                   
        /// </summary>                                                             
        public static FFmpegAudioFormat f64be = "f64be";
        /// <summary>                                                            
        /// PCM 64-bit floating-point little-endian                              
        /// </summary>                                                           
        public static FFmpegAudioFormat f64le = "f64le";
        /// <summary>                                                             
        /// PCM mu-law                                                            
        /// </summary>                                                            
        public static FFmpegAudioFormat mulaw = "mulaw";
        /// <summary>                                                            
        /// PCM signed 16-bit big-endian                                         
        /// </summary>                                                           
        public static FFmpegAudioFormat s16be = "s16be";
        /// <summary>                                                             
        /// PCM signed 16-bit little-endian                                       
        /// </summary>                                                            
        public static FFmpegAudioFormat s16le = "s16le";
        /// <summary>                                                           
        /// PCM signed 24-bit big-endian                                        
        /// </summary>                                                          
        public static FFmpegAudioFormat s24be = "s24be";
        /// <summary>                                                            
        /// PCM signed 24-bit little-endian                                      
        /// </summary>                                                           
        public static FFmpegAudioFormat s24le = "s24le";
        /// <summary>                                                             
        /// PCM signed 32-bit big-endian                                          
        /// </summary>                                                            
        public static FFmpegAudioFormat s32be = "s32be";
        /// <summary>                                                            
        /// PCM signed 32-bit little-endian                                      
        /// </summary>                                                           
        public static FFmpegAudioFormat s32le = "s32le";
        /// <summary>                                                             
        /// PCM signed 8-bit                                                      
        /// </summary>                                                            
        public static FFmpegAudioFormat s8 = "s8";
        /// <summary>                                                            
        /// PCM unsigned 16-bit big-endian                                       
        /// </summary>                                                           
        public static FFmpegAudioFormat u16be = "u16be";
        /// <summary>                                                            
        /// PCM unsigned 16-bit little-endian                                    
        /// </summary>                                                           
        public static FFmpegAudioFormat u16le = "u16le";
        /// <summary>                                                            
        /// PCM unsigned 24-bit big-endian                                       
        /// </summary>                                                           
        public static FFmpegAudioFormat u24be = "u24be";
        /// <summary>                                                             
        /// PCM unsigned 24-bit little-endian                                     
        /// </summary>                                                            
        public static FFmpegAudioFormat u24le = "u24le";
        /// <summary>                                                           
        /// PCM unsigned 32-bit big-endian                                      
        /// </summary>                                                          
        public static FFmpegAudioFormat u32be = "u32be";
        /// <summary>                                                           
        /// PCM unsigned 32-bit little-endian                                   
        /// </summary>                                                          
        public static FFmpegAudioFormat u32le = "u32le";
        /// <summary>                                                             
        /// PCM unsigned 8-bit                                                    
        /// </summary>                                                            
        public static FFmpegAudioFormat u8 = "u8";
        private string format = string.Empty;
        private FFmpegAudioFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegAudioFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegAudioFormat(string format)
        {
            return new FFmpegAudioFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
    //I.... = Supported Input format for conversion
    //.O... = Supported Output format for conversion
    //..H.. = Hardware accelerated format
    //...P. = Paletted format
    //....B = Bitstream format
    public class FFmpegPixFormat
    {
        ///  <summary>  
        /// IO...
        /// </summary>      
        public static FFmpegPixFormat yuv420p = "yuv420p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuyv422 = "yuyv422";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb24 = "rgb24";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb32 = "rgb32";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr24 = "bgr24";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p = "yuv422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p = "yuv444p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv410p = "yuv410p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv411p = "yuv411p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray = "gray";
        /// <summary>
        /// IO..B. 
        /// </summary>
        public static FFmpegPixFormat monow = "monow";
        /// <summary>
        /// IO..B. 
        /// </summary>
        public static FFmpegPixFormat monob = "monob";
        /// <summary>
        /// I..P.
        /// </summary>
        public static FFmpegPixFormat pal8 = "pal8";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj420p = "yuvj420p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj422p = "yuvj422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuvj444p = "yuvj444p";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat xvmcmc = "xvmcmc";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat xvmcidct = "xvmcidct";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat uyvy422 = "uyvy422";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat uyyvyy411 = "uyyvyy411";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr8 = "bgr8";
        /// <summary>
        /// .O..B.
        /// </summary>
        public static FFmpegPixFormat bgr4 = "bgr4";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr4_byte = "bgr4_byte";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb8 = "rgb8";
        /// <summary>
        /// .O..B.
        /// </summary>
        public static FFmpegPixFormat rgb4 = "rgb4";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb4_byte = "rgb4_byte";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat nv12 = "nv12";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat nv21 = "nv21";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat argb = "argb";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgba = "rgba";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat abgr = "abgr";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgra = "bgra";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray16be = "gray16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray16le = "gray16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p = "yuv440p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuvj440p = "yuvj440p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p = "yuva420p";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau_h264 = "vdpau_h264";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg1 = "vdpau_mpeg1";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg2 = "vdpau_mpeg2";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_wmv3 = "vdpau_wmv3";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_vc1 = "vdpau_vc1";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb48be = "rgb48be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb48le = "rgb48le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb565be = "rgb565be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb565le = "rgb565le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb555be = "rgb555be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb555le = "rgb555le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr565be = "bgr565be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr565le = "bgr565le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr555be = "bgr555be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr555le = "bgr555le";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_moco = "vaapi_moco";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_idct = "vaapi_idct";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_vld = "vaapi_vld";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p16le = "yuv420p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p16be = "yuv420p16be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p16le = "yuv422p16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p16be = "yuv422p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p16le = "yuv444p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p16be = "yuv444p16be";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg4 = "vdpau_mpeg4";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat dxva2_vld = "dxva2_vld";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb444le = "rgb444le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb444be = "rgb444be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr444le = "bgr444le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr444be = "bgr444be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat ya8 = "ya8";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr48be = "bgr48be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr48le = "bgr48le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p9be = "yuv420p9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p9le = "yuv420p9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p10be = "yuv420p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p10le = "yuv420p10le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p10be = "yuv422p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p10le = "yuv422p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p9be = "yuv444p9be";
        /// <summary>
        ///  IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p9le = "yuv444p9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p10be = "yuv444p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p10le = "yuv444p10le";
        /// <summary>
        /// IO...         
        /// </summary>
        public static FFmpegPixFormat yuv422p9be = "yuv422p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p9le = "yuv422p9le";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vda_vld = "vda_vld";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp = "gbrp";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp9be = "gbrp9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp9le = "gbrp9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp10be = "gbrp10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp10le = "gbrp10le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrp16be = "gbrp16be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrp16le = "gbrp16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p = "yuva422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p = "yuva444p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p9be = "yuva420p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p9le = "yuva420p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p9be = "yuva422p9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p9le = "yuva422p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p9be = "yuva444p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p9le = "yuva444p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p10be = "yuva420p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p10le = "yuva420p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p10be = "yuva422p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p10le = "yuva422p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p10be = "yuva444p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p10le = "yuva444p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva420p16be = "yuva420p16be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p16le = "yuva420p16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p16be = "yuva422p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p16le = "yuva422p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p16be = "yuva444p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p16le = "yuva444p16le";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau = "vdpau";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat xyz12le = "xyz12le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat xyz12be = "xyz12be";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv16 = "nv16";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv20le = "nv20le";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv20be = "nv20be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgba64be = "rgba64be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgba64le = "rgba64le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgra64be = "bgra64be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgra64le = "bgra64le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yvyu422 = "yvyu422";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vda = "vda";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat ya16be = "ya16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat ya16le = "ya16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrap = "gbrap";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap16be = "gbrap16be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap16le = "gbrap16le";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat qsv = "qsv";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat mmal = "mmal";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat d3d11va_vld = "d3d11va_vld";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat cuda = "cuda";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb0 = "rgb0";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr0 = "bgr0";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p12be = "yuv420p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p12le = "yuv420p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p14be = "yuv420p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p14le = "yuv420p14le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p12be = "yuv422p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p12le = "yuv422p12le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p14be = "yuv422p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p14le = "yuv422p14le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p12be = "yuv444p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p12le = "yuv444p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p14be = "yuv444p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p14le = "yuv444p14le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp12be = "gbrp12be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp12le = "gbrp12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp14be = "gbrp14be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp14le = "gbrp14le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj411p = "yuvj411p";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr8 = "bayer_bggr8";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat bayer_rggb8 = "bayer_rggb8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg8 = "bayer_gbrg8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg8 = "bayer_grbg8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr16le = "bayer_bggr16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr16be = "bayer_bggr16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_rggb16le = "bayer_rggb16le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat bayer_rggb16be = "bayer_rggb16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg16le = "bayer_gbrg16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg16be = "bayer_gbrg16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg16le = "bayer_grbg16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg16be = "bayer_grbg16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p10le = "yuv440p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p10be = "yuv440p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p12le = "yuv440p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv440p12be = "yuv440p12be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat ayuv64le = "ayuv64le";
        /// <summary>
        /// ..... 
        /// </summary>
        public static FFmpegPixFormat ayuv64be = "ayuv64be";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat videotoolbox_vld = "videotoolbox_vld";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat p010le = "p010le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat p010be = "p010be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap12be = "gbrap12be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap12le = "gbrap12le";
        /// <summary>
        /// I.... 
        /// </summary>
        /// gbrap10be               =
        /// <summary>
        /// I.... 
        /// </summary>           
        public static FFmpegPixFormat gbrap10le = "gbrap10le";
        /// <summary>
        /// ..H..                            
        /// </summary>
        public static FFmpegPixFormat mediacodec = "mediacodec";
        private string format = string.Empty;
        private FFmpegPixFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegPixFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegPixFormat(string format)
        {
            return new FFmpegPixFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
    //I.... = Supported Input format for conversion
    //.O... = Supported Output format for conversion
    //..H.. = Hardware accelerated format
    //...P. = Paletted format
    //....B = Bitstream format
    public class FFmpegSampleFormat
    {
        /// <summary>
        /// 8
        /// </summary>
        public static FFmpegSampleFormat u8 = "u8";
        /// <summary>
        /// 16
        /// </summary>
        public static FFmpegSampleFormat s16 = "s16";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat s32 = "s32";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat flt = "flt";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat dbl = "dbl";
        /// <summary>
        /// 8
        /// </summary>
        public static FFmpegSampleFormat u8p = "u8p";
        /// <summary>
        /// 16
        /// </summary>
        public static FFmpegSampleFormat s16p = "s16p";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat s32p = "s32p";
        /// <summary>
        /// 32
        /// </summary>
        public static FFmpegSampleFormat fltp = "fltp";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat dblp = "dblp";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat s64 = "s64";
        /// <summary>
        /// 64
        /// </summary>
        public static FFmpegSampleFormat s64p = "s64p";
        private string format = string.Empty;
        private FFmpegSampleFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegSampleFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegSampleFormat(string format)
        {
            return new FFmpegSampleFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
    public class FFmpegVideoFormat
    {
        public static FFmpegVideoFormat rawvideo = "rawvideo";
        public static FFmpegVideoFormat image2 = "image2";
        public static FFmpegVideoFormat image2pipe = "image2pipe";
        public static FFmpegVideoFormat flv = "flv";
        public static FFmpegVideoFormat live_flv = "live_flv";
        private string format = string.Empty;
        private FFmpegVideoFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegVideoFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegVideoFormat(string format)
        {
            return new FFmpegVideoFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
    public class FFmpegVideoAspect
    {
        public static FFmpegVideoAspect VA4_3 = "4:3";
        public static FFmpegVideoAspect VA16_9 = "16:9";
        private string videoAspect = string.Empty;
        private FFmpegVideoAspect(string videoAspect)
        {
            this.videoAspect = videoAspect;
        }
        public static implicit operator string(FFmpegVideoAspect videoAspect)
        {
            return videoAspect.videoAspect;
        }
        public static implicit operator FFmpegVideoAspect(string videoAspect)
        {
            return new FFmpegVideoAspect(videoAspect);
        }
        public override string ToString()
        {
            return this.videoAspect;
        }
    }
    // ReSharper disable once InconsistentNaming
    internal abstract class FFmpegPostProcessingCodec : VideoCodecBase
    {
        protected abstract string PostProcessingName { get; }
        protected abstract string PostProcessingDescription { get; }

        public override string Name { get; }

        public override string Description { get; }

        protected FFmpegPostProcessingCodec()
        {
            this.Name = $"Post Processing: {this.PostProcessingName}";
            this.Description = $"{Description}\nEncoding is done after recording has been finished";
        }
    }
    internal class QsvHevcVideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "Intel QuickSync: Mp4 (HEVC, AAC)";

        public override string Extension { get; } = ".mp4";

        public override string Description { get; } = "Encode to Mp4: HEVC(H.265) with AAC audio using Intel QuickSync hardware encoding.\nRequires the processor to be Skylake generation or later";

        public override AudioCodecBase AudioCodec { get; } = new AACAudioCodec();

        public override void Apply(VideoWriterArgs writerArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.hevc_qsv)
                .AddArg("load_plugin", "hevc_hw")
                .AddArg("q", 2)
                .AddArg("preset:v", "veryfast");
        }
    }
    internal abstract class VideoCodecBase : IWriterItem
    {
        public abstract string Name { get; }

        public abstract string Extension { get; }

        public abstract string Description { get; }

        public abstract AudioCodecBase AudioCodec { get; }

        public abstract void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputArgs);

        public override string ToString() => Name;
    }
    internal class Vp8VideoCodec : FFmpegPostProcessingCodec
    {
        public override string Extension { get; } = ".webm";

        protected override string PostProcessingName { get; } = "WebM (Vp8, Opus)";

        protected override string PostProcessingDescription { get; } = "Encode to WebM: Vp8 with Opus audio";

        public override AudioCodecBase AudioCodec { get; } = new OpusAudioCodec();

        public override void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 63 (lowest) to 4 (highest)
            var crf = 63 - ((videoWriterArgs.VideoQuality - 1) * 59) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libvpx)
                .AddArg("crf", crf)
                .SetVideoBitrate("1M");
        }
    }
    internal class Vp9VideoCodec : FFmpegPostProcessingCodec
    {
        public override string Extension { get; } = ".webm";

        protected override string PostProcessingName { get; } = "WebM (Vp9, Opus)";

        protected override string PostProcessingDescription { get; } = "Encode to WebM: Vp9 with Opus audio";

        public override AudioCodecBase AudioCodec { get; } = new OpusAudioCodec();

        public override void Apply(VideoWriterArgs videoWriterArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 63 (lowest) to 0 (highest)
            var crf = (63 * (100 - videoWriterArgs.VideoQuality)) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libvpx_vp9)
                .AddArg("crf", crf)
                .SetVideoBitrate(0);
        }
    }
    internal class X264VideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "Mp4 (H.264, AAC)";

        public override string Extension { get; } = ".mp4";

        public override string Description { get; } = "Encode to Mp4: H.264 with AAC audio using x264 encoder.";

        public override AudioCodecBase AudioCodec { get; } = new AACAudioCodec();

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
    internal class XvidVideoCodec : VideoCodecBase
    {
        public override string Name { get; } = "Avi (Xvid, Mp3)";

        public override string Extension { get; } = ".avi";

        public override string Description { get; } = "Encode to Avi with Mp3 audio using Xvid encoder";

        public override AudioCodecBase AudioCodec { get; } = new Mp3AudioCodec();

        public override void Apply(VideoWriterArgs writerArgs, FFmpegOutputOptionArgs outputOptionArgs)
        {
            // quality: 31 (lowest) to 1 (highest)
            var qscale = 31 - ((writerArgs.VideoQuality - 1) * 30) / 99;
            outputOptionArgs.SetVideoCodec(Codecs.FFmpegVideoCodec.libxvid)
                .AddArg("qscale:v", qscale);
        }
    }
    internal class FFmpegMediaHelper : IMediaHelper
    {
        public bool MediaConvertAuto(string input, string output)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputFile(input);
                fFmpegArgsBuilder.SetOutputFile(output);
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MediaCut(string input, string output, TimeSpan start, TimeSpan? end = null)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                var inputOptionArgs = fFmpegArgsBuilder.SetInputFile(input)
                    .SetSeek(start);
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputFile(input)
                    ;
                if (end != null)
                {
                    outputOptionArgs
                       .SetSeekEnd(end.Value)
                       .SetAudioCodec(Codecs.FFmpegAudioCodec.copy)
                       .SetVideoCodec(Codecs.FFmpegVideoCodec.copy);
                }
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MediaConvertPCM_S16E(string input, string output, int sampleRate)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputFile(input);
                fFmpegArgsBuilder.SetOutputFile(output)
                    //.SetAudioFormat(AudioFormat.s16le)
                    .SetAudioCodec(FFmpegAudioCodec.pcm_s16le)
                    .SetAudioFrequency(sampleRate)
                    .SetAudioChannels(2)
                    ;
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
    internal class FFmpegMediaInfo : IMediaInfo
    {
        public int Width { get; private set; }

        public int Height { get; private set; }

        public string AudioFormat { get; private set; }

        public string VideoFormat { get; private set; }

        public string PixFormat { get; private set; }

        public TimeSpan Duration { get; private set; }

        public double Framerate { get; private set; }

        public string VideoBitrate { get; private set; }

        public string AudioBitrate { get; private set; }

        public int AudioFrequency { get; private set; }

        public string Bitrate { get; private set; }
        /// <summary>
        /// 这个算法还没有完成 用来获取Duration还是可以的
        /// </summary>
        /// <param name="filePath"></param>
        public void Open(string filePath)
        {
            FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
            fFmpegArgsBuilder.SetInputFile(filePath);
            StreamReader streamReader = FFmpegService.StartFFmpegErrorStream(fFmpegArgsBuilder.Args);
            string line = string.Empty;
            line = streamReader.ReadToEnd();
            string regexDuration = "Duration: (.*?), start: (.*?), bitrate: (\\d*) kb\\/s";
            string regexVideo = "Video: (.*?), (.*?), (\\d*x\\d*).*?, (.*?) kb/s, (.*?)[,\\s]";
            string regexAudio = "Audio: (.*?), (.*?) Hz, (.*?), (.*?), (.*?) kb/s";
            Regex regex;
            Match match;
            regex = new Regex(regexDuration);
            match = regex.Match(line);
            if (match.Groups.Count == 4)
            {
                if (TimeSpan.TryParse(match.Groups[1].Value, out TimeSpan timeSpan))
                {
                    this.Duration = timeSpan;
                }
                this.Bitrate = regex.Match(line).Groups[3].Value;
            }
            regex = new Regex(regexVideo);
            match = regex.Match(line);
            if (match.Groups.Count == 6)
            {
                this.VideoFormat = regex.Match(line).Groups[1].Value;
                this.PixFormat = regex.Match(line).Groups[2].Value;
                this.Width = int.Parse(regex.Match(line).Groups[3].Value.Split('x')[0]);
                this.Height = int.Parse(regex.Match(line).Groups[3].Value.Split('x')[1]);
                this.VideoBitrate = regex.Match(line).Groups[4].Value;
                if (double.TryParse(regex.Match(line).Groups[5].Value, out double framerate))
                {
                    this.Framerate = framerate;
                }
            }
            regex = new Regex(regexAudio);
            match = regex.Match(line);
            if (match.Groups.Count == 6)
            {
                this.AudioFormat = regex.Match(line).Groups[1].Value;
                if (int.TryParse(regex.Match(line).Groups[2].Value, out int audioFrequency))
                {
                    this.AudioFrequency = audioFrequency;
                }
                this.AudioBitrate = regex.Match(line).Groups[5].Value;
            }
        }
    }
    public static class FFmpegProvider
    {
        public static IVideoFileWriter GetVideoFileWriter()
        {
            return new FFmpegVideoWriter();
        }
        public static IVideoFileReader GetVideoFileReader()
        {
            return new FFmpegVideoReader();
        }
        public static IMediaHelper GetMediaHelper()
        {
            return new FFmpegMediaHelper();
        }
        public static IMediaInfo GetMediaInfo()
        {
            return new FFmpegMediaInfo();
        }
        public static IEnumerable<IWriterItem> VideoCodecItems
        {
            get
            {
                yield return new X264VideoCodec();
                yield return new XvidVideoCodec();
                yield return new QsvHevcVideoCodec();
                yield return new Vp8VideoCodec();
                yield return new Vp9VideoCodec();
            }
        }
        public static IWriterItem SelectVideoCodec { get; set; } = new X264VideoCodec();
    }
    public static class FFmpegService
    {
        private static string folderPath = @"c:\";
        private const string FFMPEGEXE = "ffmpeg.exe";
        public static bool FFmpegExists
        {
            get
            {
                // FFmpeg folder
                if (!string.IsNullOrWhiteSpace(folderPath))
                {
                    var path = Path.Combine(folderPath, FFMPEGEXE);
                    if (File.Exists(path))
                    {
                        return true;
                    }
                }
                // PATH
                try
                {
                    Process.Start(new ProcessStartInfo
                    {
                        FileName = FFMPEGEXE,
                        Arguments = "-version",
                        UseShellExecute = false,
                        CreateNoWindow = true
                    });
                    return true;
                }
                catch { return false; }
            }
        }

        public static Process StartFFmpeg(string arguments)
        {
            var path = Path.Combine(folderPath, FFMPEGEXE);
            var process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                    RedirectStandardInput = true
                },
                EnableRaisingEvents = true
            };
            process.OutputDataReceived += (s, e) =>
            {
                Console.WriteLine(e.Data);
            };
            process.ErrorDataReceived += (s, e) =>
            {
                Console.WriteLine(e.Data);
            };
            process.Start();
            process.BeginErrorReadLine();
            return process;
        }
        public static Process StartFFmpegStandardOutput(string arguments)
        {
            var path = Path.Combine(folderPath, FFMPEGEXE);
            var process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardOutput = true,
                    RedirectStandardInput = true
                }
            };
            process.Start();
            return process;
        }
        public static StreamReader StartFFmpegErrorStream(string arguments)
        {
            var path = Path.Combine(folderPath, FFMPEGEXE);
            var process = new Process
            {
                StartInfo =
                {
                    FileName = path,
                    Arguments = arguments,
                    UseShellExecute = false,
                    CreateNoWindow = true,
                    RedirectStandardError = true,
                }
            };
            process.Start();
            try
            {
                return process.StandardError;
            }
            finally
            {
                process.WaitForExit();
            }
        }
    }
    public class FFmpegVideoReader : IVideoFileReader
    {
        private Process ffmpegProcess;
        private string inputPipeName = $"input-{Guid.NewGuid()}";
        private string videoPipeName = $"videoR-{Guid.NewGuid()}";
        private string filePath = string.Empty;
        private FFmpegMediaInfo fFmpegMediaInfo = null;
        public int FrameCount => (int)(Duration.TotalMilliseconds / (1000.0 / this.FPS));

        public double FPS { get; set; }

        public int Width => this.fFmpegMediaInfo.Width;

        public int Height => this.fFmpegMediaInfo.Height;

        public TimeSpan Duration => this.fFmpegMediaInfo.Duration;

        public FFmpegVideoReader()
        {
            if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
        }
        public void Dispose()
        {
            try
            {
                this.ffmpegProcess?.Kill();
            }
            catch (Exception ex)
            {

            }
        }

        public bool Open(string filePath)
        {
            try
            {
                this.filePath = filePath;
                fFmpegMediaInfo = new FFmpegMediaInfo();
                fFmpegMediaInfo.Open(this.filePath);
                return true;
            }
            catch { return false; }
        }

        public Stream ReadVideoFrame(TimeSpan seek, Size? size)
        {
            this.Dispose();
            try
            {
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .SetThreadQueueSize(512)
                    ;
                fFmpegArgsBuilder.SetInputFile(this.filePath)
                    .SeekAccurate()
                    .ReadByNativeFrame()
                    .SetSeek(seek)
                    ;
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputImagePipe(videoPipeName)
                    .SetPixFormat(Formats.FFmpegPixFormat.rgb24)
                    .SetOutputVideoFrame(1)
                    .SetVideoFormat(FFmpegVideoFormat.image2)
                    .SetFramerate(this.FPS)
                    ;
                if (size != null)
                {
                    outputOptionArgs
                       .SetVideoSize(size.Value);
                }
                this.ffmpegProcess = FFmpegService.StartFFmpegStandardOutput(fFmpegArgsBuilder.Args);
                return this.ffmpegProcess.StandardOutput.BaseStream;
            }
            catch
            {

            }
            return null;
        }

        public IEnumerable<VideoFrameArgs> ReadVideoFrames(TimeSpan? seek = null, TimeSpan? seekEnd = null, Size? size = null, bool readByNativeFrame = true, CancellationToken? cancellationToken = null)
        {
            this.Dispose();
            TimeSpan startSeek = seek ?? TimeSpan.FromSeconds(0);
            FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
            fFmpegArgsBuilder.GlobalOptionArgs
                .SetThreadQueueSize(512)
                        ;
            var inputOptionArgs = fFmpegArgsBuilder.SetInputFile(this.filePath)
                .SeekAccurate()
                .SetSeek(startSeek)
                ;
            if (readByNativeFrame)
            {
                inputOptionArgs
                    .ReadByNativeFrame();
            }
            var outputOptionArgs = fFmpegArgsBuilder.SetOutputImagePipe(videoPipeName)
                .SetPixFormat(Formats.FFmpegPixFormat.rgb24)
                .SetVideoFormat(FFmpegVideoFormat.image2pipe)
                .SetFramerate(this.FPS)
                ;
            if (seekEnd != null)
            {
                outputOptionArgs
                    .SetSeekEnd(seekEnd.Value);
            }
            if (size != null)
            {
                outputOptionArgs
                   .SetVideoSize(size.Value);
            }
            this.ffmpegProcess = FFmpegService.StartFFmpegStandardOutput(fFmpegArgsBuilder.Args);
            using (MemoryStream memoryStream = new MemoryStream())
            {
                int frameIndex = (int)(startSeek.TotalMilliseconds / (1000.0 / this.FPS));
                byte[] buffer = new byte[32768]; //ffmpeg的缓冲区大小被限定在32k 32768 似乎没有办法修改？可以修改的话 下面就不需要进行read != buffer.Length处理了
                int read;
                var data = System.Text.Encoding.Default.GetBytes(this.filePath);
                while ((read = this.ffmpegProcess.StandardOutput.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    if (cancellationToken?.IsCancellationRequested ?? false)
                    {
                        this.Dispose();
                        yield break;
                    }
                    memoryStream.Write(buffer, 0, read);
                    if (read != buffer.Length)
                    {
                        yield return new VideoFrameArgs(frameIndex++, memoryStream);
                        memoryStream.Position = 0;
                        memoryStream.Flush();
                    }
                }
            }
        }
    }
    internal class FFmpegVideoWriter : IVideoFileWriter
    {
        private PipeServerWrite audioPipeWrite;
        private PipeServerWrite videoPipeWrite;
        private Process ffmpegProcess;
        private string videoPipeName = $"videoW-{Guid.NewGuid()}";
        private string audioPipeName = $"audioW-{Guid.NewGuid()}";
        public VideoWriterArgs VideoWriterArgs { get; } = new VideoWriterArgs();
        public AudioWriterArgs AudioWriterArgs { get; } = new AudioWriterArgs();
        public FFmpegVideoWriter()
        {
            if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
        }
        public bool Open(string filePath)
        {
            try
            {
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputPipe(videoPipeName)
                    .SetFramerate(this.VideoWriterArgs.FrameRate)
                    .SetVideoFormat(FFmpegVideoFormat.rawvideo)
                    .SetPixFormat(FFmpegPixFormat.rgb32)
                    .SetVideoSize(this.VideoWriterArgs.Width, this.VideoWriterArgs.Height);
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputFile(filePath)
                    .SetFramerate(this.VideoWriterArgs.FrameRate);
                ((VideoCodecBase)FFmpegProvider.SelectVideoCodec).Apply(this.VideoWriterArgs, outputOptionArgs);
                var videoBufferSize = this.VideoWriterArgs.Width * this.VideoWriterArgs.Height * 4;
                this.videoPipeWrite = new PipeServerWrite(videoPipeName, videoBufferSize);
                if (this.Audioable)
                {
                    fFmpegArgsBuilder.SetInputPipe(audioPipeName)
                        .SetAudioFormat(FFmpegAudioFormat.s16le)
                        .SetAudioCodec(FFmpegAudioCodec.pcm_s16le)
                        .SetAudioFrequency(this.AudioWriterArgs.AudioFrequency)
                        .SetAudioChannels(this.AudioWriterArgs.AudioChannels);
                    ((VideoCodecBase)FFmpegProvider.SelectVideoCodec).AudioCodec.Apply(this.AudioWriterArgs, outputOptionArgs);
                    var audioBufferSize = (int)((1000.0 / this.VideoWriterArgs.FrameRate) * (this.AudioWriterArgs.AudioFrequency / 100.0) * this.AudioWriterArgs.AudioChannels * 2 * 2);
                    this.audioPipeWrite = new PipeServerWrite(audioPipeName, audioBufferSize);
                }
                this.ffmpegProcess = FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public void Dispose()
        {
            this.FlushAudio();
            this.FlushAudio();
            this.audioPipeWrite?.Dispose();
            this.videoPipeWrite?.Dispose();
            try
            {
                this.ffmpegProcess.Kill();
            }
            catch { }
        }

        public bool Audioable { get; set; } = true;

        public void FlushAudio()
        {
            this.audioPipeWrite?.Flush();
        }

        public void FlushVideo()
        {
            this.videoPipeWrite?.Flush();
        }

        public void WriteAudio(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.audioPipeWrite.IsConnected)
            {
                if (!this.audioPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                this.audioPipeWrite.Write(buffer);
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public async Task WriteAudioAsync(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.audioPipeWrite.IsConnected)
            {
                if (!this.audioPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                await this.audioPipeWrite?.WriteAsync(buffer);
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public void WriteVideo(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.videoPipeWrite.IsConnected)
            {
                if (!this.videoPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                this.videoPipeWrite?.Write(buffer);
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public async Task WriteVideoAsync(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.videoPipeWrite.IsConnected)
            {
                if (!this.videoPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                await this.videoPipeWrite?.WriteAsync(buffer);
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }
    }
    /// <summary>
    /// ffmpeg的pipe读取只要获取process.StandardOutput.BaseStream的流就可以了 所以这个先没有用到
    /// </summary>
    internal class PipeServerRead : IDisposable
    {
        private readonly NamedPipeServerStream namedPipeServerStream;

        public bool IsConnected => this.namedPipeServerStream?.IsConnected ?? false;
        public PipeServerRead(string pipeName, int bufferSize)
        {
            this.namedPipeServerStream = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, bufferSize, 0);
        }

        public void Dispose()
        {
            this.namedPipeServerStream.Dispose();
        }

        public void Flush()
        {
            this.namedPipeServerStream.Flush();
        }
        public int Read(byte[] buffer)
        {
            return this.namedPipeServerStream.Read(buffer, 0, buffer.Length);
        }
        public Task<int> ReadAsync(byte[] buffer)
        {
            return this.namedPipeServerStream.ReadAsync(buffer, 0, buffer.Length);
        }

        public bool WaitForConnection(int timeout = 5000)
        {
            var asyncResult = this.namedPipeServerStream.BeginWaitForConnection(iar => { }, null);
            if (asyncResult.AsyncWaitHandle.WaitOne(timeout))
            {
                this.namedPipeServerStream.EndWaitForConnection(asyncResult);
                return this.namedPipeServerStream.IsConnected;
            }
            return false;
        }
    }
    internal class PipeServerWrite : IDisposable
    {
        private readonly NamedPipeServerStream namedPipeServerStream;

        public bool IsConnected => this.namedPipeServerStream?.IsConnected ?? false;
        public PipeServerWrite(string pipeName, int bufferSize)
        {
            this.namedPipeServerStream = new NamedPipeServerStream(pipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 0, bufferSize);
        }

        public void Dispose()
        {
            this.namedPipeServerStream.Dispose();
        }

        public void Flush()
        {
            this.namedPipeServerStream.Flush();
        }
        public void Write(byte[] buffer)
        {
            this.namedPipeServerStream.Write(buffer, 0, buffer.Length);
        }
        public Task WriteAsync(byte[] buffer)
        {
            return this.namedPipeServerStream.WriteAsync(buffer, 0, buffer.Length);
        }

        public bool WaitForConnection(int timeout = 5000)
        {
            var asyncResult = this.namedPipeServerStream.BeginWaitForConnection(iar => { }, null);
            if (asyncResult.AsyncWaitHandle.WaitOne(timeout))
            {
                this.namedPipeServerStream.EndWaitForConnection(asyncResult);
                return this.namedPipeServerStream.IsConnected;
            }
            return false;
        }
    }
}
