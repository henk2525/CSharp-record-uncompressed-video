using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using Accord.Video.FFMPEG;
using AForge.Video;
using AForge.Video.DirectShow;


namespace 情緒攝影
{
    public partial class Form1 : Form
    {
        private Stopwatch StopWatch;
        bool _recording = false;
        bool _stopthread = false;
        private BlockingCollection<Bitmap> ImageQueue = new BlockingCollection<Bitmap>();
        private BlockingCollection<TimeSpan> elapsedTimeQueue = new BlockingCollection<TimeSpan>();
        private SaveFileDialog dialog = new SaveFileDialog();
        private FilterInfoCollection VideoCaptureDevices;
        private VideoCaptureDevice FinalVideo;
        private Rectangle rect;
        public double recordtime;
        private VideoFileWriter _writer;
        List<string> myLists = new List<string>();
        private Thread t;
        public Form1()
        {
            InitializeComponent();
            StopWatch = new Stopwatch();

            VideoCaptureDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
            foreach (FilterInfo VideoCaptureDevice in VideoCaptureDevices)
                comboBoxAttachedCameras.Items.Add(VideoCaptureDevice.Name);
            t = new Thread(new ThreadStart(savevideothread));
        }

        private void BtnSavedir_Click(object sender, EventArgs e)
        {
            //FileBorserDialog.FolderBrowserDialog path = new FileBorserDialog.FolderBrowserDialog();
            dialog.FileName = "video1";
            dialog.DefaultExt = ".avi";
            dialog.Filter = "avi檔案 | *.avi";
            dialog.AddExtension = true;
            var dialogresult = dialog.ShowDialog();
            textBox1.Text = dialog.FileName;
        }


