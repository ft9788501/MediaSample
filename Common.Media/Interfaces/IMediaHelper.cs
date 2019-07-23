using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Medias.Interfaces
{
    public interface IMediaHelper
    {
        bool MediaCut(string input, string output, TimeSpan start, TimeSpan? end = null);
        bool MediaConvertAuto(string input, string output);
        bool MediaConvertPCM_S16E(string input, string output, int sampleRate);
    }
}
