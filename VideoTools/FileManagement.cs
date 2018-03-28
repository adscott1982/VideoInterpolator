using System.Threading.Tasks;

namespace VideoTools
{
    public static class FileManagement
    {
        public static async Task<Video> LoadVideoFileAsync(string path)
        {
            var video = await Task.Run(() => new Video(path));
            return video;
        }
    }
}
