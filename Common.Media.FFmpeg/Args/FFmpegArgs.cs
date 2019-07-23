using System.Collections.Generic;

namespace Common.Media.FFmpeg.Args
{
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
        /// <summary>
        /// -stdin (global)
        /// Enable interaction on standard input. On by default unless standard input is used as an input. To explicitly disable interaction you need to specify -nostdin.Disabling interaction on standard input is useful, for example, if ffmpeg is in the background process group.Roughly the same result can be achieved with ffmpeg ... < /dev/null but it requires a shell.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner stdin() { return AddArg("-stdin"); }
        /// <summary>
        /// -nostdin (global)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        /// <returns></returns>
        protected TOwner nostdin() { return AddArg("-nostdin"); }
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
}
