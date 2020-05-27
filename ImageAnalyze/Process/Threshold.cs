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

        public Threshold(MainForm f, Point p)
        {
            InitializeComponent();
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
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
            }
            return ResultBitmap;
        }

        private void SetThresholdText()
        {
            if (Model == 11)
                label1.Text = $"M:\r\n{Hold.ToString()}";
            else
                label1.Text = $"阈值\r\n{Hold.ToString()}";
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            SetThresholdText();
        }
    }
}
