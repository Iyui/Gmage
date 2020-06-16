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
            SetChannelRGB();
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
                if (r > 1000)
                    r = 1000;
                if (r < 0)
                    r = 0;
                mT_CR.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 1000)
                {
                    mT_CR.Text = 1000.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_CR.Text = 0.ToString();
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
                if (r > 1000)
                    r = 1000;
                if (r < 0)
                    r = 0;
                mT_CG.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 1000)
                {
                    mT_CG.Text = 1000.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_CG.Text = 0.ToString();
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
                if (r > 1000)
                    r = 1000;
                if (r < 0)
                    r = 0;
                mT_CB.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 1000)
                {
                    mT_CB.Text = 1000.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_CB.Text = 0.ToString();
                    return;
                }
                mT_CB.Text = value.ToString();
            }
        }
        private void ChangeChannel()
        {
            Config.Model = FunctionType.RGBChannel;
            float[] fRGB = new float[] { Color_CR / 100f, Color_CG / 100f, Color_CB / 100f };
            Config.parameter.fParameter = fRGB;
            ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter, false);
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
