using NAudio.Wave;

namespace Common.Media.NAudio.WaveRenderer
{
    internal interface IPeakProvider
    {
        void Init(ISampleProvider reader, int samplesPerPixel);
        PeakInfo GetNextPeak();
    }
}