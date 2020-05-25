using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using static ImageAnalyze.ImageProcess;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace ImageAnalyze
{
    public partial class Form1 : Form
    {
        #region 变量
        int[][] initRGB;

        public int Threshold { get => (int)nud_Threshold.Value; }

        Bitmap initBitmap = new Bitmap(1, 1);

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

  
        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            ReadInitImage();
        }


        private void ReadInitImage()
        {
            OpenFileDialog oi = new OpenFileDialog
            {
                //oi.InitialDirectory = "c:\\";
                Filter = "图片(*.jpg,*.jpeg,*.bmp) | *.jpg;*.jpeg;*.bmp| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                var filename = oi.FileName;
                var Format = new string[] { ".jpg", ".bmp" ,".jpeg" };
                if (Format.Contains(Path.GetExtension(filename).ToLower()))
                {
                    try
                    {
                        initBitmap = (Bitmap)Image.FromFile(filename);
                        //var image1 = Image.FromFile(filename);
                        //image = new Bitmap(image1);
                        pB_Init.Image = initBitmap.Clone() as Image;
                    }
                    catch
                    {
                        MessageBox.Show("不正确的格式", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btn_Threshod_Click(object sender, EventArgs e)
        {
            CutBackground.model = 3;
            pictureBox2.Image = Threshoding(initBitmap,Threshold);
            GC.Collect();

        }
        //反色
        private void btn_Complementary_Click(object sender, EventArgs e)
        {
            CutBackground.model = 4;
            pictureBox2.Image = Complementary(initBitmap);
            GC.Collect();
        }

        private void btn_Gray_Click(object sender, EventArgs e)
        {
            CutBackground.model = 1;
            pictureBox2.Image = ImageToGrey(initBitmap);
            GC.Collect();
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            if (initBitmap != null)
            {
                Histogramcs hs = new Histogramcs(initBitmap);
                hs.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CutBackground.model = 2;
            pictureBox2.Image = ImageToGrey2(initBitmap);
        }

        private void btn_Frequency_Click(object sender, EventArgs e)
        {
            try
            {
            CutBackground.model = 5;
                pictureBox2.Image = FFT(initBitmap);
            }
            catch { };
        }

        private void btn_Gaussian_Click(object sender, EventArgs e)
        {
            CutBackground.model = 6;
            pictureBox2.Image = GaussBlur(initBitmap);
        }

        private void btn_Robert_Click(object sender, EventArgs e)
        {
            CutBackground.model = 7;
            pictureBox2.Image = EdgeDetector_Robert(initBitmap, Threshold);
        }

        private void btn_Smoothed_Click(object sender, EventArgs e)
        {
            CutBackground.model = 8;
            pictureBox2.Image = EdgeDetector_Smoothed(initBitmap);
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            CutBackground.model = 9;
            pictureBox2.Image = SaltNoise(initBitmap);
        }

        private void btn_GaussNoise_Click(object sender, EventArgs e)
        {
            CutBackground.model = 10;
            pictureBox2.Image = GaussNoise(initBitmap);
        }

        private void btn_Polar_Click(object sender, EventArgs e)
        {
            CutBackground.model = 11;
            pictureBox2.Image = Polar(initBitmap);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CutBackground cb = new CutBackground();
            cb.Show();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            CutBackground.model = 12;
            pictureBox2.Image = Recognite_Face(initBitmap);
        }
    }
}
