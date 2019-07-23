using Common.Media.FFmpeg;

namespace Common.Media.FFmpeg.VideoCodecs
{
    // ReSharper disable once InconsistentNaming
    internal abstract class FFmpegPostProcessingCodec : VideoCodecBase
    {
        protected abstract string PostProcessingName { get; }
        protected abstract string PostProcessingDescription { get; }

        public override string Name { get; } 

        public override string Description { get; } 

        protected FFmpegPostProcessingCodec()
        {
            this.Name = $"{this.PostProcessingName}";
            //this.Description = $"{Description}\nEncoding is done after recording has been finished";
        }
    }
}