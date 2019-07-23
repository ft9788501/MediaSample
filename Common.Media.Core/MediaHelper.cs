using Common.Media.FFmpeg;
using Common.Medias.Interfaces;
using System;

namespace Common.Media.Core
{
    public static class MediaHelper
    {
        private static IMediaHelper mediaHelper = FFmpegProvider.GetMediaHelper();
        public static bool CutMedia(string input, string output, TimeSpan start, TimeSpan? end = null)
        {
            return mediaHelper.MediaCut(input, output, start, end);
        }
        public static bool MediaConvertAuto(string input, string output)
        {
            return mediaHelper.MediaConvertAuto(input, output);
        }
        public static bool MediaConvertPCM_S16E(string input, string output, int sampleRate = 16000)
        {
            return mediaHelper.MediaConvertPCM_S16E(input, output, sampleRate);
        }
    }
}
