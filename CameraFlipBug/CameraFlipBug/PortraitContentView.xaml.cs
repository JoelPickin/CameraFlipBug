using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.CommunityToolkit.UI.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace CameraFlipBug
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PortraitContentView : ContentView
    {
        public PortraitContentView()
        {
            InitializeComponent();
        }

        void CameraView_OnAvailable(object sender, bool e)
        {
            captureButton.IsEnabled = e;
        }

        async void CameraView_MediaCaptured(object sender, MediaCapturedEventArgs e)
        {
            switch (cameraView.CaptureMode)
            {
                default:
                case CameraCaptureMode.Default:
                    shutterFeedbackPage.IsVisible = true;

                    break;
            }

            await shutterFeedbackPage.FadeTo(1, 150);

            shutterFeedbackPage.IsVisible = false;
        }

        private void EnableDisableFlash_Tapped(object sender, EventArgs e)
        {
            if (cameraView.FlashMode == CameraFlashMode.Off)
            {
                cameraView.FlashMode = CameraFlashMode.On;
                flashButton.TextColor = Color.Yellow;
            }
            else if (cameraView.FlashMode == CameraFlashMode.On)
            {
                cameraView.FlashMode = CameraFlashMode.Off;
                flashButton.TextColor = Color.White;
            }
        }

        double currentScale = 1;
        double startScale = 1;

        private void PinchGestureRecognizer_PinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            if (e.Status == GestureStatus.Started)
            {
                //Captured cameras current zoom
                startScale = cameraView.Zoom;
            }
            if (e.Status == GestureStatus.Running)
            {
                //Calculate the scale factor to be applied.
                currentScale += (e.Scale - 1) * startScale;
                currentScale = Math.Max(1, currentScale);

                //Apply scale factor
                cameraView.Zoom = currentScale;
            }
        }
    }
}