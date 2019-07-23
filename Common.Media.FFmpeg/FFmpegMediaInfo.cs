using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.Exceptions;
using Common.Medias.Interfaces;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Common.Media.FFmpeg
{
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
}
