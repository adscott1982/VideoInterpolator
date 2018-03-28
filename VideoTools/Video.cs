using System.Threading.Tasks;

namespace VideoTools
{
    public class Video
    {
        public Video(string path)
        {
            this.Details = path;
            Task.Delay(2000).Wait();
        }

        public string Details { get; }
    }
}