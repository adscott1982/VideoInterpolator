using System.IO;
using System.Threading.Tasks;
using Xabe.FFmpeg;
using Xabe.FFmpeg.Streams;

namespace VideoTools
{
    public static class FileManagement
    {
        public static async Task<Video> LoadVideoFileAsync(string path)
        {
            return new Video(await MediaInfo.Get(path));
        }
    }
}
