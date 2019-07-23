using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Common.Media.Args
{
    public class VideoFrameArgs
    {
        public int FrameIndex { get; }
        public byte[] FrameData { get; }

        public VideoFrameArgs(int frameIndex, byte[] frameData)
        {
            FrameIndex = frameIndex;
            FrameData = frameData;
        }
    }
}
