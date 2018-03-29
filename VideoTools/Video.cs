using System;
using System.Collections.Generic;
using System.Linq;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Streams;

namespace VideoTools
{
    public class Video : IDisposable
    {
        private readonly IMediaInfo _mediaInfo;
        private IVideoStream _videoStream;
        private List<IAudioStream> _audioStreams;

        public Video(IMediaInfo mediaInfo)
        {
            this._mediaInfo = mediaInfo;
            this._videoStream = mediaInfo.VideoStreams.First();
            this._audioStreams = mediaInfo.AudioStreams.ToList();
        }

        public TimeSpan Duration => this._mediaInfo.Duration;

        public IVideoStream VideoStream => this._videoStream;

        public void Dispose()
        {
        }
    }
}