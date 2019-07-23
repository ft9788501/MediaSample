using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace Common.Media.FFmpeg
{
    /// <summary>
    /// ffmpeg的pipe读取只要获取process.StandardOutput.BaseStream的流就可以了 所以这个先没有用到
    /// </summary>
    internal class PipeServerRead : IDisposable
    {
        private readonly NamedPipeServerStream namedPipeServerStream;

        public bool IsConnected => this.namedPipeServerStream?.IsConnected ?? false;
        public PipeServerRead(string pipeName, int bufferSize)
        {
            this.namedPipeServerStream = new NamedPipeServerStream(pipeName, PipeDirection.In, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, bufferSize, 0);
        }

        public void Dispose()
        {
            this.namedPipeServerStream.Dispose();
        }

        public void Flush()
        {
            this.namedPipeServerStream.Flush();
        }
        public int Read(byte[] buffer)
        {
            return this.namedPipeServerStream.Read(buffer, 0, buffer.Length);
        }
        public Task<int> ReadAsync(byte[] buffer)
        {
            return this.namedPipeServerStream.ReadAsync(buffer, 0, buffer.Length);
        }

        public bool WaitForConnection(int timeout = 5000)
        {
            var asyncResult = this.namedPipeServerStream.BeginWaitForConnection(iar => { }, null);
            if (asyncResult.AsyncWaitHandle.WaitOne(timeout))
            {
                this.namedPipeServerStream.EndWaitForConnection(asyncResult);
                return this.namedPipeServerStream.IsConnected;
            }
            return false;
        }
    }
}
