using System;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoTools
{
    public class Video : IDisposable
    {
        public Video(IMediaInfo mediaInfo)
        {
            this.MediaInfo = mediaInfo;
            this.Details = $"Length: {mediaInfo.Duration:g}";
        }

        public IMediaInfo MediaInfo { get; }

        public string Details { get; }

        public void Dispose()
        {
        }
    }
}