using Common.Media.FFmpeg.Args;
using Common.Media.FFmpeg.AudioCodecs;
using Common.Media.FFmpeg.Codecs;
using Common.Media.FFmpeg.Exceptions;
using Common.Media.FFmpeg.Formats;
using Common.Media.FFmpeg.VideoCodecs;
using Common.Medias.Args;
using Common.Medias.Interfaces;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Common.Media.FFmpeg
{
    internal class FFmpegVideoWriter : IVideoFileWriter
    {
        private PipeServerWrite audioPipeWrite;
        private PipeServerWrite videoPipeWrite;
        private Process ffmpegProcess;
        private string videoPipeName = $"videoW-{Guid.NewGuid()}";
        private string audioPipeName = $"audioW-{Guid.NewGuid()}";
        public CommonWriterArgs CommonWriterArgs { get; } = new CommonWriterArgs();
        public VideoWriterArgs VideoWriterArgs { get; } = new VideoWriterArgs();
        public AudioWriterArgs AudioWriterArgs { get; } = new AudioWriterArgs();
        public FFmpegVideoWriter()
        {
            if (!FFmpegService.FFmpegExists) { throw new FFmpegNotFoundException(); }
        }
        public bool Open(string filePath)
        {
            try
            {
                FFmpegArgsBuilder fFmpegArgsBuilder = new FFmpegArgsBuilder();
                fFmpegArgsBuilder.GlobalOptionArgs
                    .OverwriteOutput()
                    .SetThreadQueueSize(512);
                fFmpegArgsBuilder.SetInputPipe(videoPipeName)
                    .SetFramerate(this.VideoWriterArgs.FrameRate)
                    .SetVideoFormat(FFmpegVideoFormat.rawvideo)
                    .SetPixFormat(FFmpegPixFormat.rgb32)
                    .SetVideoSize(this.VideoWriterArgs.Width, this.VideoWriterArgs.Height)
                    ;
                var outputOptionArgs = fFmpegArgsBuilder.SetOutputFile(filePath)
                    .SetFramerate(this.VideoWriterArgs.FrameRate)
                    .SetFileLength(CommonWriterArgs.FileLength ?? 0, () => CommonWriterArgs.FileLength != null)
                    .SetVideoSize((int)(this.VideoWriterArgs.Width * this.VideoWriterArgs.ScaleWidth), (int)(this.VideoWriterArgs.Height * this.VideoWriterArgs.ScaleHeight))
                    ;
                ((VideoCodecBase)this.VideoWriterArgs.VideoCodec).Apply(this.VideoWriterArgs, outputOptionArgs);
                var videoBufferSize = this.VideoWriterArgs.Width * this.VideoWriterArgs.Height * 4;
                this.videoPipeWrite = new PipeServerWrite(videoPipeName, videoBufferSize);
                if (this.Audioable)
                {
                    fFmpegArgsBuilder.SetInputPipe(audioPipeName)
                        .SetAudioFormat(FFmpegAudioFormat.s16le)
                        .SetAudioCodec(FFmpegAudioCodec.pcm_s16le)
                        .SetAudioFrequency(16000)
                        .SetAudioChannels(2);
                    outputOptionArgs
                        .SetAudioFrequency(this.AudioWriterArgs.AudioFrequency)
                        .SetAudioChannels(this.AudioWriterArgs.AudioChannels)
                        ;
                    ((AudioCodecBase)this.AudioWriterArgs.AudioCodec).Apply(this.AudioWriterArgs, outputOptionArgs);
                    var audioBufferSize = (int)((1000.0 / this.VideoWriterArgs.FrameRate) * (44100 / 100.0) * 2 * 2 * 2);
                    this.audioPipeWrite = new PipeServerWrite(audioPipeName, audioBufferSize);
                }
                this.ffmpegProcess = FFmpegService.StartFFmpeg(fFmpegArgsBuilder.Args);
                return true;
            }
            catch(Exception ex)
            {
                return false;
            }
        }
        public void Dispose()
        {
            try
            {
                this.FlushVideo();
                this.FlushAudio();
                this.audioPipeWrite?.Dispose();
                this.videoPipeWrite?.Dispose();
                this.ffmpegProcess?.WaitForExit(3000);
                this.ffmpegProcess?.Kill();
            }
            catch { }
        }

        public bool Audioable { get; set; } = false;

        public void FlushAudio()
        {
            this.audioPipeWrite?.Flush();
        }

        public void FlushVideo()
        {
            this.videoPipeWrite?.Flush();
        }

        public void WriteAudio(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.audioPipeWrite.IsConnected)
            {
                if (!this.audioPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                this.audioPipeWrite?.Write(buffer);
                this.audioPipeWrite?.Flush();
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public async Task WriteAudioAsync(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.audioPipeWrite.IsConnected)
            {
                if (!this.audioPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                await this.audioPipeWrite?.WriteAsync(buffer);
                this.audioPipeWrite?.Flush();
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public void WriteVideo(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.videoPipeWrite.IsConnected)
            {
                if (!this.videoPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                this.videoPipeWrite?.Write(buffer);
                this.videoPipeWrite?.Flush();
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }

        public async Task WriteVideoAsync(byte[] buffer)
        {
            if (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode);
            }
            if (!this.videoPipeWrite.IsConnected)
            {
                if (!this.videoPipeWrite.WaitForConnection())
                {
                    throw new Exception("Cannot connect Audio pipe to FFmpeg");
                }
            }
            try
            {
                await this.videoPipeWrite?.WriteAsync(buffer);
                this.videoPipeWrite?.Flush();
            }
            catch (Exception e) when (ffmpegProcess.HasExited)
            {
                throw new FFmpegException(ffmpegProcess.ExitCode, e);
            }
        }
    }
}
