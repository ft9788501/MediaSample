using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Exceptions;
using Common.Media.FFmpeg.Formats;
using Common.Medias.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Common.Media.FFmpeg
{
    internal class FFmpegMediaHelper : IMediaHelper
    {
        public bool MediaConvertAuto(string input, string output)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputFile(input);
                fFmpegArgsBuilder.SetOutputFile(output);
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MediaCut(string input, string output, TimeSpan start, TimeSpan? end = null)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                var inputOptionArgs = fFmpegArgsBuilder.SetInputFile(input)
                    .SetSeek(start);
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputFile(input)
                    ;
                if (end != null)
                {
                    outputOptionArgs
                       .SetSeekEnd(end.Value)
                       .SetAudioCodec(Codecs.FFmpegAudioCodec.copy)
                       .SetVideoCodec(Codecs.FFmpegVideoCodec.copy);
                }
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool MediaConvertPCM_S16E(string input, string output, int sampleRate)
        {
            try
            {
                if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputFile(input);
                fFmpegArgsBuilder.SetOutputFile(output)
                    //.SetAudioFormat(AudioFormat.s16le)
                    .SetAudioCodec(FFmpegAudioCodec.pcm_s16le)
                    .SetAudioFrequency(sampleRate)
                    .SetAudioChannels(2)
                    ;
                FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
