using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Formats;
using System;
using System.Drawing;

namespace Common.Media.FFmpeg.Args
{
    public class FFmpegGlobalOptionArgs : FFmpegArgs<FFmpegGlobalOptionArgs>
    {
        public FFmpegGlobalOptionArgs()
        {
        }
        public FFmpegGlobalOptionArgs SetThreadQueueSize(int threadQueueSize, Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return thread_queue_size(threadQueueSize);
            }
            else
            {
                return this;
            }
        }
        public FFmpegGlobalOptionArgs SetStandardInput(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return stdin();
            }
            else
            {
                return this;
            }
        }
        public FFmpegGlobalOptionArgs SetNoStandardInput(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return nostdin();
            }
            else
            {
                return this;
            }
        }
        /// <summary>
        /// 输出文件存在的时候，是否覆盖输出？
        /// </summary>
        /// <param name="threadQueueSize"></param>
        /// <returns></returns>
        public FFmpegGlobalOptionArgs OverwriteOutput(Func<bool> condition = null)
        {
            if (condition?.Invoke() ?? true)
            {
                return y();
            }
            else
            {
                return this;
            }
        }
    }
}
