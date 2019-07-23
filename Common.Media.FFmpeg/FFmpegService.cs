using Common.Media.FFmpeg.Args;
using Common.Medias.Args;
using Common.Medias.Interfaces;
using System;
using System.Diagnostics;
using System.IO;
using System.IO.Pipes;

namespace Common.Media.FFmpeg
{
    public static class FFmpegService
    {
        private static string folderPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ffmpeg");
        private const string FFMPEGEXE = "ffmpeg.exe";
        internal static string FFmpegPath
        {
            get
            {
                var fFmpegPath = Path.Combine(folderPath, FFMPEGEXE);
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }
                return fFmpegPath;
            }
        }
        public static bool FFmpegExists
        {
            get
            {
                // FFmpeg folder
                if (!string.IsNullOrWhiteSpace(folderPath))
                {
                    if (File.Exists(FFmpegPath))
                    {
                        return true;
                    }
                }
                return false;
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
}
