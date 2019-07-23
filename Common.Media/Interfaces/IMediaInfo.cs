using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Interfaces
{
    public interface IMediaInfo
    {
        int Width { get; }
        int Height { get; }
        string AudioFormat { get; }
        string VideoFormat { get; }
        string PixFormat { get; }
        TimeSpan Duration { get; }
        /// <summary>
        /// FPS
        /// </summary>
        double Framerate { get; }
        string VideoBitrate { get; }
        string AudioBitrate { get; }
        int AudioFrequency { get; }
        string Bitrate { get; }
        void Open(string filePath);
    }
}
