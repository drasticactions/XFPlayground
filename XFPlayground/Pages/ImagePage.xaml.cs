using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFPlayground.Pages
{
    public partial class ImagePage : ContentPage
    {
        private CancellationTokenSource animateTimerCancellationTokenSource;


        public ImagePage()
        {
            InitializeComponent();
            RotateCover(true);
        }

        private void RotateCover(bool isPlaying)
        {
            if (isPlaying)
            {
                StartCoverAnimation(new CancellationTokenSource());
            }
            else
            {
                ViewExtensions.CancelAnimations(CoverImage);

                if (animateTimerCancellationTokenSource != null)
                {
                    animateTimerCancellationTokenSource.Cancel();
                }
            }
        }

        void StartCoverAnimation(CancellationTokenSource tokenSource)
        {
            try
            {
                animateTimerCancellationTokenSource = tokenSource;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (!animateTimerCancellationTokenSource.IsCancellationRequested)
                    {
                        await CoverImage.RelRotateTo(360, 5000, Easing.Linear);

                        StartCoverAnimation(animateTimerCancellationTokenSource);
                    }
                });
            }
            catch (TaskCanceledException ex)
            {
                Debug.WriteLine(ex);
            }
        }
    }
}
