using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Formats
{
    /// <summary>
    //s means "signed" (for the integer representations)= u would mean "unsigned"
    //16 means 16 Bits per sample
    //le means "little endian" coding for the samples
    /// https://trac.ffmpeg.org/wiki/audio%20types
    /// </summary>
    public class FFmpegAudioFormat
    {
        /// <summary>                                                              
        /// PCM A-law                                                              
        /// </summary>                                                             
        public static FFmpegAudioFormat alaw = "alaw";
        /// <summary>                                                           
        /// PCM 32-bit floating-point big-endian                                
        /// </summary>                                                          
        public static FFmpegAudioFormat f32be = "f32be";
        /// <summary>                                                             
        /// PCM 32-bit floating-point little-endian                               
        /// </summary>                                                            
        public static FFmpegAudioFormat f32le = "f32le";
        /// <summary>                                                              
        /// PCM 64-bit floating-point big-endian                                   
        /// </summary>                                                             
        public static FFmpegAudioFormat f64be = "f64be";
        /// <summary>                                                            
        /// PCM 64-bit floating-point little-endian                              
        /// </summary>                                                           
        public static FFmpegAudioFormat f64le = "f64le";
        /// <summary>                                                             
        /// PCM mu-law                                                            
        /// </summary>                                                            
        public static FFmpegAudioFormat mulaw = "mulaw";
        /// <summary>                                                            
        /// PCM signed 16-bit big-endian                                         
        /// </summary>                                                           
        public static FFmpegAudioFormat s16be = "s16be";
        /// <summary>                                                             
        /// PCM signed 16-bit little-endian                                       
        /// </summary>                                                            
        public static FFmpegAudioFormat s16le = "s16le";
        /// <summary>                                                           
        /// PCM signed 24-bit big-endian                                        
        /// </summary>                                                          
        public static FFmpegAudioFormat s24be = "s24be";
        /// <summary>                                                            
        /// PCM signed 24-bit little-endian                                      
        /// </summary>                                                           
        public static FFmpegAudioFormat s24le = "s24le";
        /// <summary>                                                             
        /// PCM signed 32-bit big-endian                                          
        /// </summary>                                                            
        public static FFmpegAudioFormat s32be = "s32be";
        /// <summary>                                                            
        /// PCM signed 32-bit little-endian                                      
        /// </summary>                                                           
        public static FFmpegAudioFormat s32le = "s32le";
        /// <summary>                                                             
        /// PCM signed 8-bit                                                      
        /// </summary>                                                            
        public static FFmpegAudioFormat s8 = "s8";
        /// <summary>                                                            
        /// PCM unsigned 16-bit big-endian                                       
        /// </summary>                                                           
        public static FFmpegAudioFormat u16be = "u16be";
        /// <summary>                                                            
        /// PCM unsigned 16-bit little-endian                                    
        /// </summary>                                                           
        public static FFmpegAudioFormat u16le = "u16le";
        /// <summary>                                                            
        /// PCM unsigned 24-bit big-endian                                       
        /// </summary>                                                           
        public static FFmpegAudioFormat u24be = "u24be";
        /// <summary>                                                             
        /// PCM unsigned 24-bit little-endian                                     
        /// </summary>                                                            
        public static FFmpegAudioFormat u24le = "u24le";
        /// <summary>                                                           
        /// PCM unsigned 32-bit big-endian                                      
        /// </summary>                                                          
        public static FFmpegAudioFormat u32be = "u32be";
        /// <summary>                                                           
        /// PCM unsigned 32-bit little-endian                                   
        /// </summary>                                                          
        public static FFmpegAudioFormat u32le = "u32le";
        /// <summary>                                                             
        /// PCM unsigned 8-bit                                                    
        /// </summary>                                                            
        public static FFmpegAudioFormat u8 = "u8";
        private string format = string.Empty;
        private FFmpegAudioFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegAudioFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegAudioFormat(string format)
        {
            return new FFmpegAudioFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
}
