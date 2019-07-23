namespace Common.Media.NAudio.WaveRenderer
{
    internal class PeakInfo
    {
        public PeakInfo(float min, float max)
        {
            Max = max;
            Min = min;
        }

        public float Min { get; private set; }
        public float Max { get; private set; }
    }
}