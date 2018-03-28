using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;

namespace VideoTools
{
    public static class FileManagement
    {
        public static async Task<Video> LoadVideoFileAsync(string path)
        {
            var mediaInfo = await MediaInfo.Get(path);
            var video = await Task.Run(() => new Video(path));
            return video;
        }
    }
}
