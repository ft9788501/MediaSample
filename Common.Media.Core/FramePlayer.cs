using NAudio.Wave;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class FramePlayer
    {
        private WaveOut waveOut = new WaveOut();
        private ISampleProvider sampleProvider = null;

        public FramePlayer()
        {
            var bufferedProvider = new BufferedWaveProvider(sampleProvider.WaveFormat);
        }
        public void Load(ISampleProvider sampleProvider)
        {

        }
    }
}
