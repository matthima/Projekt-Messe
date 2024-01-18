using AForge.Video;
using AForge.Video.DirectShow;

namespace App {
    internal class WebcamFeed {
        private readonly PictureBox feedTarget;
        private VideoCaptureDevice? webcam;

        public WebcamFeed(PictureBox feedTarget) {
            this.feedTarget = feedTarget;
        }

        public void Start() {
            this.feedTarget.Image = null;
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0) {
                this.webcam = new VideoCaptureDevice(videoDevices[0].MonikerString);
                this.webcam.NewFrame += new NewFrameEventHandler(this.FrameEventHandler);
                this.webcam.Start();
            }
            else {
                MessageBox.Show("Keine Webcam verfügbar, bitte wenden Sie sich an unsere Kundenberatung");
            }
        }

        public void FrameEventHandler(object sender, NewFrameEventArgs e) {
            this.feedTarget.Image = (Bitmap)e.Frame.Clone();
        }

        public void StopFeed() {
            if (this.webcam != null) {
                this.webcam.SignalToStop();
            }
        }
    }
}
