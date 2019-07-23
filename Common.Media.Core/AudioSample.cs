using Common.Media.NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class AudioSample : IDisposable
    {
        private AudioFileReader audioFileReader = null;
        private ISampleProvider oriSample = null;
        public ISampleProvider Sample { get; private set; }

        public void Dispose()
        {
            this.audioFileReader?.Dispose();
        }
        public AudioSample(string filePath)
        {
            this.audioFileReader = new AudioFileReader(filePath);
            ISampleProvider sampleProvider = this.audioFileReader.ToSampleProvider();
            // Mono to Stereo
            if (sampleProvider.WaveFormat.Channels == 1)
                sampleProvider = sampleProvider.ToStereo();
            // Resample
            if (sampleProvider.WaveFormat.SampleRate != 16000)
            {
                sampleProvider = new WdlResamplingSampleProvider(sampleProvider, 16000);
            }
            this.oriSample = sampleProvider;
            this.Sample = this.oriSample;
        }
        public AudioSample(IEnumerable<AudioSample> audioSamples)
        {
            if (audioSamples.Count() != 0)
            {
                this.Sample = new MixingSampleProvider(audioSamples.Select(a => a.Sample));
            }
        }
        public AudioSample ResetSample()
        {
            this.Sample = this.oriSample;
            return this;
        }
        /// <summary>
        /// 设置速率原始速率为1（倍数值）
        /// </summary>
        /// <param name="rate"></param>
        /// <returns></returns>
        public AudioSample RateSample(double rate)
        {
            if (rate != 1)
            {
                this.Sample = new VarispeedWaveProvider(this.Sample.ToWaveProvider16())
                {
                    Rate = rate
                }.ToSampleProvider();
            }
            return this;
        }
        /// <summary>
        /// 音频空白延长
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public AudioSample LeadOutTime(TimeSpan timeSpan)
        {
            if (timeSpan.TotalMilliseconds != 0)
            {
                this.Sample = new OffsetSampleProvider(this.Sample)
                {
                    LeadOut = timeSpan
                };
            }
            return this;
        }
        /// <summary>
        /// 偏移音频位置
        /// </summary>
        /// <param name="timeSpan"></param>
        /// <returns></returns>
        public AudioSample OffsetTime(TimeSpan timeSpanSkip, TimeSpan timeSpanTake, TimeSpan timeSpanDelay)
        {
            var aaa = timeSpanTake.TotalMilliseconds;
            if (0 < -timeSpanDelay.TotalMilliseconds && -timeSpanDelay.TotalMilliseconds < timeSpanTake.TotalMilliseconds)
            {
                audioFileReader.CurrentTime = -timeSpanDelay;
                this.Sample = new OffsetSampleProvider(this.Sample)
                {
                    SkipOver = TimeSpan.FromMilliseconds(timeSpanSkip.TotalMilliseconds),
                    Take = TimeSpan.FromMilliseconds(timeSpanTake.TotalMilliseconds + timeSpanDelay.TotalMilliseconds),
                    DelayBy = TimeSpan.FromMilliseconds(timeSpanDelay.TotalMilliseconds < 0 ? 0 : timeSpanDelay.TotalMilliseconds)
                };
            }
            else if (-timeSpanDelay.TotalMilliseconds <= 0)
            {
                audioFileReader.CurrentTime = TimeSpan.FromMilliseconds(0);
                this.Sample = new OffsetSampleProvider(this.Sample)
                {
                    SkipOver = TimeSpan.FromMilliseconds(timeSpanSkip.TotalMilliseconds),
                    Take = TimeSpan.FromMilliseconds(timeSpanTake.TotalMilliseconds),
                    DelayBy = TimeSpan.FromMilliseconds(timeSpanDelay.TotalMilliseconds < 0 ? 0 : timeSpanDelay.TotalMilliseconds)
                };
            }
            else
            {
                this.Sample = null;
            }
            return this;
        }
    }
}