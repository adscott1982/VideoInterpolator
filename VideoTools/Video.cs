using System;
using System.Threading.Tasks;

namespace VideoTools
{
    public class Video : IDisposable
    {
        public Video(string path)
        {
            this.Details = path;
            Task.Delay(2000).Wait();
        }

        public string Details { get; }

        public void Dispose()
        {
        }
    }
}