using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAnalyze
{
    public partial class Probability : Form
    {
        public double Pb
        {
            get => tB_Pepper.Value / 1000d;
        }
        public double Pa
        {
            get => tB_Salt.Value / 1000d;
        }

        public Bitmap InitBitmap
        {
            set;get;
        }
        public Bitmap ResultBitmap
        {
            set; get;
        }
        private MainForm f;
        public Probability()
        {
            InitializeComponent();
          

        }

        public Probability(MainForm f, Point p)
        {
            InitializeComponent();
        
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
            label1.Text = $"椒概率\r\n0.1%";
            label2.Text = $"盐概率\r\n0.1%";
        }

        private Bitmap SaltPepperNoise()
        {
            GC.Collect();
            ResultBitmap = ImageProcess.SaltNoise(InitBitmap, Pa, Pb);
            return ResultBitmap;
        }

        private void tB_Pepper_Scroll(object sender, EventArgs e)
        {
            f.SetImageCallback(SaltPepperNoise());
            label1.Text = $"椒概率\r\n{(Pb * 100).ToString()}%";
        }

        private void tB_Salt_Scroll(object sender, EventArgs e)
        {
            f.SetImageCallback(SaltPepperNoise());
            label2.Text = $"盐概率\r\n{(Pa * 100).ToString()}%";
        }

        private void btn_MedianFilter_Click(object sender, EventArgs e)
        {
            f.SetImageCallback(ImageProcess.MedianFilter(ResultBitmap));
        }
    }
}
