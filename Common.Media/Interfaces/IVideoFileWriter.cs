using Common.Medias.Args;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Medias.Interfaces
{
    public interface IVideoFileWriter : IAudioFileWriter
    {
        CommonWriterArgs CommonWriterArgs { get; }
        VideoWriterArgs VideoWriterArgs { get; }
        void WriteVideo(byte[] buffer);
        Task WriteVideoAsync(byte[] buffer);
        void FlushVideo();
    }
}
