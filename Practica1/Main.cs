using DirectShowLib;
using OpenCvSharp;
using Practica1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Practica1
{
    public partial class Main : Form
    {
        #region Members
        List<DsDevice> Cameras;
        List<Models.Resolution> SupportedResolutions;
        VideoCapture Camera = new VideoCapture();
        CancellationTokenSource CTS = new CancellationTokenSource();
        CancellationToken Token;
        Task task;
        int LostFrames = 0;
        int CapturedFrames = 0;
        int xsize = 100;
        int ysize = 100;
        Queue<TimeSpan> Delays;
        Mat OriginalFrame = new Mat();
        int rm, gm, bm, rM, gM, bM;
        bool ViewMask;
        #endregion

        #region Methods
        private void UpdateValues()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateValues()));
                return;
            }
             rm = tBMinRed.Value;
             gm = tBMinGreen.Value;
             bm = tBMinBlue.Value;
             rM = tBMaxRed.Value;
             gM = tBMaxGreen.Value;
             bM = tBMaxBlue.Value;
        }
        private void UpdateFilter()
        {
            label3.Text = tBMinRed.Value.ToString();
            label6.Text = tBMaxRed.Value.ToString();
            label5.Text = tBMinBlue.Value.ToString();
            label8.Text = tBMaxBlue.Value.ToString();
            label4.Text = tBMinGreen.Value.ToString();
            label7.Text = tBMaxGreen.Value.ToString();
        }
        private void LoadCameras()
        {
            Cameras = Utilities.Cameras.GetCameras();
            cBCamera.DataSource = Cameras;
            cBCamera.DisplayMember = "Name";
        }

        private void ConnectCamera()
        {
            CTS = new CancellationTokenSource();
            Token = CTS.Token;
            Camera.Open(cBCamera.SelectedIndex);
            btnConnect.BackgroundImage = global::Practica1.Properties.Resources.Oxygen_Icons_org_Oxygen_Actions_window_close_256;
            Resolution resolution = SupportedResolutions[cBResolution.SelectedIndex];
            Camera.Set(VideoCaptureProperties.FrameWidth, resolution.FrameWidth);
            Camera.Set(VideoCaptureProperties.FrameHeight, resolution.FrameHeight);
            Camera.Set(VideoCaptureProperties.FourCC, resolution.Compression);
            task = new Task(() => { VideoProcessing(Token); }, Token);
            task.Start();
        }

        private void VideoProcessing(CancellationToken token)
        {
            LostFrames = 0;
            CapturedFrames = 0;
            Delays = new Queue<TimeSpan>(); 
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            using (var win = new OpenCvSharp.Window("Imagen"))
            {
                while (!token.IsCancellationRequested)
                {
                    if (!Camera.Read(OriginalFrame))
                    {
                        ++LostFrames;
                        continue;
                    }
                    ++CapturedFrames;
                    Mat FilteredImage = new Mat();
                    Mat Mask = new Mat();
                    UpdateValues();
                    Cv2.InRange(OriginalFrame, new Scalar(bm, gm, rm), new Scalar(bM, gM, rM), Mask);
                    Cv2.BitwiseAnd(OriginalFrame, OriginalFrame, FilteredImage, Mask);
                    var moments = Cv2.Moments(Mask);
                    int x = (int)(moments.M10 / moments.M00);
                    int y = (int)(moments.M01 / moments.M00);
                    x = x >= xsize ? x : xsize;
                    y = y >= ysize ? y : ysize;
                    x = x <= OriginalFrame.Width-xsize ? x : OriginalFrame.Width-xsize;
                    y = y <= OriginalFrame.Height - ysize ? y : OriginalFrame.Height - ysize;
                    Cv2.Circle(FilteredImage, new Point(x, y), 10, new Scalar(0, 255, 0), 2);
                    //Cortar 60 x 60
                    Mat crop = FilteredImage[y-ysize, y + ysize, x-xsize, x+xsize];
                    stopwatch.Stop();
                    Delays.Enqueue(stopwatch.Elapsed);
                    stopwatch.Restart();
                    Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    win.ShowImage(ViewMask ? Mask : FilteredImage);
                    Cv2.ImShow("Crop", crop);
                    Cv2.WaitKey(1);
                }
                Cv2.DestroyWindow("Crop");
            }
            Camera.Release();
            DisconnectCamera();
        }

        private void DisconnectCamera()
        {
            if(this.InvokeRequired)
            {
                this.Invoke(new Action(DisconnectCamera));
                return;
            }
            Cv2.DestroyAllWindows();
            btnConnect.BackgroundImage = global::Practica1.Properties.Resources.Mazenl77_I_Like_Buttons_3a_Cute_Ball_Go_512;
        }
        #endregion

        public Main()
        {
            InitializeComponent();
            LoadCameras();
        }

        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            ViewMask = cBMask.Checked;
        }

        private void cBCamera_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cBCamera.Items.Count > 0) 
            {
                SupportedResolutions = Utilities.Cameras.GetSupportedResolutions(Cameras[cBCamera.SelectedIndex].Mon);
                cBResolution.DataSource = SupportedResolutions;
                cBResolution.DisplayMember = "Caption";
            }
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            if(Camera.IsOpened())
            {
                CTS.Cancel();
            }
            else
            {
                ConnectCamera();
            }
        }

        private void tBMinRed_ValueChanged(object sender, EventArgs e)
        {
            UpdateFilter();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog ofd = new SaveFileDialog();
            ofd.Filter = "Archivo JSON|*.json";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if(ofd.ShowDialog() == DialogResult.OK)
            {
                Models.ValuesFilter.SaveData(ofd.FileName);
                MessageBox.Show($"Los datos se guardaron en: {ofd.FileName}");
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Archivo JSON|*.json";
            ofd.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                Models.ValuesFilter.LoadData(ofd.FileName);
                MessageBox.Show("Los datos se cargaron con éxito");
            }
        }
    }
}
