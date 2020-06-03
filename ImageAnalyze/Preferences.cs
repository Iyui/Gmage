using System;
using System.Windows.Forms;
using GmageConfigXML;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Drawing;
using System.IO;
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
        }

        private void SetPreferences()
        {
            Config.homePage = HomePageIndex;
            SetPreferences("Conventional", "HomePage", HomePageIndex.ToString());
            SetPreferences("Conventional", "Theme", DarkTheme.ToString().ToLower());
            SetPreferences("Conventional", "Batch_ChildIndex", Batch_ChildIndex.ToString().ToLower());
            
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
        }

        private void Preferences_Load(object sender, EventArgs e)
        {
            LoadPreferences();
        }

        private void Preferences_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void Load_Classifier_Plugin()
        {
            foreach(var c in Config.Classifier)
            {
                var name = Path.GetFileNameWithoutExtension(c);
                lB_Classifier.Items.Add(name);
            }
            foreach (var c in Config.PluginList)
            {
                var name = Path.GetFileNameWithoutExtension(c);

                lB_Plugin.Items.Add(name);
            }
            
        }

        private void mFB_OK_Click(object sender, EventArgs e)
        {
            SetPreferences();
        }
    }
}
