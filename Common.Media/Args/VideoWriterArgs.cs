using Common.Medias.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Args
{
    public class VideoWriterArgs
    {
        public virtual IDisplayItem VideoCodec { get; set; }
        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual float ScaleWidth { get; set; } = 1;
        public virtual float ScaleHeight { get; set; } = 1;
        public virtual int FrameRate { get; set; } = 19;
        public virtual int VideoQuality { get; set; } = 55;
        //public virtual int VideoBitrate { get; private set; } = 256;
    }
}
