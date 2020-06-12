using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
namespace Gmage
{
    public partial class BatchModel : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        Dictionary<string, FunctionType> Func = new Dictionary<string, FunctionType>();

        public string ModelName { set; get; }
        public BatchModel()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            lB_Task.BackColor = Color.FromArgb(255, 51, 51, 51);
            lB_Task.ForeColor = Color.White;
        }

        private void BatchModel_Load(object sender, EventArgs e)
        {
            SetDic();
            foreach (var key in Func.Keys)
                lB_Task.Items.Add(key);
        }

        private void SetDic(string key, FunctionType value)
        {
            Func.Add(key, value);
        }

        private void SetDic()
        {
            SetDic("灰度化", FunctionType.Gray);
            SetDic("二值化", FunctionType.Binarization);
            SetDic("反色", FunctionType.Complementary);
            SetDic("Smoothed边缘检测", FunctionType.Smoothed);
            SetDic("频率谱", FunctionType.FFT);
            SetDic("旋转180度", FunctionType.Clockwise180);
            SetDic("顺时针旋转90度", FunctionType.Clockwise90);
            SetDic("逆时针旋转90度", FunctionType.Clockwise270);
            SetDic("垂直镜像", FunctionType.RotateNoneFlipX);
            SetDic("水平镜像", FunctionType.RotateNoneFlipY);
        }

        private void materialFlatButton1_Click(object sender, EventArgs e)
        {
            if(lB_Task.SelectedItem is null)
            {
                DialogResult = DialogResult.Cancel;
                return;
            }
            ModelName =lB_Task.SelectedItem.ToString();
            Config.Model = Func[ModelName];
        }
    }
}
