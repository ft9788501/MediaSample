using System;

namespace Common.Media.FFmpeg.Exceptions
{
    public class FFmpegException : Exception
    {
        public FFmpegException(int exitCode, Exception innerException = null)
            : base($"FFmpeg发生错误,错误代码: {exitCode}.\r\n查看FFmpeg日志获取更多信息", innerException) { }
    }
}
