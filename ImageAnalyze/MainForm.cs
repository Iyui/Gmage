﻿/* Title:Gmage
 * Author:Iyui
 * Image Process
 * 20200521:第一版
 * 20200602:完善批处理
 * 20200603:新增首选项设置
 * 20200604:新增拾色器、图片移动
 */
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
using static Gmage.RollBack;
using static Gmage.ImageProcess;
using System.Threading;
namespace Gmage
{
    public partial class MainForm : MaterialForm
    {
        #region 变量
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="e"></param>
        private void MessageManage(MessageEventArgs e)
        {
            switch (e.messageType)
            {
                case MessageType.ImageReading:
                    mPB_Bar.Visible = true;
                    Thread thread = new Thread(new ParameterizedThreadStart(SetImageShow));
                    thread.Start((object)e.FileNames);
                    break;
                case MessageType.RunTime:
                    break;
                case MessageType.Message:
                    SetImage_Control(e.Message);
                    break;
                case MessageType.Error:
                    break;
                case MessageType.DeadlyError:
                    MessageBox.Show(e.Message, "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Progress:
                    if ((int)e.Progress < 100)
                    {
                        mPB_Bar.Value = (int)e.Progress;
                    }
                    else
                        mPB_Bar.Visible = false;
                    break;
                case MessageType.ImageInfo:
                    break;
                case MessageType.PrgressInfo:
                    break;
            }
        }
        ToolTip toolTip = new ToolTip();

        private void SubthreadMessageReceive(MessageEventArgs e)
        {
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    MessageEventHandler handler = new MessageEventHandler(MessageManage);
                    this.Invoke(handler, new object[] { e });
                }
            }
            catch (Exception)
            {
                //throw new Exception("", ex);
            }
        }

        public Tools Tool{set; get;} = Tools.Empty;
        private Tools lastTool= Tools.Empty;
        private bool spaceUp = false;

        public Bitmap ResultImage
        {
            set => col.Image = value; get => (Bitmap)col.Image;
        }

        public Bitmap initBitmap { set; get; }

        private Hashtable htTabImageName = new Hashtable();

        bool canDrag = false;

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

            //Mtb_Color
            tabPage1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            groupBox1.BackColor = ((int)Primary.BlueGrey800).ToColor();
            tB_R.BackColor = ((int)Primary.BlueGrey800).ToColor();
            tB_G.BackColor = ((int)Primary.BlueGrey800).ToColor();
            tB_B.BackColor = ((int)Primary.BlueGrey800).ToColor();

