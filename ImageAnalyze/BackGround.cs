using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using static ImageAnalyze.ImageProcess;
namespace ImageAnalyze
{
    public partial class CutBackground : Form
    {
        private Color tr_color = Color.Transparent;
        private bool b_start = false;
        bool[] b_visible = null;
        public static int model = 0;
        public CutBackground()
        {
            InitializeComponent();
        }

        private void CutBackground_Load(object sender, EventArgs e)
        {
            foreach (ToolStripItem items in contextMenuStrip1.Items)
            {
                items.Click += contextMenu_Click;
            }
            SetBackgroundImageTransparent();
            //timer.Start();
        }
        private void SetBackgroundImageTransparent()
        {
            Point pt = this.PointToScreen(new Point(0, 0));
            Bitmap b = new Bitmap(this.Width, this.Height);
            using (Graphics g = Graphics.FromImage(b))
            {
                g.CopyFromScreen(pt, new Point(), new Size(this.Width, this.Height));
            }

            this.BackgroundImage = SwitchFunc(b);
            GC.Collect();
        }

        private Bitmap SwitchFunc(Bitmap b)
        {

            switch (model)
            {
                default:
                    break;
                case 1:
                    b = ImageToGreyP(b);
                    break;
                case 2:
                    b = ImageToGrey2(b);
                    break;
                case 3:
                    b = Thresholding(b);
                    break;
                case 4:
                    b = ComplementaryP(b);
                    break;
                case 5:
                    b = FFT(b);
                    break;
                case 6:
                    b = GaussBlur(b);
                    break;
                case 7:
                    b = EdgeDetector_Robert(b);
                    break;
                case 8:
                    b = EdgeDetector_Smoothed(b);
                    break;
                case 9:
                    b = SaltNoise(b);
                    break;
                case 10:
                    b = GaussNoise(b);
                    break;
                case 11:
                    b = Polar(b);
                    break;
                case 12:
                    b = Recognite_Face(b); 
                    break;
            }
            return b;
        }
        private void BeginSet()
        {
            tr_color = this.TransparencyKey;
            b_start = true;
        }
        private void Setting()
        {
            if (b_start)
            {
                b_visible = new bool[Controls.Count];
                for (int i = 0; i < Controls.Count; i++)
                {
                    b_visible[i] = Controls[i].Visible;
                    Controls[i].Visible = false;
                }
                BackgroundImage = null;
                BackColor = Color.White;
                b_start = false;
                this.TransparencyKey = Color.White;
            }
        }
        private void EndSet()
        {
            SetBackgroundImageTransparent();
            this.TransparencyKey = tr_color;
            for (int i = 0; i < Controls.Count; i++)
            {
                Controls[i].Visible = b_visible[i];
            }
            b_start = false;
        }

        private void CutBackground_Resize(object sender, EventArgs e)
        {
            Setting();
        }
        private void CutBackground_ResizeBegin(object sender, EventArgs e)
        {
            BeginSet();
        }
        private void CutBackground_ResizeEnd(object sender, EventArgs e)
        {
            EndSet();
        }
        private void CutBackground_Move(object sender, EventArgs e)
        {
            Setting();
        }

        /// <summary>
        /// 设置右键菜单单选
        /// </summary>
        /// <param name="cms">参数-右键可选项类</param>
        public void IsCheckedControl(ToolStripMenuItem cms)
        {
            foreach (ToolStripMenuItem item in this.contextMenuStrip1.Items)
            {
                if (cms.Name == "tsmI_Save")
                    return;
                //不是当前项的取消选择
                if (item.Name == cms.Name)
                {
                    model = int.Parse(cms.Tag.ToString());
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

        private void contextMenu_Click(object sender, EventArgs e)
        {
            IsCheckedControl((ToolStripMenuItem)sender);
            SetBackgroundImageTransparent();
        }
    }

}

