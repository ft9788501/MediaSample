using Common.Media.Core;
using Common.Media.FFmpeg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSample
{
    public partial class FmPlayer : Form
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private VideoFileReader videoFileReader = null;
        public FmPlayer()
        {
            InitializeComponent();
        }
        protected async override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            if (!FFmpegService.FFmpegExists)
            {
                this.Enabled = false;
                await FFmepgDownload.DownloadArchive((i) =>
                {
                    this.Text = $"下载中{i}%";
                }, cancellationTokenSource.Token);
                this.Enabled = true;
            }
            videoFileReader = new VideoFileReader() { FPS = 25 };
            videoFileReader.Open("Videos/girl.mp4");
            await Task.Run(() =>
            {
                foreach (var frame in videoFileReader.ReadVideoFrames(size: this.ClientSize, readByNativeFrame: true, cancellationToken: cancellationTokenSource.Token))
                {
                    using (frame.FrameBitmap)
                    using (Graphics g = this.CreateGraphics())
                    {
                        g.DrawImage(frame.FrameBitmap, 0, 0);
                    }
                }
            });
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            videoFileReader?.Dispose();
        }
    }
}