        private void BtnStart_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || comboBoxAttachedCameras.Text == "" || comboBoxSupportedModes.Text == "")
                MessageBox.Show("未選擇儲存路徑 or 未選擇相機 or 未選擇解析度");
            else if(BtnStart.Text == "開啟相機")
            {
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.Brightness, 128,VideoProcAmpFlags.Manual); // 亮度
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.Contrast, 128, VideoProcAmpFlags.Manual); // 對比
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.Saturation, 128, VideoProcAmpFlags.Manual); // 飽和度
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.WhiteBalance, 5500, VideoProcAmpFlags.Manual); // 白平衡
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.BacklightCompensation, 0, VideoProcAmpFlags.Manual); // 背光補償
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.Gain, 0, VideoProcAmpFlags.Manual); // 增益
                FinalVideo.SetVideoProperty(VideoProcAmpProperty.KSPROPERTY_VIDEOPROCAMP_POWERLINE_FREQUENCY, 2, VideoProcAmpFlags.Manual); // 電源基線
                FinalVideo.SetCameraProperty(CameraControlProperty.Zoom, 100, CameraControlFlags.Manual); // 縮放
                FinalVideo.SetCameraProperty(CameraControlProperty.Focus, 0, CameraControlFlags.Manual); // 焦距
                FinalVideo.SetCameraProperty(CameraControlProperty.Exposure, -5, CameraControlFlags.Manual); // 曝光度
                FinalVideo.SetCameraProperty(CameraControlProperty.Pan, 0, CameraControlFlags.Manual); // 取景位置調整
                FinalVideo.SetCameraProperty(CameraControlProperty.Tilt, 0, CameraControlFlags.Manual); // 傾斜
                FinalVideo.SetCameraProperty(CameraControlProperty.KSPROPERTY_CAMERACONTROL_AUTO_EXPOSURE_PRIORITY, 0, CameraControlFlags.Manual); // 弱光補償

                FinalVideo.VideoResolution = FinalVideo.VideoCapabilities[comboBoxSupportedModes.SelectedIndex];
                Btnsetcamera.Enabled = true;
                rect = new Rectangle(FinalVideo.VideoResolution.FrameSize.Width / 2 - 175, FinalVideo.VideoResolution.FrameSize.Height / 2 - 200, 350, 400);
                FinalVideo.Start();
                t.Start();
                BtnStart.Text = "關閉相機";
                BtnStart.Enabled = false;
                comboBoxAttachedCameras.Enabled = false;
                comboBoxSupportedModes.Enabled = false;
                label4.Visible = true;
            }
        }

        private void BtnRecord_Click(object sender, EventArgs e)
        {
            if(BtnRecord.Text == "開始攝影")
            {
                if (textBox1.Text == "" || comboBoxAttachedCameras.Text == "" || comboBoxSupportedModes.Text == "")
                    MessageBox.Show("未選擇儲存路徑 or 未選擇相機 or 未選擇解析度");
                else
                {
                    myLists.Clear();
                    Btnsetcamera.Enabled = false;
                    BtnStart.Enabled = false;
                    _writer = new VideoFileWriter();
                    _writer.Open(textBox1.Text, 350, 400, 30, VideoCodec.Raw);
                    StopWatch.Restart();
                    StopWatch.Start();
                    _recording = true;
                    BtnRecord.Text = "結束攝影";
                    label6.Text = "錄製中!";
                    label6.Visible = true;
                }
            }

            else
            {
                BtnRecord.Text = "開始攝影";
                _recording = false;
                _writer.Close();
                _writer.Dispose();
                StopWatch.Stop();
                using (StreamWriter outputFile = new StreamWriter(textBox1.Text.Substring(0, textBox1.Text.Length-4) + ".txt"))
                {
                    foreach (string line in myLists)
                        outputFile.WriteLine(line);
                }
                label6.Text = "已儲存檔案，可安全關閉!";
                textBox1.Text = "";
            }
        }


        private void FinalFrame_NewFrame(object sender, NewFrameEventArgs eventArgs)
        {
            ImageQueue.Add((Bitmap)eventArgs.Frame.Clone());
            elapsedTimeQueue.Add(StopWatch.Elapsed);
        }
        private TimeSpan elapsedTime;
        private void savevideothread()
        {
            Bitmap Image, CroppedImage;
            while (true)
            {
                if (_stopthread)
                    break;
                Image = ImageQueue.Take();
                elapsedTime = elapsedTimeQueue.Take();
                CroppedImage = Image.Clone(rect, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                if(_recording == true)
                {
                    _writer.WriteVideoFrame(CroppedImage);
                    myLists.Add(elapsedTime.ToString());
                }
                if (pictureBoxVideo.Image != null)
                    pictureBoxVideo.Image.Dispose();
                pictureBoxVideo.Image = CroppedImage;
                Image.Dispose();
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            _stopthread = true;
            if (FinalVideo!= null)
                FinalVideo.Stop();
            if (_recording == true)
            {
                _writer.Close();
                _writer.Dispose();
            }
            Application.Exit(null);
        }

        private void comboBoxAttachedCameras_SelectedIndexChanged(object sender, EventArgs e)
        {
            FinalVideo = new VideoCaptureDevice(VideoCaptureDevices[comboBoxAttachedCameras.SelectedIndex].MonikerString);
            comboBoxSupportedModes.Items.Clear();
            comboBoxSupportedModes.Text = "";
            foreach (var capability in FinalVideo.VideoCapabilities)
            {
                string fourcc = decode_fourcc(capability.compression);
                comboBoxSupportedModes.Items.Add(capability.FrameSize.ToString() + "," + capability.MaximumFrameRate.ToString() + "fps,"  +  fourcc + " codec");
            }
            FinalVideo.NewFrame += new NewFrameEventHandler(FinalFrame_NewFrame);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.label5.Text = StopWatch.Elapsed.ToString();
        }
        
        private string decode_fourcc(int fourcc)
        {
            var fourccString = new string
                (
                    new[]
                    {
                        (char)(fourcc & 0xFF),
                        (char)((fourcc & 0xFF00) >> 8),
                        (char)((fourcc & 0xFF0000) >> 16),
                        (char)((fourcc & 0xFF000000U) >> 24)
                    }
                );
            return fourccString;
        }

        private void Btnsetcamera_Click(object sender, EventArgs e)
        {
            FinalVideo.DisplayPropertyPage(IntPtr.Zero);
        }
    }
}
