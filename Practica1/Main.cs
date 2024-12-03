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
        bool Tracking;
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
            Tracking = cbTracking.Checked;
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
            var features = new Rect[2];
            using (var win = new OpenCvSharp.Window("Imagen"))
            {





                Camera.Read(OriginalFrame);



                    features = Cv2.SelectROIs("Imagen", OriginalFrame, true, false);

                    do
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
                    //Cv2.InRange(OriginalFrame, new Scalar(bm, gm, rm), new Scalar(bM, gM, rM), Mask);
                    //Cv2.BitwiseAnd(OriginalFrame, OriginalFrame, FilteredImage, Mask);

                    //Cv2.SetWindowTitle("Imagen", $"Delay: {Delays.Last().TotalSeconds}");
                    
                    /*-------------------------------------------------------------------------------------------*/
                    var feature1 = OriginalFrame[features[0]];
                        //var feature2 = OriginalFrame[features[1]];

                        Mat FIf1 = new Mat();
                        Mat maskf1 = new Mat();
                        Cv2.InRange(feature1, new Scalar(bm, gm, rm), new Scalar(bM, gM, rM), maskf1);
                        Cv2.BitwiseAnd(feature1, feature1, FIf1, maskf1);
                        var momentsF1 = Cv2.Moments(maskf1);
                    
                        xsize = features[0].Width;
                        ysize = features[0].Height;

                        int x1 = (int)(momentsF1.M10 / momentsF1.M00);
                        int y1 = (int)(momentsF1.M01 / momentsF1.M00);
                        int dx1 = x1 - xsize / 2;
                        int dy1 = y1 - ysize / 2;
                        int x01 = features[0].Left + dx1;
                        int y01 = features[0].Top +  dy1;
                        x01 = x01 < 0 ? 0 : x01;
                        y01 = y01 < 0 ? 0 : y01;
                        x01 = x01 + xsize > OriginalFrame.Width ? OriginalFrame.Width - xsize : x01;
                        y01 = y01 + ysize > OriginalFrame.Height ? OriginalFrame.Height - ysize : y01;
                    //features[0].Top += x1 - features[0].Width / 2;
                    //features[0].Left += y1 - features[0].Height / 2;

                    
                    features[0] = Tracking? new Rect(x01,y01,xsize,ysize) : features[0];
                    Cv2.Rectangle(OriginalFrame, features[0], new Scalar(0, 255, 0), 2);
                        Cv2.ImShow("Feature1", maskf1);

                    Cv2.ImShow("Original",OriginalFrame);


                }
                    while (!token.IsCancellationRequested && Cv2.WaitKey(1) != 81);

                    


                    

                   
                
                //Cv2.DestroyWindow("Crop");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

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
