using System.Collections.Generic;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoTools
{
    public static class FileManagement
    {
        public static async Task<Video> LoadVideoFileAsync(string path)
        {
            return new Video(await MediaInfo.Get(path));
        }

        public static async Task ExtractFramesFromVideo(Video video, string path)
        {
            await Task.Run(() =>
            {
            });
        }
    }
}
