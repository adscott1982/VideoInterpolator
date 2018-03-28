using Microsoft.Win32;

namespace VideoInterpolator.ViewModels
{
    using Prism.Commands;
    using Prism.Mvvm;

    /// <summary>
    /// The view model for the main window.
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private string _videoDetails;
        private bool _isProcessing;

        public MainWindowViewModel()
        {
            this.VideoDetails = "";
            this.LoadVideoCommand = new DelegateCommand(this.LoadVideo, this.CanLoadVideo).ObservesProperty(() => this.IsProcessing);
        }

        private bool CanLoadVideo()
        {
            return !this.IsProcessing;
        }

        private async void LoadVideo()
        {
            this.IsProcessing = true;

            var openFileDialog = new OpenFileDialog
            {
                DefaultExt = ".mp4",
                Filter = "MPEG-4 Video (.mp4)|*.mp4"
            };

            var result = openFileDialog.ShowDialog();

            if (result != true)
            {
                this.VideoDetails = "No file selected.";
                this.IsProcessing = false;
                return;
            }

            var video = await VideoTools.FileManagement.LoadVideoFileAsync(openFileDialog.FileName);
            this.VideoDetails = video.Details;

            this.IsProcessing = false;
        }

        public DelegateCommand LoadVideoCommand { get; set; }

        public bool IsProcessing
        {
            get => this._isProcessing;
            set => this.SetProperty(ref this._isProcessing, value);
        }

        public string VideoDetails
        {
            get => this._videoDetails;
            set => this.SetProperty(ref this._videoDetails, value);
        }
    }
}