            SetColorRGB();
            // pTools.BackColor = Color.FromArgb(255, 55, 71, 79);
            messageClass.OnMessageSend += new MessageEventHandler(SubthreadMessageReceive);
            TsmiClick();
            TsmiThresholdClick();
            ToolsClickEvent();
            SetToolTipPromot();
            this.KeyDown += (sender, e) =>
            {
                if (e.KeyCode == Keys.Space)
                {
                    if (spaceUp)
                    {
                        lastTool = Tool;
                        spaceUp = false;
                        Tool = Tools.Move;
                    }
                }
            };
            this.KeyUp += (sender, e) =>
            {
                if (e.KeyCode == Keys.Space)
                {
                    Tool = lastTool;
                    spaceUp = true ;
                }
            };
        }

        /// <summary>
        /// 设置按钮的提示文本
        /// </summary>
        private void SetToolTipPromot()
        {
           
            toolTip.SetToolTip(mFB_Cut, "裁剪");
            toolTip.SetToolTip(mFB_ColorPicker, "拾色器");
        }

        #region mtS_Selected及以上的控件功能
        private void btn_SelectImage_Click(object sender, EventArgs e)
        {
            ReadInitImage();
        }

        private void ReadInitImage()
        {
            OpenFileDialog oi = new OpenFileDialog
            {
                Filter = "图片(*.jpg,*.jpeg,*.bmp,*.png) | *.jpg;*.jpeg;*.bmp;*.png| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1,
                Multiselect = true,
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                RollBackMessage(oi.FileNames);
            }
        }

        private void SetImageShow(object fileNames)
        {
            var files = (string[])fileNames;
            var count = files.Count();
            float c = 0;
            foreach (var filename in files)
            {
                RollBackMessage(++c / count * 100f);
                SetImageShow(filename);
            }
            CheckonIndex();
        }

        private void SetImageShow(string filename)
        {
            var Format = new string[] { ".jpg", ".bmp", ".jpeg", ".png" };
            if (Format.Contains(Path.GetExtension(filename).ToLower()))
            {
                try
                {
                    RollBackMessage(filename);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("不正确的格式", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void SetImage_Control(string filename)
        {
            if (mtS_Selected.BaseTabControl != mTC_ImageTab)
            {
                mtS_Selected.BaseTabControl = mTC_ImageTab;
                mTC_ImageTab.Visible = true;
                panel1.Visible = false;
            }
            var initImage = (Bitmap)Image.FromFile(filename);
            ResultImage = initImage.Clone() as Bitmap;
            initBitmap = initImage.Clone() as Bitmap; ;
            SetTab(Path.GetFileNameWithoutExtension(filename));
            if (!HideTab())
            {
                materialContextMenuStrip1.Enabled = true;
                tsm_CloseTabPage.Enabled = true;
            }
            else
            {
                ResetBitmap();
            }
        }

        /// <summary>
        /// 打开文件时tabcontrol显示图片名字
        /// </summary>
        private void SetTab(string imageName)
        {
            imageName = reName(imageName);
            AddPagesIndex(imageName);
            TabPage t = new TabPage(imageName)
            {
                Name = "tp_" + imageName
            };
            mTC_ImageTab.TabPages.Add(t);
            PictureBox it = new PictureBox()
            {
                Name = "pb_" + imageName,
            };
            var tp = mTC_ImageTab.TabPages[t.Name];
            tp.Controls.Add(it);
            tp.BackColor = Color.FromArgb(255, 51, 51, 51);
            htTabImageName.Add(t.Name, it.Name);
            mTC_ImageTab.SelectedTab = tp;
            it.Dock = DockStyle.None;
            it.SizeMode = PictureBoxSizeMode.CenterImage;
            it.Image = initBitmap.Clone() as Image;
            it.Width = it.Image.Width;
            it.Height = it.Image.Height;
            var p = GetControlCenterLocation(tp, it);
            it.Location = p;
            it.Anchor = AnchorStyles.Left|AnchorStyles.Top;
            Point mouse_offset= new Point();
            Point mouse_offset2 = p;

            it.MouseDown += (sender, e) =>
            {
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Move:
                        canDrag = true;
                        mouse_offset.X = -e.X;
                        mouse_offset.Y = -e.Y;
                        break;
                    case Tools.RGB_Pick:
                        var c = ((Bitmap)it.Image).GetPixel(e.X,e.Y);
                        Pick_RGB(c);
                        break;
                }
            };
            it.MouseMove += (sender, e) =>
            {
                it.Cursor = MouseCursor();
                switch (Tool)
                {
                    default:
                    case Tools.Empty:
                        break;
                    case Tools.Move:
                        if (e.Button == MouseButtons.Left&&canDrag)
                        {
                            it.Location =new Point(it.Left + e.X+ mouse_offset.X, it.Top + e.Y+ mouse_offset.Y);
                        }
                        break;
                    case Tools.RGB_Pick:
                        if (e.Button == MouseButtons.Left)
                        {
                            if (e.X > 0 && e.Y > 0&& e.X< it.Image.Width&&e.Y< it.Image.Height)
                            {
                                var c = ((Bitmap)it.Image).GetPixel(e.X, e.Y);
                                Pick_RGB(c);
                            }
                        }
                        break;
                }
            };
            it.MouseUp += (sender, e) =>
            {
                switch (Tool)
                {
                    case Tools.Move:
                        if (e.Button == MouseButtons.Left)
                        {
                            canDrag = false;
                        }
                        break;
                }
            };
        }
        /// <summary>
        /// 获取[里控件]居中于[外控件]时的左上角坐标
        /// </summary>
        /// <param name="outC"></param>
        /// <param name="inC"></param>
        /// <returns></returns>
        private Point GetControlCenterLocation(Control outC,Control inC)
        {
            var x = 0;
            var y = 0;

            var outW = outC.Width;
            var outH = outC.Height;

            var inW = inC.Width;
            var inH = inC.Height;

            x = (outW - inW) / 2;
            y = (outH - inH) / 2;

            x = x > 0 ? x : 0;
            y = y > 0 ? y : 0;

            return new Point(x, y);
        }

        HashSet<string> NameHash = new HashSet<string>();
        private string reName(string name)
        {
            string extension = Path.GetExtension(name);//扩展名
            string fileNameWithoutExtension = Path.GetFileNameWithoutExtension(name);// 没有扩展名的文件名
            if (!NameHash.Add(name))
            {
                return reName(fileNameWithoutExtension, fileNameWithoutExtension, extension, name);
            }
            return name;
        }

        /// <summary>
        /// 重命名
        /// </summary>
        /// <param name="fileNameWithoutExtension">无拓展名的文件名</param>
        /// <param name="original">原始无拓展名的文件名</param>
        /// <param name="extension">拓展名</param>
        /// <param name="name">有拓展名的文件名</param>
        /// <param name="serialNum">序号</param>
        /// <returns></returns>
        private string reName(string fileNameWithoutExtension, string original, string extension, string name, int serialNum = 1)
        {
            name = original + $"({serialNum.ToString()})" + extension;
            serialNum++;
            if (!NameHash.Add(name))
                return reName(fileNameWithoutExtension, original, extension, name, serialNum);
            return name;
        }

        private void btn_Histogram_Click(object sender, EventArgs e)
        {
            Histogramcs hs = new Histogramcs(ResultImage);
            hs.ShowDialog();
        }

        private void btn_Salt_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Salt;
            Probability py = new Probability(this, MousePosition)
            {
                InitBitmap = ResultImage,
            };
            SetImageCallback(SaltNoise(ResultImage));
            py.ShowDialog();
        }

        public void SetImageCallback(Bitmap bitmap)
        {
            ResultImage = bitmap;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GmageConfigXML.XmlHandle.SetPreferences("Conventional", "HomePage", "1");
            Config.homePage = 1;
            Config.bReStart = true;
            Application.Exit();
        }

        private void btn_FaceRecognition_Click(object sender, EventArgs e)
        {
            Config.Model = FunctionType.FaceRecognition;
            if (Path.GetExtension(Config.ClassifierPath) == ".xml")
                ResultImage = Recognite_Face(ResultImage, Config.ClassifierPath);
            else
                MessageBox.Show("请先选择分类器", "错误的预期", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Program.MyArgs.Length > 0)
            {
                RollBackMessage(Program.MyArgs);
            }
            Classifier_Load();
            Change_pB_Color();
        }

        /// <summary>
        /// 
        /// </summary>
        private void Classifier_Load()
        {
            var path = Application.StartupPath + @"\Classifier\";
            config.FloderExist(path);
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
                items.Click += tsmi_Classifier_Click;
                tsmi_Classifier.DropDownItems.Add(items);
            }
        }

        private void AddPagesIndex(string ImageName)
        {
            ToolStripMenuItem items = new ToolStripMenuItem()
            {
                Name = "tsmi_" + ImageName,
                Text = ImageName,
                Tag = "tp_" + ImageName,
                CheckOnClick = true,
            };
            items.Click += tsmi_Index_Click;
            tsmi_Index.DropDownItems.Add(items);
        }

        Config config = new Config();
        private void tsmi_Classifier_Click(object sender, EventArgs e)
        {
            Config.ClassifierPath = (string)((ToolStripMenuItem)sender).Name;
            config.IsCheckedControl((ToolStripMenuItem)sender, tsmi_Classifier);
        }

        private void tsmi_Index_Click(object sender, EventArgs e)
        {
            Config.ClassifierPath = ((ToolStripMenuItem)sender).Name;
            config.IsCheckedControl((ToolStripMenuItem)sender, tsmi_Index);
            mTC_ImageTab.SelectedTab = mTC_ImageTab.TabPages[((ToolStripMenuItem)sender).Tag.ToString()];
        }

        private void CheckonIndex()
        {
            int i = 0;
            foreach (ToolStripMenuItem item in tsmi_Index.DropDownItems)
            {
                if (i++ < tsmi_Index.DropDownItems.Count - 1)
                    continue;
                item.Checked = true; //设选中状态为true
            }
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

        private void Open_Threshold_Config(int hold = 128)
        {
            Process.Threshold ptd = new Process.Threshold(this, MousePosition, hold)
            {
                InitBitmap = ResultImage.Clone() as Bitmap,
            };
            ptd.ShowDialog();
        }

        private void tsmi_About_Click(object sender, EventArgs e)
        {
            
        }

        PictureBox col = new PictureBox();
        private void materialTabSelector1_TabIndexChanged(object sender, EventArgs e)
        {
            ResetBitmap();
        }

        private void ResetBitmap()
        {
            if (mTC_ImageTab.SelectedTab is null)
                return;
            var TabName = mTC_ImageTab.SelectedTab.Name;
            var selectedTabName = (string)htTabImageName[TabName];

            config.IsCheckedControl(tsmi_Index, TabName);
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
                var SelectedTabName = mTC_ImageTab.SelectedTab.Name;
                var TabName = SelectedTabName.Substring(3);
                //使用TabControl控件的TabPages属性的Remove方法移除指定的选项卡
                htTabImageName.Remove(SelectedTabName);
                tsmi_Index.DropDownItems.RemoveByKey("tsmi_" + TabName);
                NameHash.Remove(TabName);
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

        private void mTC_ImageTab_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void mTC_ImageTab_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                RollBackMessage(file);
            }
        }

        private void TsmiClick()
        {
            ToolStripMenuItem[] toolStripMenuItems = new ToolStripMenuItem[] 
            {
                tsmi_Gray,tsmi_Complementary,tsmi_Frequency,
                Clockwise180,Clockwise90,Clockwise270,RotateNoneFlipX,RotateNoneFlipY,
                Tsmi_GaussBlur,tsmi_MedianFilter,tsmi_GaussNoise,tsmi_Smoothed
            };
            foreach (var tsmi in toolStripMenuItems)
            {
                tsmi.Click += (click_sender, click_e) =>
                {
                    Config.Model = (FunctionType)Enum.Parse(typeof(FunctionType), tsmi.Tag.ToString());
                    ResultImage = SwitchFunc(ResultImage);
                };
            }
        }

        private void TsmiThresholdClick()
        {
            ToolStripMenuItem[] toolStripMenuItems = new ToolStripMenuItem[]
            {
               tsmi_Lighten,tsmi_Contrast,tsmi_Binarization,tsmi_Polar,tsmi_Robert,tsmi_Sharpen
            };
            foreach (var tsmi in toolStripMenuItems)
            {
                tsmi.Click += (click_sender, click_e) =>
                {
                    Config.Model = (FunctionType)Enum.Parse(typeof(FunctionType), tsmi.Tag.ToString());
                    //ResultImage = SwitchFunc(initBitmap);
                    Open_Threshold_Config(0);
                };
            }
        }

        private void tsmi_Clear_Click(object sender, EventArgs e)
        {
            ResultImage = initBitmap.Clone() as Bitmap ;
        }

        private void tsmi_Preferences_Click(object sender, EventArgs e)
        {
            Preferences preferences = new Preferences();
            preferences.ShowDialog();
        }
        #endregion

        #region 拾色器
#region 调色板
        private void pB_Color_Click(object sender, EventArgs e)
        {
            ColorDialog dlgColor = new ColorDialog();
            if (dlgColor.ShowDialog() == DialogResult.OK)
            {
                var c = dlgColor.Color;
                pB_Color.BackColor = c;
                Color_R = c.R;
                Color_G = c.G;
                Color_B = c.B;
            }
        }

        public int Color_R
        {
            get
            {
                int.TryParse(mT_R.Text, out int r);
                if (r > 255)
                    r = 255;
                if (r < 0)
                    r = 0;
                mT_R.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_R.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_R.Text = 0.ToString();
                    return;
                }
                mT_R.Text = value.ToString();
            }
        }
        public int Color_G
        {
            get
            {
                int.TryParse(mT_G.Text,out int r);
                if (r > 255)
                    r = 255;
                if (r < 0)
                    r = 0;
                mT_G.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_G.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_G.Text = 0.ToString();
                    return;
                }
                mT_G.Text = value.ToString();
            }
        }

        public int Color_B
        {
            get
            {
                int.TryParse(mT_B.Text, out int r);
                if (r > 255)
                   r= 255;
                if (r < 0)
                   r= 0;
                mT_B.Text = r.ToString();
                return r;
            }
            set
            {
                if (value > 255)
                {
                    mT_B.Text = 255.ToString();
                    return;
                }
                if (value < 0)
                {
                    mT_B.Text = 0.ToString();
                    return;
                }
                mT_B.Text = value.ToString();
            }
        }

        private void SetColorRGB()
        {
            mT_R.TextChanged += (sender, e) =>
            {
                tB_R.Value = Color_R;
                Change_pB_Color();
            };

            mT_G.TextChanged += (sender, e) =>
            {
                tB_G.Value = Color_G;
                Change_pB_Color();
            };

            mT_B.TextChanged += (sender, e) =>
            {
                tB_B.Value = Color_B;
                Change_pB_Color();
            };


            mT_R.KeyPress += InputLimit;

            mT_G.KeyPress += InputLimit;

            mT_B.KeyPress += InputLimit;

            tB_R.Scroll += (sender, e) =>
             {
                 Color_R = tB_R.Value;
             };

            tB_G.Scroll += (sender, e) =>
            {
                Color_G = tB_G.Value;
            };

            tB_B.Scroll += (sender, e) =>
            {
                Color_B = tB_B.Value;
            };

        }

        private void InputLimit(object sender, KeyPressEventArgs e)
        {
            if (((int)e.KeyChar < 48 && (int)e.KeyChar != 8) || ((int)e.KeyChar > 57))
            {
                e.Handled = true;
            }
        }

        private void Change_pB_Color()
        {
            pB_Color.BackColor = Color.FromArgb(Color_R, Color_G, Color_B);
        }

        #endregion

        #region 鼠标拾色
        Point p = MousePosition;
        
        private void Pick_RGB(Color c)
        {
            Color_R = c.R;
            Color_G = c.G;
            Color_B = c.B;
        }



        #endregion
        #endregion

        #region 左边工具栏
        private void ToolsClickEvent()
        {
            MaterialFlatButton[] flatButtons = new MaterialFlatButton[] { mFB_Select, mFB_ColorPicker, mFB_Move };
            foreach (var flatButton in flatButtons)
            {
                flatButton.Click += (sender, e) =>
                {
                    Tool = (Tools)Enum.Parse(typeof(Tools), flatButton.Tag.ToString());
                };
            }
        }

        private System.Windows.Forms.Cursor MouseCursor()
        {
            switch (Tool)
            {
                default:
                case Tools.Empty:
                    return Cursors.Default;
                case Tools.Move:
                    return Cursors.Hand;
                case Tools.Cut:
                case Tools.RGB_Pick:
                    return Cursors.Cross;
            }
        }
        #endregion


    }

    public enum Tools
    {
        Empty,
        Move,
        Cut,
        RGB_Pick,
    }
}
