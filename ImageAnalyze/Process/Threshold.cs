using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Gmage.ImageProcess;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Gmage.Process
{
    public partial class Threshold : MaterialForm
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
            button2.BackColor = button1.BackColor = ((int)Primary.BlueGrey800).ToColor();
        }

        private void SetScrollStyle()
        {
            tB_Threshold.BackColor = ((int)Primary.BlueGrey800).ToColor();
            label1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            label1.ForeColor= ((int)TextShade.WHITE).ToColor();
            switch (Config.Model)
            {
                case FunctionType.Lighten:
                    tB_Threshold.Minimum = -255;
                    break;
                case FunctionType.Contrast:
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
            switch (Config.Model)
            {
                default:
                    break;
                case FunctionType.Binarization:
                    ResultBitmap = BinarizationP(InitBitmap, Hold);
                    break;
                case FunctionType.Robert:
                    ResultBitmap = EdgeDetector_Robert(InitBitmap, Hold);
                    break;
                case FunctionType.Polar:
                    ResultBitmap = Polar(InitBitmap, Hold);
                    break;
                case FunctionType.Sharpen:
                    ResultBitmap = Sharpen(InitBitmap, Hold / 25.5f);
                    break;
                case FunctionType.Lighten:
                    ResultBitmap = Lighten(InitBitmap, Hold);
                    break;
                case FunctionType.Contrast:
                    ResultBitmap = Contrast(InitBitmap, Hold);
                    break;
                case FunctionType.Line:
                    ResultBitmap = EdgeDetector_Line(InitBitmap, Hold);
                    break;
            }
            return ResultBitmap;
        }

        private int LoadThreshold()
        {
            int _threshold = 0;
            switch (Config.Model)
            {
                default:
                case FunctionType.Sharpen:
                case FunctionType.Contrast:
                case FunctionType.Lighten:
                    _threshold = 0;
                    break;
                case FunctionType.Binarization:
                    _threshold = 128;
                    break;
                case FunctionType.Robert:
                    _threshold = 30;
                    break;
                case FunctionType.Polar:
                    _threshold = 30;
                    break;
               
            }
            return _threshold;
        }


        private void SetThresholdText()
        {
            switch (Config.Model)
            {
                default:
                    label1.Text = $"{Hold.ToString()}";
                    break;
                case FunctionType.Binarization:
                    label1.Text = $"{Hold.ToString()}";
                    break;
                case FunctionType.Sharpen:
                    label1.Text = $"{(Hold / 25.5f).ToString("0.00%")}";
                    break;
            }
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            SetScrollStyle();
            Hold = LoadThreshold();
            SetThresholdText();
            f.SetImageCallback(SetThreshold());
        }

        private void mFB_Select_Click(object sender, EventArgs e)
        {
            f.SetImageCallback(ResultBitmap);
        }

        private void Threshold_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                f.SetImageCallback(InitBitmap);
            }
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            f.SetImageCallback(InitBitmap);
        }
    }
}
