using Common.Medias.Args;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Interfaces
{
    public interface IVideoWriterItem : IDisplayItem
    {
           IVideoFileWriter GetVideoFileWriter(VideoWriterArgs videoWriterArgs);
    }
}
