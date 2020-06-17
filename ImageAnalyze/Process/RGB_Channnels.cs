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
    public partial class RGB_Channnels : MaterialForm
    {
        private MainForm f;
        private readonly MaterialSkinManager materialSkinManager;
        private GraphCommand.GraphCommand _g;
        public RGB_Channnels(MainForm f, Point p)
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
            _g = Config.graphCommand;
            SetScrollStyle();
            SetTextStyle();
            SetChannelRGB();
            
        }

        private void SetScrollStyle()
        {
            TrackBar[] trackBars = new TrackBar[] { tb_CR, tb_CG, tb_CB };
            foreach (var tb in trackBars)
            {
                switch (Config.Model)
                {
                    case FunctionType.RGBChannel:
                        tb.Minimum = 0;
                        tb.Maximum = 1000;
                        tb.Value = 100;
                        break;
                    case FunctionType.HueSaturationAdjust:
                    case FunctionType.LightnessAdjustProcess:
                    case FunctionType.ColorBalanceProcess:
                        tb.Minimum = -100;
                        tb.Maximum = 100;
                        break;
                    case FunctionType.USMProcess:
                        tb_CR.Maximum = 500;
                        tb_CG.Maximum = 50;
                        tb_CB.Maximum = 255;
                        tb.Minimum = 0;
                        break;
                }
            }
        }

        private void SetTextStyle()
        {
            switch (Config.Model)
            {
                case FunctionType.RGBChannel:
                    Color_CR = 100;
                    Color_CG = 100;
                    Color_CB = 100;
                    label6.Text = "R%";
                    label5.Text = "G%";
                    label4.Text = "B%";
                    break;
                case FunctionType.HueSaturationAdjust:
                case FunctionType.LightnessAdjustProcess:
                    label6.Text = "色相";
                    label5.Text = "饱和度";
                    label4.Text = "明度";
                    break;
                case FunctionType.ColorBalanceProcess:
                    label6.Text = "青色";
                    label5.Text = "洋红";
                    label4.Text = "黄色";
                    break;
                case FunctionType.USMProcess:
                    label6.Text = "数量";
                    label5.Text = "半径";
                    label4.Text = "阈值";
                    break;
            }
        }

        public Bitmap InitBitmap
        {
            set; get;
        }

        public Bitmap ResultBitmap
        {
            set; get;
        }

        #region RGB通道
        public int Color_CR
        {
            get
            {
                int.TryParse(mT_CR.Text, out int r);
                if (r > tb_CR.Maximum)
                    r = tb_CR.Maximum;
                if (r < tb_CR.Minimum)
                    r = tb_CR.Minimum;
                mT_CR.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > tb_CR.Maximum)
                {
                    mT_CR.Text = tb_CR.Maximum.ToString();
                    return;
                }
                if (value < tb_CR.Minimum)
                {
                    mT_CR.Text = tb_CR.Minimum.ToString();
                    return;
                }
                mT_CR.Text = value.ToString();
            }
        }
        public int Color_CG
        {
            get
            {
                int.TryParse(mT_CG.Text, out int r);
                if (r > tb_CG.Maximum)
                    r = tb_CG.Maximum;
                if (r < tb_CG.Minimum)
                    r = tb_CG.Minimum;
                mT_CG.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > tb_CG.Maximum)
                {
                    mT_CG.Text = tb_CG.Maximum.ToString();
                    return;
                }
                if (value < tb_CG.Minimum)
                {
                    mT_CG.Text = tb_CG.Minimum.ToString();
                    return;
                }
                mT_CG.Text = value.ToString();
            }
        }

        public int Color_CB
        {
            get
            {
                int.TryParse(mT_CB.Text, out int r);
                if (r > tb_CB.Maximum)
                    r = tb_CB.Maximum;
                if (r < tb_CB.Minimum)
                    r = tb_CB.Minimum;
                mT_CB.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > tb_CB.Maximum)
                {
                    mT_CB.Text = tb_CB.Maximum.ToString();
                    return;
                }
                if (value < tb_CB.Minimum)
                {
                    mT_CB.Text = tb_CB.Minimum.ToString();
                    return;
                }
                mT_CB.Text = value.ToString();
            }
        }
        private void ChangeChannel()
        {
            switch (Config.Model)
            {
                case FunctionType.RGBChannel:
                    float[] fRGB = new float[] { Color_CR / 100f, Color_CG / 100f, Color_CB / 100f };
                    Config.parameter.fParameter = fRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.HueSaturationAdjust:
                case FunctionType.LightnessAdjustProcess:
                    int[] iRGB = new int[] { Color_CR, Color_CG, Color_CB };
                    Config.parameter.iParameter = iRGB;
                    Config.Model = FunctionType.HueSaturationAdjust;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    Config.Model = FunctionType.LightnessAdjustProcess;
                    ResultBitmap = _g.Execute(Config.Model, ResultBitmap, Config.parameter, false);
                    break;
                case FunctionType.ColorBalanceProcess:
                    iRGB = new int[] { Color_CR, Color_CG, Color_CB,0 };
                    bool[] bLight = new bool[] {false};
                    Config.parameter.iParameter =iRGB;
                    Config.parameter.bParameter = bLight;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
                case FunctionType.USMProcess:
                    iRGB = new int[] { Color_CR,  Color_CB};
                    fRGB = new float[] { Color_CG/10f };
                    Config.parameter.iParameter = iRGB;
                    Config.parameter.fParameter = fRGB;
                    ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
                    break;
            }  
            f.SetImageCallback(ResultBitmap);
        }
        private void SetChannelRGB()
        {
            mT_CR.TextChanged += (sender, e) =>
            {
                tb_CR.Value = Color_CR;
                ChangeChannel();
            };

            mT_CG.TextChanged += (sender, e) =>
            {
                tb_CG.Value = Color_CG;
                ChangeChannel();
            };

            mT_CB.TextChanged += (sender, e) =>
            {
                tb_CB.Value = Color_CB;
                ChangeChannel();
            };


            mT_CR.KeyPress += InputLimit;

            mT_CG.KeyPress += InputLimit;

            mT_CB.KeyPress += InputLimit;

            tb_CR.Scroll += (sender, e) =>
            {
                Color_CR = tb_CR.Value;
            };

            tb_CG.Scroll += (sender, e) =>
            {
                Color_CG = tb_CG.Value;
            };

            tb_CB.Scroll += (sender, e) =>
            {
                Color_CB = tb_CB.Value;
            };
        }
        #endregion

        private void btn_OK_Click(object sender, EventArgs e)
        {
            ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter);
            f.SetImageCallback(ResultBitmap);
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            f.SetImageCallback(InitBitmap);
        }

        private void RGB_Channnels_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (DialogResult != DialogResult.OK)
            {
                f.SetImageCallback(InitBitmap);
            }
        }

        private void InputLimit(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 && (int)e.KeyChar != 8) || ((int)e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }
    }
}
