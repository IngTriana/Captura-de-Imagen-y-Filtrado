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
        //int rm, gm, bm, rM, gM, bM;
        int rm1, gm1, bm1, rM1, gM1, bM1;
        int rm2, gm2, bm2, rM2, gM2, bM2;
        bool ViewMask;
        #endregion

        #region Methods
        /*private void UpdateValues()
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
        }*/

        private void UpdateValues()
        {
            if (this.InvokeRequired)
            {
                this.Invoke(new Action(() => UpdateValues()));
                return;
            }
            rm1 = tBMinRed.Value;
            gm1 = tBMinGreen.Value;
            bm1 = tBMinBlue.Value;
            rM1 = tBMaxRed.Value;
            gM1 = tBMaxGreen.Value;
            bM1 = tBMaxBlue.Value;

            rm2 = tBMinRed.Value;
            gm2 = tBMinGreen.Value;
            bm2 = tBMinBlue.Value;
            rM2 = tBMaxRed.Value;
            gM2 = tBMaxGreen.Value;
            bM2 = tBMaxBlue.Value;
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

        /*
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
                    //Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    win.ShowImage(ViewMask ? Mask : FilteredImage);
                    Cv2.ImShow("Crop", crop);
                    Cv2.SetWindowTitle("Crop", "x = "+x+", y = "+y);
                    Console.WriteLine("x = " + x + ", y = " + y);
                    Cv2.WaitKey(1);
                }
                Cv2.DestroyWindow("Crop");
            }
            Camera.Release();
            DisconnectCamera();
        }
        */
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
                    Mat FilteredImage1 = new Mat();
                    Mat Mask1 = new Mat();
                    Mat FilteredImage2 = new Mat();
                    Mat Mask2 = new Mat();

                    UpdateValues();

                    Cv2.InRange(OriginalFrame, new Scalar(bm1, gm1, rm1), new Scalar(bM1, gM1, rM1), Mask1);
                    Cv2.BitwiseAnd(OriginalFrame, OriginalFrame, FilteredImage1, Mask1);
                    Cv2.InRange(OriginalFrame, new Scalar(bm2, gm2, rm2), new Scalar(bM2, gM2, rM2), Mask2);
                    Cv2.BitwiseAnd(OriginalFrame, OriginalFrame, FilteredImage2, Mask2);
                    var moments1 = Cv2.Moments(Mask1);
                    var moments2 = Cv2.Moments(Mask2);
                    int x1 = (int)(moments1.M10 / moments1.M00);
                    int y1 = (int)(moments1.M01 / moments1.M00);
                    int x2 = (int)(moments2.M10 / moments2.M00);
                    int y2 = (int)(moments2.M01 / moments2.M00);
                    x1 = x1 >= xsize ? x1 : xsize;
                    y1 = y1 >= ysize ? y1 : ysize;
                    x1 = x1 <= OriginalFrame.Width - xsize ? x1 : OriginalFrame.Width - xsize;
                    y1 = y1 <= OriginalFrame.Height - ysize ? y1 : OriginalFrame.Height - ysize;
                    x2 = x2 >= xsize ? x2 : xsize;
                    y2 = y2 >= ysize ? y2 : ysize;
                    x2 = x2 <= OriginalFrame.Width - xsize ? x2 : OriginalFrame.Width - xsize;
                    y2 = y2 <= OriginalFrame.Height - ysize ? y2 : OriginalFrame.Height - ysize;



                    Cv2.Circle(FilteredImage1, new Point(x1, y1), 10, new Scalar(0, 255, 0), 2);
                    Cv2.Circle(FilteredImage2, new Point(x2, y2), 10, new Scalar(0, 255, 0), 2);


                    //Cortar 60 x 60
                    Mat crop1 = FilteredImage1[y1 - ysize, y1 + ysize, x1 - xsize, x1 + xsize];
                    Mat crop2 = FilteredImage2[y2 - ysize, y2 + ysize, x2 - xsize, x2 + xsize];
                    stopwatch.Stop();
                    Delays.Enqueue(stopwatch.Elapsed);
                    stopwatch.Restart();
                    //Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    win.ShowImage(ViewMask ? Mask1 : FilteredImage1);
                    Cv2.ImShow("Crop", crop1);
                    Cv2.SetWindowTitle("Crop", "x = " + x1 + ", y = " + y1);
                    Console.WriteLine("x1 = " + x1 + ", y1 = " + y1);

                    
                    
                    //Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    win.ShowImage(ViewMask ? Mask2 : FilteredImage2);
                    Cv2.ImShow("Crop", crop2);
                    Cv2.SetWindowTitle("Crop", "x = " + x2 + ", y = " + y2);
                    Console.WriteLine("x2 = " + x2 + ", y2 = " + y2);

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

        private void btnCol1_Click(object sender, EventArgs e)
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
