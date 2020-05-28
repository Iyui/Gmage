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
    public partial class MainForm : Form
    {
        #region 变量

        public Image ResultImage
        {
            set => pictureBox2.Image = value; get => pictureBox2.Image;
        }

        Bitmap initBitmap = new Bitmap(1, 1);

        #endregion

        public MainForm()
        {
            InitializeComponent();
            ResultImage = initBitmap.Clone() as Bitmap;
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
                Filter = "图片(*.jpg,*.jpeg,*.bmp,*.png) | *.jpg;*.jpeg;*.bmp;*.png| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                var filename = oi.FileName;
                var Format = new string[] { ".jpg", ".bmp", ".jpeg", ".png" };
                if (Format.Contains(Path.GetExtension(filename).ToLower()))
                {
                    try
                    {
                        initBitmap = (Bitmap)Image.FromFile(filename);
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
            Config.Model = FunctionType.Binarization;
            ResultImage = BinarizationP(initBitmap);
            Open_Threshold_Config();


        }
        //反色
        private void btn_Complementary_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Complementary;
            ResultImage = ComplementaryP(initBitmap);
        }

        private void btn_Gray_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Gray;
            ResultImage = ImageToGreyP(initBitmap);
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            Histogramcs hs = new Histogramcs(initBitmap);
            hs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Gray;
            ResultImage = ImageToGrey2(initBitmap);
        }

        private void btn_Frequency_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Frequency;
            ResultImage = FFT(initBitmap);
        }

        private void btn_Gaussian_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.GaussBlur;
            ResultImage = GaussBlurP(initBitmap);
        }

        private void btn_Robert_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Robert;
            ResultImage = EdgeDetector_Robert(initBitmap);
            Open_Threshold_Config(20);
        }

        private void btn_Smoothed_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Smoothed;
            ResultImage = EdgeDetector_Smoothed(initBitmap);
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Salt;
            Probability py = new Probability(this, MousePosition)
            {
                InitBitmap = initBitmap,
            };
            SetImageCallback(SaltNoise(initBitmap));
            py.ShowDialog();
        }

        public void SetImageCallback(Bitmap bitmap)
        {
            ResultImage = bitmap;
        }

        private void btn_GaussNoise_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.GaussNoise;
            ResultImage = GaussNoise(initBitmap);
        }

        private void btn_Polar_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Polar;
            ResultImage = Polar(initBitmap);
            Open_Threshold_Config(11);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CutBackground cb = new CutBackground(this);
            cb.Show();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.FaceRecognition;
            ResultImage = Recognite_Face(initBitmap);
        }



        private int Interval(int tick)
        {
            return Environment.TickCount - tick;
        }

        private void btn_MedianFilter_Click(object sender, EventArgs e)
        {
            ResultImage = MedianFilter(initBitmap);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }


        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JPEG (*.jpg,*.jpeg) | *.jpg;*.jpeg",//设置文件类型
                FileName = Guid.NewGuid().ToString(),//设置默认文件名
                AddExtension = true//设置自动在文件名中添加扩展名
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("保存成功");
            }
        }

        private void btn_Sharpen_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Sharpen;
            ResultImage = Sharpen(initBitmap);
            Open_Threshold_Config(25);
        }

        private void Open_Threshold_Config(int hold = 128)
        {
            Process.Threshold ptd = new Process.Threshold(this, MousePosition, hold)
            {
                InitBitmap = initBitmap.Clone() as Bitmap,
            };
            ptd.ShowDialog();
        }

        private void btn_Lighten_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Lighten;
            ResultImage = Lighten(initBitmap);
            Open_Threshold_Config(0);
        }

        private void btn_Contrast_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Contrast;
            ResultImage = Contrast(initBitmap);
            Open_Threshold_Config(0);
        }

        private void btn_BFT_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.BFT;
            ResultImage = BFT(initBitmap);
        }
    }
}
