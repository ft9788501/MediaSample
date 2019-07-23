using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Media.FFmpeg
{
    public static class FFmepgDownload
    {
        private static readonly Uri uri;
        private static readonly string archivePath;
        static FFmepgDownload()
        {
            var bits = Environment.Is64BitOperatingSystem ? 64 : 86;
            uri = new Uri($"http://112.5.193.60:8881/ffmpegx{bits}.zip");
            archivePath = Path.Combine(Path.GetDirectoryName(FFmpegService.FFmpegPath), "ffmpeg.zip");
        }
        public async static Task DownloadArchive(Action<int> progressCallback, CancellationToken cancellationToken)
        {
            using (var webClient = new WebClient())
            {
                cancellationToken.Register(() =>
                {
                    webClient.CancelAsync();
                });
                webClient.DownloadProgressChanged += (s, e) =>
                {
                    progressCallback?.Invoke(e.ProgressPercentage);
                };
                try
                {
                    await webClient.DownloadFileTaskAsync(uri, archivePath);
                }
                catch (Exception ex)
                {
                }
            }
            if (File.Exists(archivePath))
            {
                try
                {
                    using (var archive = ZipFile.OpenRead(archivePath))
                    {
                        archive.Entries.FirstOrDefault(e => e.Name == Path.GetFileName(FFmpegService.FFmpegPath))?.ExtractToFile(FFmpegService.FFmpegPath, true);
                    }
                    File.Delete(archivePath);
                }
                catch
                {
                }
            }
        }
    }
}
