using Common.Medias.Args;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Interfaces
{
    public interface IAudioWriterItem : IDisplayItem
    {
        IAudioFileWriter GetAudioFileWriter(AudioWriterArgs audioWriterArgs);
    }
}
