using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Collections;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.IO;
using MaterialSkin;
using MaterialSkin.Animations;
using MaterialSkin.Controls;
using static ImageAnalyze.ImageProcess;
namespace ImageAnalyze
{
    public partial class MainForm : MaterialForm
    {
        #region 变量

        public Bitmap ResultImage
        {
            set=> col.Image=value; get=> (Bitmap)col.Image;
        }

        public Bitmap initBitmap { set; get; }

        private Hashtable htTabImageName = new Hashtable();

        //Bitmap 

        #endregion
        private readonly MaterialSkinManager materialSkinManager;
        public MainForm()
        {
            InitializeComponent();
            initBitmap = new Bitmap(1, 1);
            ResultImage = initBitmap.Clone() as Bitmap;
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme = 
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, 
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            menuStrip1.BackColor = ((int)Primary.BlueGrey900).ToColor();
        }
     

        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            ReadInitImage();
            
        }


        private void ReadInitImage()
        {
            OpenFileDialog oi = new OpenFileDialog
            {
                //oi.InitialDirectory = "c:\\";
                Filter = "图片(*.jpg,*.jpeg,*.bmp,*.png) | *.jpg;*.jpeg;*.bmp;*.png| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                var filename = oi.FileName;
                var Format = new string[] { ".jpg", ".bmp", ".jpeg", ".png" };
                if (Format.Contains(Path.GetExtension(filename).ToLower()))
                {
                    try
                    {
                        if (mtS_Selected.BaseTabControl != mTC_ImageTab)
                        {
                            mtS_Selected.BaseTabControl = mTC_ImageTab;
                            mTC_ImageTab.Visible = true;
                            mRB_Select.Visible = false;
                        }
                        initBitmap = (Bitmap)Image.FromFile(filename);
                        SetTab(Path.GetFileNameWithoutExtension(filename));
                        if (!HideTab())
                        {
                            materialContextMenuStrip1.Enabled = true;
                        }
                        else
                        {
                            ResetBitmap();
                        }
                        //pB_Init.Image = initBitmap.Clone() as Image;

                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show("不正确的格式", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        /// <summary>
        /// 打开文件时tabcontrol显示图片名字
        /// </summary>
        private void SetTabName(TabPage tp,string imageName)
        {
            tp.Text = imageName;
        }

        /// <summary>
        /// 打开文件时tabcontrol显示图片名字
        /// </summary>
        private void SetTab(string imageName)
        {
            TabPage t = new TabPage(imageName);
            t.Name = "tp_" + imageName;
            mTC_ImageTab.TabPages.Add(t);
            PictureBox it = new PictureBox()
            {
                Name = "pb_" + imageName,
            };
            mTC_ImageTab.TabPages[t.Name].Controls.Add(it);
            mTC_ImageTab.TabPages[t.Name].BackColor = Color.FromArgb(255, 51, 51, 51);
            htTabImageName.Add(t.Name, it.Name);
            mTC_ImageTab.SelectedTab = mTC_ImageTab.TabPages[t.Name];
            it.Dock = DockStyle.Fill;
            it.Image = initBitmap.Clone() as Image;
            
        }

        private void btn_Binarization_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Binarization;
            ResultImage = BinarizationP(initBitmap);
            Open_Threshold_Config();


        }
        //反色
        private void btn_Complementary_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Complementary;
            ResultImage = ComplementaryP(initBitmap);
        }

        private void btn_Gray_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Gray;
            ResultImage = ImageToGreyP(initBitmap);
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            Histogramcs hs = new Histogramcs(initBitmap);
            hs.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Gray;
            ResultImage = ImageToGrey2(initBitmap);
        }

        private void btn_Frequency_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Frequency;
            ResultImage = FFT(initBitmap);
        }

        private void btn_Gaussian_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.GaussBlur;
            ResultImage = GaussBlurP(initBitmap);
        }

