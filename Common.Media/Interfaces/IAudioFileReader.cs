using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Medias.Interfaces
{
    public interface IAudioFileReader : IDisposable
    {
        byte[] ReadAudio(TimeSpan seek);
        Task<byte[]> ReadAudioAsync(TimeSpan seek);
    }
}
