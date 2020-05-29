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
    public partial class CutBackground :Form
    {
        private Color tr_color = Color.Transparent;
        private bool b_start = false;
        bool[] b_visible = null;
        MainForm f;

        public CutBackground(MainForm f)
        {
            InitializeComponent();
            this.f = f;
        }

        private void CutBackground_Load(object sender, EventArgs e)
        {
            foreach (ToolStripItem items in contextMenuStrip1.Items)
            {
                items.Click += contextMenu_Click;
            }
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
            switch (Config.Model)
            {
                default:
                    break;
                case FunctionType.Gray:
                    b = ImageToGreyP(b);
                    break;
                case FunctionType.Binarization:
                    b = BinarizationP(b);
                    break;
                case FunctionType.Complementary:
                    b = ComplementaryP(b);
                    break;
                case FunctionType.Frequency:
                    b = FFT(b);
                    break;
                case FunctionType.GaussBlur:
                    b = GaussBlurP(b);
                    break;
                case FunctionType.Robert:
                    b = EdgeDetector_Robert(b);
                    break;
                case FunctionType.Smoothed:
                    b = EdgeDetector_Smoothed(b);
                    break;
                case FunctionType.Salt:
                    b = SaltNoise(b);
                    break;
                case FunctionType.GaussNoise:
                    b = GaussNoise(b);
                    break;
                case FunctionType.Polar:
                    b = Polar(b);
                    break;
                case FunctionType.FaceRecognition:
                    b = Recognite_Face(b); 
                    break;
                case FunctionType.Sharpen:
                   b = Sharpen(b);
                    break;
                case FunctionType.Lighten:
                    b = Lighten(b);
                    break;
                case FunctionType.Contrast:
                    b = Contrast(b);
                    break;
                case FunctionType.MedianFilter:
                    b = MedianFilter(b);
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


        Config config = new Config();
        private void contextMenu_Click(object sender, EventArgs e)
        {
            config.IsCheckedControl((ToolStripMenuItem)sender, contextMenuStrip1);
            SetBackgroundImageTransparent();
        }

        private void tsmI_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JPEG (*.jpg,*.jpeg) | *.jpg;*.jpeg",//设置文件类型
                FileName = Guid.NewGuid().ToString(),//设置默认文件名
                AddExtension = true//设置自动在文件名中添加扩展名
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                BackgroundImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("保存成功");
            }
        }

        private void CutBackground_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (f.WindowState == FormWindowState.Minimized)
                f.WindowState = FormWindowState.Normal;
        }

        private void 亮度ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }

}

