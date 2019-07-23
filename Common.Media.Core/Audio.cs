using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public class Audio : Media<Audio>
    {
        private AudioFileReader audioFileReader = null;

        public override TimeSpan Duration => this.audioFileReader.TotalTime;

        public override void Dispose()
        {
            this.audioFileReader.Dispose();
        }

        private Audio(string filePath) : base(filePath)
        {
            this.audioFileReader = new AudioFileReader(filePath);
        }
        public AudioSample GengrateSample()
        {
            return new AudioSample(this.filePath);
        }
    }
}
