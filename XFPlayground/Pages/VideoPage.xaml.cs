using System;

using LibVLCSharp.Shared;

using Xamarin.Forms;
using XFPlayground.ViewModels;

namespace XFPlayground.Pages
{
    public partial class VideoPage : ContentPage
    {
        public VideoPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ((VideoPageViewModel)BindingContext).OnAppearing();
        }

        private void VideoView_MediaPlayerChanged(object sender, MediaPlayerChangedEventArgs e)
        {
            ((VideoPageViewModel)BindingContext).OnVideoViewInitialized();
        }

    }
}
