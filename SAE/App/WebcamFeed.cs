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
            feedTarget.Image = null;
            FilterInfoCollection videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            if (videoDevices.Count > 0 ) {
                webcam = new VideoCaptureDevice(videoDevices[0].MonikerString);
                webcam.NewFrame += new NewFrameEventHandler(FrameEventHandler);
                webcam.Start();
            }
            else {
                MessageBox.Show("Keine Webcam verfügbar, bitte wenden Sie sich an unsere Kundenberatung");
            }
        }

        public void FrameEventHandler(object sender, NewFrameEventArgs e) {
            feedTarget.Image = (Bitmap) e.Frame.Clone();
        }

        public void StopFeed() {
            if (webcam != null) {
                webcam.SignalToStop();
            }
        }
    }
 }
