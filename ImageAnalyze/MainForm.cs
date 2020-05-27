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
            set=> pictureBox2.Image=value; get=>pictureBox2.Image;
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
            Process.Threshold ptd = new Process.Threshold(this, MousePosition)
            {
                InitBitmap = initBitmap.Clone() as Bitmap,
                Model = 3,
            };
            ResultImage = ThresholdingP(initBitmap);
            ptd.ShowDialog();
        }
        //反色
        private void btn_Complementary_Click(object sender, EventArgs e)
        {
            CutBackground.model = 4;
            ResultImage = ComplementaryP(initBitmap);
            GC.Collect();
        }

        private void btn_Gray_Click(object sender, EventArgs e)
        {
            CutBackground.model = 1;
            ResultImage = ImageToGreyP(initBitmap);
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
            ResultImage = ImageToGrey2(initBitmap);
        }

        private void btn_Frequency_Click(object sender, EventArgs e)
        {
            try
            {
            CutBackground.model = 5;
                ResultImage = FFT(initBitmap);
            }
            catch { };
        }

        private void btn_Gaussian_Click(object sender, EventArgs e)
        {
            CutBackground.model = 6;
            ResultImage = GaussBlurP(initBitmap);
        }

        private void btn_Robert_Click(object sender, EventArgs e)
        {
            CutBackground.model = 7;
            Process.Threshold ptd = new Process.Threshold(this, MousePosition)
            {
                InitBitmap = initBitmap.Clone() as Bitmap,
                Model = 7,
            };
            ResultImage = EdgeDetector_Robert(initBitmap);
            ptd.ShowDialog();
        }

        private void btn_Smoothed_Click(object sender, EventArgs e)
        {
            CutBackground.model = 8;
            ResultImage = EdgeDetector_Smoothed(initBitmap);
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            CutBackground.model = 9;
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
            CutBackground.model = 10;
            ResultImage = GaussNoise(initBitmap);
        }

        private void btn_Polar_Click(object sender, EventArgs e)
        {
            CutBackground.model = 11;
            Process.Threshold ptd = new Process.Threshold(this, MousePosition)
            {
                InitBitmap = initBitmap.Clone() as Bitmap,
                Model = 11,
            };
            ResultImage = Polar(initBitmap);
            ptd.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CutBackground cb = new CutBackground();
            cb.Show();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            CutBackground.model = 12;
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
            btn_SelectImage.Focus();
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "位图 (*.bmp) | *.bmp|JPEG (*.jpg,*.jpeg) | *.jpg;*.jpeg|PNG (*.png) | *.png",//设置文件类型
                FileName = Guid.NewGuid().ToString(),//设置默认文件名
                AddExtension = true//设置自动在文件名中添加扩展名
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ResultImage.Save(sfd.FileName);
                MessageBox.Show("保存成功");
            }
        }
    }
}
