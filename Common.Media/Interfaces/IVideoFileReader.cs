using Common.Media.Args;
using Common.Media.Handlers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Medias.Interfaces
{
    public interface IVideoFileReader : IDisposable
    {
        bool Open(string filePath);
        int FrameCount { get; }
        double FPS { get; set; }
        int Width { get; }
        int Height { get; }
        TimeSpan Duration { get; }
        Stream ReadVideoFrame(TimeSpan seek, Size? size);
        IEnumerable<VideoFrameArgs> ReadVideoFrames(TimeSpan? seek = null, TimeSpan? seekEnd = null, Size? size = null, bool readByNativeFrame = true, CancellationToken? cancellationToken = null);
    }
}
