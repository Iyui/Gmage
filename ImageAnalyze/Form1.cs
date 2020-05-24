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

        Bitmap initBitmap = null;

        #endregion

        public Form1()
        {
            InitializeComponent();
        }

        private void AnalyzeRGB(Bitmap bitmap)
        {
            initRGB = new int[5][];
            for (int i = 0; i < 5; i++)
                initRGB[i] = new int[bitmap.Height * bitmap.Width];
            int m = 0;
            for (int i = 0; i < bitmap.Height; i++)
            {
                for (int j = 0; j < bitmap.Width; j++)
                {
                    //获取当前点的Color对象
                    Color c = bitmap.GetPixel(j, i);
                    //计算转化过灰度图之后的rgb值（套用已有的计算公式）
                    int rgb = Gray(c);
                    initRGB[0][m] = m++;
                    initRGB[1][i * j] = rgb;
                    initRGB[1][i * j] = c.R;
                    initRGB[2][i * j] = c.G;
                    initRGB[3][i * j] = c.B;
                }
            }
        }

        private void InitChart()
        {
            var X = initRGB[0];
            var R = initRGB[1];
            var G = initRGB[2];
            var B = initRGB[3];

            //GeneralChart(ct_InitChart, "R", X, R);
            //GeneralChart(ct_InitChart, "G", X, G);
            //GeneralChart(ct_InitChart, "B", X, B);
        }

        private void GeneralChart(Chart chart, string name, int[] x, int[] y, SeriesChartType seriesChartType = SeriesChartType.Spline)
        {
            chart.Series.Add(name);
            chart.Series[name].ChartType = seriesChartType;
            chart.Series[name].Points.DataBindXY(x, y);
            //chart.ChartAreas[0].AxisX.Enabled = AxisEnabled.True;
            //chart.ChartAreas[0].AxisX.LabelStyle.Enabled = false;
            //chart.ChartAreas[0].AxisX.MajorTickMark.Size = 0;
            chart.ChartAreas[0].AxisX.ScaleView.Size = 256;
            //chart.ChartAreas[0].AxisX.ScrollBar.ButtonStyle = ScrollBarButtonStyles.All;
            //chart.ChartAreas[0].AxisX.ScrollBar.IsPositionedInside = true;
        }

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {

            ReadInitImage();
            //AnalyzeRGB(initBitmap);
            //InitChart();
        }


        string  filename ="";
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
                filename = oi.FileName;
                var Format = new string[] { ".jpg", ".bmp" };
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
            pictureBox2.Image = Threshoding(initBitmap,Threshold);
            GC.Collect();

        }
        //反色
        private void btn_Complementary_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Complementary(initBitmap);
            GC.Collect();
        }

        private void btn_Gray_Click(object sender, EventArgs e)
        {
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

            pictureBox2.Image = ImageToGrey2(initBitmap);
            GC.Collect();
        }

        private void btn_Frequency_Click(object sender, EventArgs e)
        {
            try
            {
                pictureBox2.Image = Fourier.FFT(initBitmap);
            }
            catch { };
        }

        private void btn_Gaussian_Click(object sender, EventArgs e)
        {
            Gauss convolution = new Gauss();
            pictureBox2.Image = convolution.Smooth(initBitmap);
        }

        private void btn_Robert_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = EdgeDetector.Robert(initBitmap, Threshold);
        }

        private void btn_Smoothed_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = EdgeDetector.Smoothed(initBitmap);
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gauss.AddSalt(initBitmap);
        }

        private void btn_GaussNoise_Click(object sender, EventArgs e)
        {
            pictureBox2.Image = Gauss.Goss_noise(initBitmap);
        }

        private void btn_Polar_Click(object sender, EventArgs e)
        {
            if (initBitmap != null)
            {
                //PolarCoordinate hs = new PolarCoordinate(initBitmap);
                //hs.ShowDialog();
                var img = new Image<Bgr, byte>(filename);

                var img2 = new Image<Bgr, byte>(filename);
    
                CvInvoke.LogPolar(img, img2, new PointF(
              img.Width / 2,
              img.Height / 2
               ), 100);

                pictureBox2.Image = img2.ToBitmap();
            }
        }
    }
}
