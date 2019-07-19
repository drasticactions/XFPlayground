using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFPlayground.Components
{
    public partial class ImageSpinner : ContentView
    {
        public ImageSpinner()
        {
            InitializeComponent();
            RotateCover(true);
        }

        private CancellationTokenSource animateTimerCancellationTokenSource;

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
