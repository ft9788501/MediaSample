using System.Drawing;

namespace Common.Media.Core.Args
{
    public class VideoFrameImageArgs
    {
        public int FrameIndex { get; }
        public Bitmap FrameBitmap { get; }

        public VideoFrameImageArgs(int frameIndex, Bitmap frameBitmap)
        {
            FrameIndex = frameIndex;
            FrameBitmap = frameBitmap;
        }
    }
}
