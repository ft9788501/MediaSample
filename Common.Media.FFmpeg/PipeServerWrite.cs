using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Text;
using System.Threading.Tasks;

namespace Common.Media.FFmpeg
{
    internal class PipeServerWrite : IDisposable
    {
        private readonly NamedPipeServerStream namedPipeServerStream;

        public bool IsConnected => this.namedPipeServerStream?.IsConnected ?? false;
        public PipeServerWrite(string pipeName, int bufferSize)
        {
            this.namedPipeServerStream = new NamedPipeServerStream(pipeName, PipeDirection.Out, 1, PipeTransmissionMode.Byte, PipeOptions.Asynchronous, 0, bufferSize);
        }

        public void Dispose()
        {
            this.namedPipeServerStream.Dispose();
        }

        public void Flush()
        {
            this.namedPipeServerStream.Flush();
        }
        public void Write(byte[] buffer)
        {
            this.namedPipeServerStream.Write(buffer, 0, buffer.Length);
        }
        public Task WriteAsync(byte[] buffer)
        {
            return this.namedPipeServerStream.WriteAsync(buffer, 0, buffer.Length);
        }

        public bool WaitForConnection(int timeout = 10000)
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
