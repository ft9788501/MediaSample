using NAudio.Wave;

namespace Common.Media.NAudio.WaveRenderer
{
    internal abstract class PeakProvider : IPeakProvider
    {
        protected ISampleProvider Provider { get; private set; }
        protected int SamplesPerPeak { get; private set; }
        protected float[] ReadBuffer { get; private set; }

        public void Init(ISampleProvider provider, int samplesPerPeak)
        {
            Provider = provider;
            SamplesPerPeak = samplesPerPeak;
            ReadBuffer = new float[samplesPerPeak];
        }

        public abstract PeakInfo GetNextPeak();
    }
}