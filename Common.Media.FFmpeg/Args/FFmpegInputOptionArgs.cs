using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Formats;
using System;
using System.Drawing;

namespace Common.Media.FFmpeg.Args
{
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
        public FFmpegInputOptionArgs SetFramerate(double framerate, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetVideoSize(Size size, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetVideoSize(int width, int height, Func<bool> condition = null)
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
        /// 作为输入选项，阻止对文件的所有视频流进行筛选或自动为任何输出选择或映射。请参见-discard选项单独禁用流。作为输出选项，禁用视频录制，即自动选择或映射任何视频流。有关完全手动控制，请参见-map选项。
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SetVideoDisable(Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetAudioFormat(FFmpegAudioFormat format, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetVideoFormat(FFmpegVideoFormat format, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetPixFormat(FFmpegPixFormat format, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetAudioCodec(FFmpegAudioCodec audioCodec, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetAudioFrequency(int frequency, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetAudioChannels(int channels, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetSeek(TimeSpan seek, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs SetSeekEnd(TimeSpan seek, Func<bool> condition = null)
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
        /// <summary>
        /// 只seek在关键帧上
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SeekKeyframe(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return noaccurate_seek();
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// seek在精确的时间点上
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs SeekAccurate(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return accurate_seek();
            }
            else
            {
                return this;
            }
        }
        public FFmpegInputOptionArgs SetDuration(TimeSpan seek, Func<bool> condition = null)
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
        public FFmpegInputOptionArgs DisableAudio(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return an();
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 以视频的帧速率读取数据
        /// </summary>
        /// <returns></returns>
        public FFmpegInputOptionArgs ReadByNativeFrame(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return re();
            }
            else
            {
                return this;
            }
        }
        #endregion
    }
}
