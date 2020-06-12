using System;
using System.Windows.Forms;
using GmageConfigXML;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;
using System.IO;
using System.Collections.Generic;
namespace Gmage
{
    public partial class Preferences : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        #region 属性
        public int HomePageIndex
        {
            set => cB_FirstForm.SelectedIndex = value;
            get => cB_FirstForm.SelectedIndex;
        }

        public bool DarkTheme
        {
            set=> mRB_Dark.Checked = value; get=> mRB_Dark.Checked;
        }

        public bool Batch_ChildIndex
        {
            set => MCB_ChildIndex.Checked = value;
            get => MCB_ChildIndex.Checked;
        }

        public bool WindowStateMax
        {
            set => mCB_WindowStateMax.Checked = value;
            get => mCB_WindowStateMax.Checked;
        }
        #endregion

        public Preferences()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            materialSkinManager.ColorScheme =
                new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900,
                Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            cB_FirstForm.BackColor = ((int)Primary.BlueGrey900).ToColor();
            lB_Plugin.BackColor = Color.FromArgb(255, 51, 51, 51);
            lB_Classifier.BackColor = Color.FromArgb(255, 51, 51, 51);
            Load_Classifier_Plugin();
            mFB_AddClassifier.Click += (sender, e) =>
            {
                string filter = "级联分类器(*.xml) | *.xml";
                AddClassifierAndPlugin(filter, true);
            };
            mFB_AddPlugin.Click += (sender, e) =>
            {
                string filter = "Gmage插件(*.dll) | *.dll";
                AddClassifierAndPlugin(filter, false);
            };

            mFB_DelClassifier.Click += (sender, e) =>
            {
                var fileName = (string)lB_Classifier.SelectedItem;
                if (fileName is null)
                    return;
                string filePath = DicNamePath[fileName];
                DelDicNamePathKeyValue(filePath, fileName);
            };
            mFB_DelPlugin.Click += (sender, e) => 
            {
                //var fileName = (string)lB_Plugin.SelectedItem;
                //if (fileName is null)
                //    return;
                //string filePath = DicNamePath[fileName];
                //DelDicNamePathKeyValue(filePath, fileName);
                MessageBox.Show("暂不支持热插拔插件");
            };
        }

        private void SetPreferences()
        {
            Config.homePage = HomePageIndex;
            SetPreferences("Conventional", "HomePage", HomePageIndex.ToString());
            SetPreferences("Conventional", "Theme", DarkTheme.ToString().ToLower());
            SetPreferences("Conventional", "HomePage", HomePageIndex.ToString());
            SetPreferences("Conventional", "WindowState", WindowStateMax.ToString().ToLower());
        }

        private void SetPreferences(string val1, string val2, string val3)
        {
            XmlHandle.SaveControlValue("Preferences", val1, val2, val3);
        }



        private void LoadPreferences()
        {
            HomePageIndex = Config.homePage;
            DarkTheme = bool.Parse(XmlHandle.LoadPreferences("Conventional", "Theme", "true"));
            mRB_LIght.Checked = !DarkTheme;
            Batch_ChildIndex = bool.Parse(XmlHandle.LoadPreferences("Conventional", "Batch_ChildIndex", "false"));
            WindowStateMax = Config.WindowStateMax;
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            LoadPreferences();
        }

        private void Preferences_FormClosing(object sender, FormClosingEventArgs e)
        {

        }
        Dictionary<string, string> DicNamePath = new Dictionary<string, string>();
        private void Load_Classifier_Plugin()
        {
            foreach(var c in Config.Classifier)
            {
                var name = Path.GetFileNameWithoutExtension(c);
                lB_Classifier.Items.Add(name);
                DicNamePathKeyValue(name, c);
            }
            foreach (var c in Config.PluginList)
            {
                var name = Path.GetFileNameWithoutExtension(c);
                lB_Plugin.Items.Add(name);
                DicNamePathKeyValue(name, c);
            }
        }

        private void mFB_OK_Click(object sender, EventArgs e)
        {
            SetPreferences();
        }

        private void AddClassifierAndPlugin(string filter,bool Classifier)
        {

            OpenFileDialog oi = new OpenFileDialog
            {
                Filter = filter,
                RestoreDirectory = true,
                FilterIndex = 1,
                Multiselect = true,
            };
            string root = Application.StartupPath + "\\";
            if (Classifier)
                root += "\\Classifier\\";
            else
                root += "\\plug_in\\";
            if (oi.ShowDialog() == DialogResult.OK)
            {
                foreach (var file in oi.FileNames)
                {
                    try
                    {
                        File.Copy(file, root + Path.GetFileName(file), true);
                        var name = Path.GetFileNameWithoutExtension(file);
                        if (Classifier)
                            lB_Classifier.Items.Add(name);
                        else
                            lB_Plugin.Items.Add(name);
                        DicNamePathKeyValue(name, root + Path.GetFileName(file));
                    }
                    catch { MessageBox.Show($"{Path.GetFileName(file)}添加失败"); }
                }
            }
        }

        private void DicNamePathKeyValue(string key,string value)
        {
            if (DicNamePath.ContainsKey(key))
                DicNamePath[key] = value;
            else
                DicNamePath.Add(key,value);
        }

        private void DelDicNamePathKeyValue(string filePath, string fileName)
        {
            if (File.Exists(filePath))
            {
                //删除文件
                File.Delete(filePath);
                lB_Plugin.Items.Remove(fileName);
            }
        }
    }
}
