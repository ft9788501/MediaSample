using Common.Media.NAudio;
using NAudio.Wave;
using NAudio.Wave.SampleProviders;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;

namespace Common.Media.Core
{
    public abstract class Media<T> : IDisposable
        where T : Media<T>
    {
        protected string filePath = string.Empty;
        public abstract TimeSpan Duration { get; }
        public abstract void Dispose();
        protected Media(string filePath)
        {
            this.filePath = filePath;
        }
        /// <summary> 加载音频路径
        /// </summary>
        /// <param name="fileName">音频文件路径</param>
        /// <returns></returns>
        public static T FromFile(string fileName)
        {
            return (T)Activator.CreateInstance(typeof(T), BindingFlags.Instance | BindingFlags.NonPublic, null, new string[] { fileName }, null, null);
        }
    }
}
