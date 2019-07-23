using Common.Medias.Args;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Medias.Interfaces
{
    public interface IAudioFileWriter : IDisposable
    {
        AudioWriterArgs AudioWriterArgs { get; }
        bool Open(string filePath);
        void WriteAudio(byte[] buffer);
        Task WriteAudioAsync(byte[] buffer);
        void FlushAudio();
    }
}
