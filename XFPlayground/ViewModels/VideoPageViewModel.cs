using System;
using System.ComponentModel;
using System.Threading.Tasks;
using LibVLCSharp.Shared;

namespace XFPlayground.ViewModels
{
    public class VideoPageViewModel : BaseViewModel
    {
        public VideoPageViewModel()
        {
            Task.Run((Action)Initialize);
        }


        private LibVLC LibVLC { get; set; }

        private MediaPlayer _mediaPlayer;
        public MediaPlayer MediaPlayer
        {
            get => _mediaPlayer;
            private set => Set(nameof(MediaPlayer), ref _mediaPlayer, value);
        }

        private bool IsLoaded { get; set; }
        private bool IsVideoViewInitialized { get; set; }

        private void Initialize()
        {
            Core.Initialize();

            LibVLC = new LibVLC();
            MediaPlayer = new MediaPlayer(LibVLC)
            {
                Media = new Media(LibVLC,
                    "https://download.blender.org/peach/bigbuckbunny_movies/BigBuckBunny_320x180.mp4",
                    FromType.FromLocation)
            };
        }

        public void OnAppearing()
        {
            IsLoaded = true;
            Play();
        }

        public void OnVideoViewInitialized()
        {
            IsVideoViewInitialized = true;
            Play();
        }

        private void Play()
        {
            if (IsLoaded && IsVideoViewInitialized)
            {
                MediaPlayer.Play();
            }
        }

    }
}
