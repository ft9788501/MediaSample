using Common.Medias.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Args
{
    public class AudioWriterArgs
    {
        public virtual IDisplayItem AudioCodec { get; set; }
        public virtual int AudioQuality { get; set; } = 50;
        public virtual int AudioFrequency { get; set; } = 44100;
        public virtual int AudioChannels { get; set; } = 2;
        //public int AudioBitrate { get; private set; } = 128;
    }
}
