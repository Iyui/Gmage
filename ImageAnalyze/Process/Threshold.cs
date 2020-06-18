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
        private GraphCommand.GraphCommand _g;
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

        public int Thold
        {
            get
            {
                int.TryParse(mT_T.Text, out int r);
                if (r > tB_Threshold.Maximum)
                    r = tB_Threshold.Maximum;
                if (r < tB_Threshold.Minimum)
                    r = tB_Threshold.Minimum;
                mT_T.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > tB_Threshold.Maximum)
                {
                    mT_T.Text = tB_Threshold.Maximum.ToString();
                    return;
                }
                if (value < tB_Threshold.Minimum)
                {
                    mT_T.Text = tB_Threshold.Minimum.ToString();
                    return;
                }
                mT_T.Text = value.ToString();
            }
        }

        private readonly MaterialSkinManager materialSkinManager;

        public Threshold(MainForm f, Point p, int hold)
        {
            InitializeComponent();
            Hold = hold;
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
            button2.BackColor = button1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            _g = Config.graphCommand;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            mT_T.TextChanged += (sender, e) =>
            {
                tB_Threshold.Value = Thold;
                ThresholdChange();
            };
        }
        //GraphCommand.Parameter parameter = new GraphCommand.Parameter();
        private Bitmap SetThreshold()
        {
            GC.Collect();
            Config.parameter.Hold = Hold;
            ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter,false);
            return ResultBitmap;
        }

        private void SetScrollStyle()
        {
            tB_Threshold.BackColor = ((int)Primary.BlueGrey800).ToColor();
            mT_T.BackColor = ((int)Primary.BlueGrey800).ToColor();
            mT_T.ForeColor= ((int)TextShade.WHITE).ToColor();
            switch (Config.Model)
            {
                case FunctionType.Lighten:
                    tB_Threshold.Minimum = -255;
                    break;
                case FunctionType.Contrast:
                case FunctionType.NaturalSaturationProcess:
                case FunctionType.ColorTemperatureProcess:
                case FunctionType.ExposureAdjust:
                    tB_Threshold.Minimum = -100;
                    tB_Threshold.Maximum = 100;
                    break;
                case FunctionType.SoftSkinFilter:
                    tB_Threshold.Minimum = 0;
                    tB_Threshold.Maximum = 20;
                    break;
            }
        }

        private void tB_Threshold_Scroll(object sender, EventArgs e)
        {
            ThresholdChange();
        }

        private void ThresholdChange()
        {
            f.SetImageCallback(SetThreshold());
            SetThresholdText();
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
                case FunctionType.Binarization:     
                case FunctionType.Sharpen:
                    mT_T.Text = $"{(Hold)}";
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
            ResultBitmap = _g.Execute(Config.Model, InitBitmap, Config.parameter);
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
