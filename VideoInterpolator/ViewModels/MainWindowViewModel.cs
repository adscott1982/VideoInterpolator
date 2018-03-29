using System.Windows.Forms;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

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
        private bool _isVideoLoaded;

        public MainWindowViewModel()
        {
            this.VideoDetails = "";
            this.LoadVideoCommand = new DelegateCommand(this.LoadVideo, this.CanLoadVideo).ObservesProperty(() => this.IsProcessing);
            this.ExtractFramesCommand = new DelegateCommand(this.ExtractFrames, this.CanExtractFrames)
                .ObservesProperty(() => this.IsProcessing)
                .ObservesProperty(() => this.IsVideoLoaded);
        }

        public DelegateCommand ExtractFramesCommand { get; set; }

        public DelegateCommand LoadVideoCommand { get; set; }

        public bool IsProcessing
        {
            get => this._isProcessing;
            set => this.SetProperty(ref this._isProcessing, value);
        }

        public bool IsVideoLoaded
        {
            get => this._isVideoLoaded;
            set => this.SetProperty(ref this._isVideoLoaded, value);
        }

        public string VideoDetails
        {
            get => this._videoDetails;
            set => this.SetProperty(ref this._videoDetails, value);
        }

        private bool CanExtractFrames()
        {
            return !this.IsProcessing && this.IsVideoLoaded;
        }

        private void ExtractFrames()
        {
            this.IsProcessing = true;

            using (var folderDialog = new System.Windows.Forms.FolderBrowserDialog())
            {
                if (folderDialog.ShowDialog() != DialogResult.OK)
                {
                    this.IsProcessing = false;
                    return;
                }

                var extractPath = folderDialog.SelectedPath;
            }

            this.IsProcessing = false;
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
                Filter = "MPEG-4 Video (.mp4)|*.mp4|All files (*.*)|*.*"
            };

            var result = openFileDialog.ShowDialog();

            if (result != true)
            {
                this.VideoDetails = "No file selected.";
                this.IsProcessing = false;
                this.IsVideoLoaded = false;
                return;
            }

            var video = await VideoTools.FileManagement.LoadVideoFileAsync(openFileDialog.FileName);
            this.VideoDetails = $"Duration: {video.Duration:g}";

            this.IsVideoLoaded = true;
            this.IsProcessing = false;
        }
    }
}