        private void btn_Robert_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Robert;
            ResultImage = EdgeDetector_Robert(initBitmap);
            Open_Threshold_Config(20);
        }

        private void btn_Smoothed_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Smoothed;
            ResultImage = EdgeDetector_Smoothed(initBitmap);
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Salt;
            Probability py = new Probability(this, MousePosition)
            {
                InitBitmap = initBitmap,
            };
            SetImageCallback(SaltNoise(initBitmap));
            py.ShowDialog();
        }

        public void SetImageCallback(Bitmap bitmap)
        {
            ResultImage = bitmap;
        }

        private void btn_GaussNoise_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.GaussNoise;
            ResultImage = GaussNoise(initBitmap);
        }

        private void btn_Polar_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Polar;
            ResultImage = Polar(initBitmap);
            Open_Threshold_Config(11);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            CutBackground cb = new CutBackground(this);
            cb.Show();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.FaceRecognition;
            if(Path.GetExtension(Config.ClassifierPath)==".xml")
                ResultImage = Recognite_Face(initBitmap, Config.ClassifierPath);
            else
                MessageBox.Show("请先选择分类器", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }



        private int Interval(int tick)
        {
            return Environment.TickCount - tick;
        }

        private void btn_MedianFilter_Click(object sender, EventArgs e)
        {
            ResultImage = MedianFilter(initBitmap);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Classifier_Load();
        }

        private void Classifier_Load()
        {
            var path = Application.StartupPath + @"\Classifier\";
            FloderExist(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fi = dir.GetFiles();
            if (fi.Length == 0)
                return;
            foreach (var f in fi)
            {
                if (f.Extension != ".xml")
                    continue;
                ToolStripMenuItem items = new ToolStripMenuItem()
                {
                    Name = f.Name,
                    Text = f.Name,
                    Tag = f.FullName,
                    CheckOnClick = true,
                };
                items.Click += contextMenu_Click;
                tsmi_Classifier.DropDownItems.Add(items);
            }
        }

        private bool FloderExist(string path)
        {

            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
                
            }
            catch { return false; }
        }

        Config config = new Config();
        private void contextMenu_Click(object sender, EventArgs e)
        {
            Config.ClassifierPath = (string)((ToolStripMenuItem)sender).Name;
            config.IsCheckedControl((ToolStripMenuItem)sender, tsmi_Classifier);
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog
            {
                Filter = "JPEG (*.jpg,*.jpeg) | *.jpg;*.jpeg",//设置文件类型
                FileName = Guid.NewGuid().ToString(),//设置默认文件名
                AddExtension = true//设置自动在文件名中添加扩展名
            };
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                ResultImage.Save(sfd.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                MessageBox.Show("保存成功");
            }
        }

        private void btn_Sharpen_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Sharpen;
            ResultImage = Sharpen(initBitmap);
            Open_Threshold_Config(25);
        }

        private void Open_Threshold_Config(int hold = 128)
        {
            Process.Threshold ptd = new Process.Threshold(this, MousePosition, hold)
            {
                InitBitmap = initBitmap.Clone() as Bitmap,
            };
            ptd.ShowDialog();
        }

        private void btn_Lighten_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Lighten;
            ResultImage = Lighten(initBitmap);
            Open_Threshold_Config(0);
        }

        private void btn_Contrast_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Contrast;
            ResultImage = Contrast(initBitmap);
            Open_Threshold_Config(0);
        }

        private void btn_BFT_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.BFT;
            ResultImage = BFT(initBitmap);
        }

        private void tsmi_About_Click(object sender, EventArgs e)
        {
           // MessageBox.Show("666");
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
        PictureBox col= new PictureBox();
        private void materialTabSelector1_TabIndexChanged(object sender, EventArgs e)
        {
            ResetBitmap();
        }

        private void ResetBitmap()
        {
            if (mTC_ImageTab.SelectedTab is null)
                return;
            var selectedTabName = (string)htTabImageName[mTC_ImageTab.SelectedTab.Name];
            col = (PictureBox)mTC_ImageTab.SelectedTab.Controls.Find(selectedTabName, true)[0];
            if (!(col.Image is null))
                initBitmap = (Bitmap)col.Image;
        }

        private void tsm_CloseTabPage_Click(object sender, EventArgs e)
        {

            Remove();
            if (HideTab())
            {
                materialContextMenuStrip1.Enabled = false;
            }
        }

        /// <summary>
        /// 删除当前选中的选项卡
        /// </summary>
        public void Remove()
        {
            // 删除时判断是否还存在TabPage
            if (mTC_ImageTab.SelectedIndex > -1)
            {
                if (HideTab())
                    return;
                //使用TabControl控件的TabPages属性的Remove方法移除指定的选项卡
                int removeIndex = mTC_ImageTab.SelectedIndex;
                htTabImageName.Remove((string)mTC_ImageTab.SelectedTab.Name);
                mTC_ImageTab.TabPages.Remove(mTC_ImageTab.SelectedTab);
            }
        }

        private bool HideTab()
        {
            if (mTC_ImageTab.TabPages.Count < 2)
            {
                return true;
            }
            return false;
        }
    }
}
