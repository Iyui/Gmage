using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImageAnalyze.ImageProcess;

namespace ImageAnalyze.Process
{
    public partial class Threshold : Form
    {
        private MainForm f;
        public int Hold
        {
            set => tB_Threshold.Value = value;
            get => tB_Threshold.Value;
        }

        public Bitmap InitBitmap
        {
            set; get;
        }

        public int Model
        {
            set; get;
        }

        public Bitmap ResultBitmap
        {
            set; get;
        }

        public Threshold(MainForm f, Point p, int hold)
        {
            InitializeComponent();
            Hold = hold;
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
        }

        private void SetScrollStyle()
        {
            switch (Model)
            {
                case 14:
                    tB_Threshold.Minimum = -255;
                    break;
                case 15:
                    tB_Threshold.Minimum = -100;
                    tB_Threshold.Maximum = 100;
                    break;
            }
        }

        private void tB_Threshold_Scroll(object sender, EventArgs e)
        {
            f.SetImageCallback(SetThreshold());
            SetThresholdText();
        }

        private Bitmap SetThreshold()
        {
            GC.Collect();
            switch (Model)
            {
                default:
                    break;
                case 3:
                    ResultBitmap = ThresholdingP(InitBitmap, Hold);
                    break;
                case 7:
                    ResultBitmap = EdgeDetector_Robert(InitBitmap, Hold);
                    break;
                case 11:
                    ResultBitmap = Polar(InitBitmap, Hold);
                    break;
                case 13:
                    ResultBitmap = Sharpen(InitBitmap, Hold / 25.5f);
                    break;
                case 14:
                    ResultBitmap = Lighten(InitBitmap, Hold);
                    break;
                case 15:
                    ResultBitmap = Contrast(InitBitmap, Hold);
                    break;
            }
            return ResultBitmap;
        }

        private void SetThresholdText()
        {
            switch (Model)
            {
                default:
                    label1.Text = $"阈值\r\n{Hold.ToString()}";
                    break;
                case 11:
                    label1.Text = $"M:\r\n{Hold.ToString()}";
                    break;
                case 13:
                    label1.Text = $"锐化程度:\r\n{(Hold / 25.5f).ToString("0.00%")}";
                    break;
            }
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            SetThresholdText();
            SetScrollStyle();
        }
    }
}
