using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Media.FFmpeg.Formats
{
    //I.... = Supported Input format for conversion
    //.O... = Supported Output format for conversion
    //..H.. = Hardware accelerated format
    //...P. = Paletted format
    //....B = Bitstream format
    public class FFmpegPixFormat
    {
        ///  <summary>  
        /// IO...
        /// </summary>      
        public static FFmpegPixFormat yuv420p = "yuv420p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuyv422 = "yuyv422";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb24 = "rgb24";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb32 = "rgb32";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr24 = "bgr24";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p = "yuv422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p = "yuv444p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv410p = "yuv410p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv411p = "yuv411p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray = "gray";
        /// <summary>
        /// IO..B. 
        /// </summary>
        public static FFmpegPixFormat monow = "monow";
        /// <summary>
        /// IO..B. 
        /// </summary>
        public static FFmpegPixFormat monob = "monob";
        /// <summary>
        /// I..P.
        /// </summary>
        public static FFmpegPixFormat pal8 = "pal8";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj420p = "yuvj420p";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj422p = "yuvj422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuvj444p = "yuvj444p";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat xvmcmc = "xvmcmc";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat xvmcidct = "xvmcidct";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat uyvy422 = "uyvy422";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat uyyvyy411 = "uyyvyy411";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr8 = "bgr8";
        /// <summary>
        /// .O..B.
        /// </summary>
        public static FFmpegPixFormat bgr4 = "bgr4";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr4_byte = "bgr4_byte";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb8 = "rgb8";
        /// <summary>
        /// .O..B.
        /// </summary>
        public static FFmpegPixFormat rgb4 = "rgb4";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb4_byte = "rgb4_byte";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat nv12 = "nv12";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat nv21 = "nv21";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat argb = "argb";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgba = "rgba";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat abgr = "abgr";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgra = "bgra";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray16be = "gray16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gray16le = "gray16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p = "yuv440p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuvj440p = "yuvj440p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p = "yuva420p";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau_h264 = "vdpau_h264";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg1 = "vdpau_mpeg1";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg2 = "vdpau_mpeg2";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_wmv3 = "vdpau_wmv3";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vdpau_vc1 = "vdpau_vc1";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb48be = "rgb48be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb48le = "rgb48le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb565be = "rgb565be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb565le = "rgb565le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb555be = "rgb555be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb555le = "rgb555le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr565be = "bgr565be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr565le = "bgr565le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr555be = "bgr555be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr555le = "bgr555le";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_moco = "vaapi_moco";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_idct = "vaapi_idct";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vaapi_vld = "vaapi_vld";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p16le = "yuv420p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p16be = "yuv420p16be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p16le = "yuv422p16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p16be = "yuv422p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p16le = "yuv444p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p16be = "yuv444p16be";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau_mpeg4 = "vdpau_mpeg4";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat dxva2_vld = "dxva2_vld";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb444le = "rgb444le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat rgb444be = "rgb444be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgr444le = "bgr444le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr444be = "bgr444be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat ya8 = "ya8";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr48be = "bgr48be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr48le = "bgr48le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p9be = "yuv420p9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p9le = "yuv420p9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p10be = "yuv420p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p10le = "yuv420p10le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p10be = "yuv422p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p10le = "yuv422p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p9be = "yuv444p9be";
        /// <summary>
        ///  IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p9le = "yuv444p9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p10be = "yuv444p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p10le = "yuv444p10le";
        /// <summary>
        /// IO...         
        /// </summary>
        public static FFmpegPixFormat yuv422p9be = "yuv422p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p9le = "yuv422p9le";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat vda_vld = "vda_vld";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp = "gbrp";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp9be = "gbrp9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp9le = "gbrp9le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp10be = "gbrp10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp10le = "gbrp10le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrp16be = "gbrp16be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrp16le = "gbrp16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p = "yuva422p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p = "yuva444p";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p9be = "yuva420p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p9le = "yuva420p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p9be = "yuva422p9be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p9le = "yuva422p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p9be = "yuva444p9be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva444p9le = "yuva444p9le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p10be = "yuva420p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p10le = "yuva420p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p10be = "yuva422p10be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p10le = "yuva422p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p10be = "yuva444p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p10le = "yuva444p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva420p16be = "yuva420p16be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva420p16le = "yuva420p16le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuva422p16be = "yuva422p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva422p16le = "yuva422p16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p16be = "yuva444p16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuva444p16le = "yuva444p16le";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vdpau = "vdpau";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat xyz12le = "xyz12le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat xyz12be = "xyz12be";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv16 = "nv16";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv20le = "nv20le";
        /// <summary>
        /// .....
        /// </summary>
        public static FFmpegPixFormat nv20be = "nv20be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgba64be = "rgba64be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgba64le = "rgba64le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgra64be = "bgra64be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat bgra64le = "bgra64le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yvyu422 = "yvyu422";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat vda = "vda";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat ya16be = "ya16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat ya16le = "ya16le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrap = "gbrap";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap16be = "gbrap16be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap16le = "gbrap16le";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat qsv = "qsv";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat mmal = "mmal";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat d3d11va_vld = "d3d11va_vld";
        /// <summary>
        /// ..H..
        /// </summary>
        public static FFmpegPixFormat cuda = "cuda";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat rgb0 = "rgb0";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat bgr0 = "bgr0";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p12be = "yuv420p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv420p12le = "yuv420p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p14be = "yuv420p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv420p14le = "yuv420p14le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p12be = "yuv422p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p12le = "yuv422p12le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv422p14be = "yuv422p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv422p14le = "yuv422p14le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p12be = "yuv444p12be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv444p12le = "yuv444p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p14be = "yuv444p14be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv444p14le = "yuv444p14le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp12be = "gbrp12be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp12le = "gbrp12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat gbrp14be = "gbrp14be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat gbrp14le = "gbrp14le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuvj411p = "yuvj411p";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr8 = "bayer_bggr8";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat bayer_rggb8 = "bayer_rggb8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg8 = "bayer_gbrg8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg8 = "bayer_grbg8";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr16le = "bayer_bggr16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_bggr16be = "bayer_bggr16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_rggb16le = "bayer_rggb16le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat bayer_rggb16be = "bayer_rggb16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg16le = "bayer_gbrg16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_gbrg16be = "bayer_gbrg16be";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg16le = "bayer_grbg16le";
        /// <summary>
        /// I....
        /// </summary>
        public static FFmpegPixFormat bayer_grbg16be = "bayer_grbg16be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p10le = "yuv440p10le";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p10be = "yuv440p10be";
        /// <summary>
        /// IO...
        /// </summary>
        public static FFmpegPixFormat yuv440p12le = "yuv440p12le";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat yuv440p12be = "yuv440p12be";
        /// <summary>
        /// IO... 
        /// </summary>
        public static FFmpegPixFormat ayuv64le = "ayuv64le";
        /// <summary>
        /// ..... 
        /// </summary>
        public static FFmpegPixFormat ayuv64be = "ayuv64be";
        /// <summary>
        /// ..H.. 
        /// </summary>
        public static FFmpegPixFormat videotoolbox_vld = "videotoolbox_vld";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat p010le = "p010le";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat p010be = "p010be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap12be = "gbrap12be";
        /// <summary>
        /// I.... 
        /// </summary>
        public static FFmpegPixFormat gbrap12le = "gbrap12le";
        /// <summary>
        /// I.... 
        /// </summary>
        /// gbrap10be               =
        /// <summary>
        /// I.... 
        /// </summary>           
        public static FFmpegPixFormat gbrap10le = "gbrap10le";
        /// <summary>
        /// ..H..                            
        /// </summary>
        public static FFmpegPixFormat mediacodec = "mediacodec";
        private string format = string.Empty;
        private FFmpegPixFormat(string format)
        {
            this.format = format;
        }
        public static implicit operator string(FFmpegPixFormat format)
        {
            return format.format;
        }
        public static implicit operator FFmpegPixFormat(string format)
        {
            return new FFmpegPixFormat(format);
        }
        public override string ToString()
        {
            return this.format;
        }
    }
}