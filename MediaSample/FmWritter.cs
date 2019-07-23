using Common.Media.Core;
using Common.Media.FFmpeg;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MediaSample
{
    public partial class FmWritter : Form
    {
        public FmWritter()
        {
            InitializeComponent();
        }
        protected override void OnShown(EventArgs e)
        {
            base.OnShown(e);
            string path = Path.Combine(Application.StartupPath, Guid.NewGuid().ToString() + ".mp4");
            using (VideoFileWriter videoFileWriter = new VideoFileWriter() { Width = this.ClientSize.Width, Height = this.ClientSize.Height, FPS = 25, VideoCodec = FFmpegProvider.VideoCodecItems.First() })
            {
                videoFileWriter.Open(path);
                int width = this.ClientSize.Width / 10;
                int height = this.ClientSize.Height / 10;
                for (int y = 0; y < height; y++)
                {
                    for (int x = 0; x < width; x++)
                    {
                        using (Bitmap bitmap = new Bitmap(videoFileWriter.Width, videoFileWriter.Height))
                        using (Graphics graphics = Graphics.FromImage(bitmap))
                        {
                            graphics.DrawEllipse(Pens.Yellow, new RectangleF(x, y, 10, 10));
                            videoFileWriter.WriteVideo(bitmap);
                            this.Text = $"写入{y * width + x}/{width * height}";
                        }
                    }
                }
            }
            System.Diagnostics.Process.Start("Explorer.exe", path);
        }
    }
}
