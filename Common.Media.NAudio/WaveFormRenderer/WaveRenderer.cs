using System;
using System.Drawing;
using NAudio.Wave;

namespace Common.Media.NAudio.WaveRenderer
{
    public static class WaveRenderer
    {
        public static Image Render(string selectedFile, int height)
        {
            var soundCloudDarkBlocks = new SoundCloudBlockWaveRendererSettings(Color.Black, Color.FromArgb(55, 55, 55), Color.Black, Color.FromArgb(204, 204, 204))
            {
                TopHeight = height / 2,
                BottomHeight = height / 2,
                Name = "SoundCloud Darker Blocks"
            };

            return Render(selectedFile, new MaxPeakProvider(), new WaveRendererSettings()
            {
                TopHeight = height / 2,
                BottomHeight = height / 2,
                TopPeakPen = Pens.Black,
                BottomPeakPen = Pens.Black
            });
        }
        public static Image[] Render(string selectedFile, int height, int maxWidth)
        {
            using (Image image = Render(selectedFile, height))
            {
                int totalWidth = image.Width;
                int count = totalWidth / maxWidth + (totalWidth % maxWidth == 0 ? 0 : 1);
                Image[] images = new Image[count];
                for (int c = 0; c < count; c++)
                {
                    int width = Math.Min(maxWidth, totalWidth);
                    images[c] = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(images[c]))
                    {
                        g.DrawImage(image, new Rectangle(0, 0, width, image.Height), new Rectangle(image.Width - totalWidth, 0, width, image.Height), GraphicsUnit.Pixel);
                        totalWidth -= width;
                    }
                }
                return images;
            }
        }

        private static Image Render(string selectedFile, IPeakProvider peakProvider, WaveRendererSettings settings)
        {
            using (var reader = new AudioFileReader(selectedFile))
            {
                settings.Width = settings.Width ?? (int)reader.TotalTime.TotalMilliseconds / 2;
                int bytesPerSample = (reader.WaveFormat.BitsPerSample / 8);
                var samples = reader.Length / (bytesPerSample);
                var samplesPerPixel = (int)(samples / settings.Width);
                var stepSize = settings.PixelsPerPeak + settings.SpacerPixels;
                peakProvider.Init(reader, samplesPerPixel * stepSize);
                return Render(peakProvider, settings);
            }
        }

        private static Image Render(IPeakProvider peakProvider, WaveRendererSettings settings)
        {
            if (settings.DecibelScale)
                peakProvider = new DecibelPeakProvider(peakProvider, 48);

            var b = new Bitmap(settings.Width.Value, settings.TopHeight + settings.BottomHeight);
            if (settings.BackgroundColor == Color.Transparent)
            {
                b.MakeTransparent();
            }
            using (var g = Graphics.FromImage(b))
            {
                g.FillRectangle(settings.BackgroundBrush, 0, 0, b.Width, b.Height);
                var midPoint = settings.TopHeight;

                int x = 0;
                var currentPeak = peakProvider.GetNextPeak();
                while (x < settings.Width)
                {
                    var nextPeak = peakProvider.GetNextPeak();

                    for (int n = 0; n < settings.PixelsPerPeak; n++)
                    {
                        var lineHeight = settings.TopHeight * currentPeak.Max;
                        g.DrawLine(settings.TopPeakPen, x, midPoint, x, midPoint - lineHeight);
                        lineHeight = settings.BottomHeight * currentPeak.Min;
                        g.DrawLine(settings.BottomPeakPen, x, midPoint, x, midPoint - lineHeight);
                        x++;
                    }

                    for (int n = 0; n < settings.SpacerPixels; n++)
                    {
                        // spacer bars are always the lower of the 
                        var max = Math.Min(currentPeak.Max, nextPeak.Max);
                        var min = Math.Max(currentPeak.Min, nextPeak.Min);

                        var lineHeight = settings.TopHeight * max;
                        g.DrawLine(settings.TopSpacerPen, x, midPoint, x, midPoint - lineHeight);
                        lineHeight = settings.BottomHeight * min;
                        g.DrawLine(settings.BottomSpacerPen, x, midPoint, x, midPoint - lineHeight);
                        x++;
                    }
                    currentPeak = nextPeak;
                }
            }
            return b;
        }

    }
}
