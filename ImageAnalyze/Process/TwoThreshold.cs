using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin;
using MaterialSkin.Controls;
namespace Gmage.Process
{
    public partial class TwoThreshold : MaterialForm
    {
        public Bitmap InitBitmap
        {
            set; get;
        }
        public Bitmap ResultBitmap
        {
            set; get;
        }
        private MainForm f;
        private readonly MaterialSkinManager materialSkinManager;
        public TwoThreshold()
        {
            InitializeComponent();
            //materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            //materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
        }

        public float floatT1
        {
            get
            {
                float.TryParse(mT_mt1.Text, out float r);
                if (r > tB_bar1.Maximum)
                    r = tB_bar1.Maximum;
                if (r < tB_bar1.Minimum)
                    r = tB_bar1.Minimum;
                mT_mt1.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > tB_bar1.Maximum)
                {
                    mT_mt1.Text = tB_bar1.Maximum.ToString();
                    return;
                }
                if (value < tB_bar1.Minimum)
                {
                    mT_mt1.Text = tB_bar1.Minimum.ToString();
                    return;
                }
                mT_mt1.Text =(value).ToString();
            }
        }

        public float floatT2
        {
            get
            {
                float.TryParse(mT_mt2.Text, out float r);
                if (r > tB_bar2.Maximum)
                    r = tB_bar2.Maximum;
                if (r < tB_bar2.Minimum)
                    r = tB_bar2.Minimum;
                mT_mt2.Text = (r).ToString();
                return r;
            }
            set
            {
                if (value > tB_bar2.Maximum)
                {
                    mT_mt2.Text = tB_bar2.Maximum.ToString();
                    return;
                }
                if (value < tB_bar2.Minimum)
                {
                    mT_mt2.Text = tB_bar2.Minimum.ToString();
                    return;
                }
                mT_mt2.Text = (value).ToString();
            }
        }

        public TwoThreshold(MainForm f, Point p)
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
            
            SetChannelRGB();
            
        }

        private void SetChannelRGB()
        {
            mT_mt1.TextChanged += (sender, e) =>
            {
                tB_bar1.Value = (int)(floatT1);
                ChangeChannel();
            };

            mT_mt2.TextChanged += (sender, e) =>
            {
                tB_bar2.Value = (int)(floatT2);
                ChangeChannel();
            };


            mT_mt1.KeyPress += InputLimit;

            mT_mt2.KeyPress += InputLimit;

            tB_bar1.Scroll += (sender, e) =>
            {
                floatT1 = tB_bar1.Value;
            };

            tB_bar2.Scroll += (sender, e) =>
            {
                floatT2 = tB_bar2.Value;
            };
        }
        private GraphCommand.GraphCommand _g=Config.graphCommand;
        private void ChangeChannel()
        {
            switch (Config.Model)
            {
                case FunctionType.SurfaceBlur:
                    int[] iRGB = new int[] { (int)floatT1, (int)floatT2 };
                    Config.parameter.iParameter = iRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.MotionBlur:
                    iRGB = new int[] { (int)floatT1, (int)floatT2 };
                    Config.parameter.iParameter = iRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.ZoomBlurProcess:
                case FunctionType.SmartBlurProcess:
                    iRGB = new int[] { (int)floatT1, (int)floatT2 };
                    Config.parameter.iParameter = iRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.HighlightShadowPreciseAdjustProcess:
                    iRGB = new int[] { (int)floatT1, (int)floatT2 };
                    Config.parameter.iParameter = iRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.AnisotropicFilter:
                case FunctionType.Relief:
                    iRGB = new int[] { (int)floatT1, (int)floatT2 };
                    Config.parameter.iParameter = iRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.Lighten:
                case FunctionType.Contrast:
                    Config.Model = FunctionType.Lighten;
                    Config.parameter.Hold = (int)floatT1;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter);
                    Config.Model = FunctionType.Contrast;
                    Config.parameter.Hold = (int)floatT2;
                    ResultBitmap = _g.Execute(Config.Model, ResultBitmap, Config.parameter);
                    break;
            }
            f.SetImageCallback(ResultBitmap);
        }

        private void InputLimit(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar < 48 && e.KeyChar != 8) || (e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void TwoThreshold_Load(object sender, EventArgs e)
        {
            tB_bar1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            mT_mt1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            //mT_mt1.ForeColor = ((int)TextShade.WHITE).ToColor();

            label3.ForeColor = ((int)TextShade.WHITE).ToColor();
            label3.BackColor = Color.FromArgb(0,0,0,0);

            switch (Config.Model)
            {
                case FunctionType.MotionBlur:
                    tB_bar1.Maximum = 360;
                    tB_bar2.Maximum = 200;
                    tB_bar1.Minimum = 1;
                    tB_bar2.Minimum = 1;
                    break;
                case FunctionType.Relief:
                    tB_bar1.Maximum = 360;
                    tB_bar2.Maximum = 500;
                    tB_bar1.Minimum = 0;
                    tB_bar2.Minimum = 0;
                    break;
                case FunctionType.SmartBlurProcess:
                case FunctionType.SurfaceBlur:
                    tB_bar1.Maximum = 100;
                    tB_bar2.Maximum = 255;
                    tB_bar1.Minimum = 1;
                    tB_bar2.Minimum = 1;
                    break;
                case FunctionType.AnisotropicFilter:
                case FunctionType.ZoomBlurProcess:
                    tB_bar1.Maximum = 100;
                    tB_bar2.Maximum = 100;
                    tB_bar1.Minimum = 1;
                    tB_bar2.Minimum = 1;
                    break;
                case FunctionType.HighlightShadowPreciseAdjustProcess:
                    tB_bar1.Maximum = 100;
                    tB_bar2.Maximum = 100;
                    tB_bar1.Minimum = 0;
                    tB_bar2.Minimum = 0;
                    label3.Text = "高光";
                    this.Text = "阴影";
                    break;
                case FunctionType.Lighten:
                case FunctionType.Contrast:
                    tB_bar1.Maximum = 100;
                    tB_bar2.Maximum = 100;
                    tB_bar1.Minimum = -100;
                    tB_bar2.Minimum = -100;
                    this.Text = "亮度";
                    label3.Text = "对比度";
                    break;
            }
        }

        private void TwoThreshold_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                f.SetImageCallback(InitBitmap);
            }
        }

        private void btn_OK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
