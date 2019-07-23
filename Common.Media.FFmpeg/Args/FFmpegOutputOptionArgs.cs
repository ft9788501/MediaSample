using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Formats;
using Common.Media.FFmpeg.Options;
using System;
using System.Drawing;

namespace Common.Media.FFmpeg.Args
{
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
        public FFmpegOutputOptionArgs SetOutputVideoFrame(int frameNum = 1, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return vframes(frameNum);
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// FPS
        /// 设置帧速率（赫兹值、分数或缩写）。作为一个输入选项，忽略存储在文件中的任何时间戳，而是在假设恒定帧速率fps的情况下生成时间戳。这与用于某些输入格式（如image2或v4l2）的-framerate选项不同（在旧版本的ffmpeg中，它以前是相同的）。如果有疑问，请使用-framerate而不是输入选项-r。
        /// </summary>
        /// <param name="framerate"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetFramerate(double framerate, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return r(framerate);
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoSize(Size size, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return s($"{size.Width}x{size.Height}");
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 设置帧大小。作为一个输入选项，这是视频大小专用选项的快捷方式，由一些帧大小不存储在文件中或可配置的分路器识别，例如原始视频或视频抓取器。作为输出选项，这会将缩放视频过滤器插入到相应过滤器图形的末尾。请直接使用磅秤过滤器将其插入开头或其他位置。格式为“wxh”（默认值-与源代码相同）。
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoSize(int width, int height, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return s($"{width}x{height}");
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 设置由纵横比指定的视频显示纵横比。纵横比可以是浮点数字符串，也可以是num:den格式的字符串，其中num和den是纵横比的分子和分母。例如，“4:3”、“16:9”、“1.3333”和“1.7777”是有效的参数值。如果与-vcodec copy一起使用，它将影响存储在容器级别的纵横比，但不会影响存储在编码帧中的纵横比（如果存在）。
        /// </summary>
        /// <param name="videoAspect"></param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoAspect(FFmpegVideoAspect videoAspect, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return aspect($"{videoAspect}");
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 作为输入选项，阻止对文件的所有视频流进行筛选或自动为任何输出选择或映射。请参见-discard选项单独禁用流。作为输出选项，禁用视频录制，即自动选择或映射任何视频流。有关完全手动控制，请参见-map选项。
        /// </summary>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetVideoDisable(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return vn();
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetVideoCodec(FFmpegVideoCodec videoCodec, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return vcodec(videoCodec);
            }
            else
            {
                return this;
            }
        }
        #endregion
        public FFmpegOutputOptionArgs SetAudioFormat(FFmpegAudioFormat format, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return f(format);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetVideoFormat(FFmpegVideoFormat format, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return f(format);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetPixFormat(FFmpegPixFormat format, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return pix_fmt(format);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioCodec(FFmpegAudioCodec audioCodec, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return acodec(audioCodec);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioFrequency(int frequency, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return ar(frequency);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioChannels(int channels, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return ac(channels);
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 限制输出文件大小
        /// </summary>
        /// <param name="size">单位MB</param>
        /// <returns></returns>
        public FFmpegOutputOptionArgs SetFileLength(int size, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return fs($"{size}MB");
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioSampleFormat(Formats.FFmpegSampleFormat sampleFormat, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return sample_fmt(sampleFormat);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetSeek(TimeSpan seek, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return ss(seek);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetSeekEnd(TimeSpan seek, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return to(seek);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetDuration(TimeSpan seek, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return t(seek);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetOutputAudioFrame(int frameNum = 1, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return aframes(frameNum);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetOutputAllFrame(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return AddArg("update", 1);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetVideoBitrate(int bitrate, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return AddArg("b:v", bitrate);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetVideoBitrate(string bitrate, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return AddArg("b:v", bitrate);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioBitrate(int bitrate, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return AddArg("b:a", bitrate);
            }
            else
            {
                return this;
            }
        }
        public FFmpegOutputOptionArgs SetAudioBitrate(string bitrate, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return AddArg("b:a", bitrate);
            }
            else
            {
                return this;
            }
        }
    }
}
