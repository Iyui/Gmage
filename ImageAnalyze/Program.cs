using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using GmageIF;
using System.IO;
using System.Reflection;
using System.Drawing;

namespace Gmage
{
    internal static class Program
    {
        internal static string[] MyArgs;
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            MyArgs = args;
            GmageConfigXML.XmlHandle.LoadGmageConfig();
            Config.Read_Init_Preferences();
            Config.Pack();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Config.bReStart = false;
            switch (Config.homePage)
            {
                default:
                case 0:
                    var mf = new MainForm();
                    ReadPlug_in(mf);
                    Application.Run(mf);
                    break;
                case 1:
                    Application.Run(new BatchForm());
                    break;     
            }
            GmageConfigXML.XmlHandle.SaveGmageConfig();
            Restart();
        }

        private static void Restart()
        {
            try
            {
                if (true == Config.bReStart)
                {
                    System.Diagnostics.Process.Start(Application.ExecutablePath); 
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("软件配置参数错误.信息:\r\n" + ex.Message);
            }
        }


        internal static void ReadPlug_in(MainForm mf)
        {
            Config cf = new Config();
            var path = Application.StartupPath + "\\plug_in\\";
            if (!cf.FloderExist(path))
                return;
            //搜索某路径下所有dll
            foreach (string fn in Directory.GetFiles(path, "*.dll"))
            {
                try
                {
                    //获取程序集
                    Assembly ass = Assembly.LoadFrom(fn);
                    //遍历包含的类型
                    foreach (Type t in ass.GetTypes())
                    {
                        //判断是否是实现了插件接口
                        if (t.GetInterface("IGmage", true) != null)
                        {
                            Config.PluginList.Add(fn);
                            //创建实例
                            object o = ass.CreateInstance(t.ToString());
                            //执行方法
                            Set_MenuItem(mf, o, t);
                        }
                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show($"插件加载失败，插件名{Path.GetFileName(fn)}");  
                }
            }
            Classifier_Load(cf);
        }

        /// <summary>
        /// 设置菜单栏按键
        /// </summary>
        /// <param name="tsmi">按键实例</param>
        /// <param name="mf">窗体</param>
        /// <param name="o">插件实例</param>
        /// <param name="t"></param>
        internal static void Set_MenuItem(MainForm mf, object o, Type t)
        {
            //获取方法
            MethodInfo filter = t.GetMethod("GMage_Filter");
            MethodInfo item = t.GetMethod("Set_ToolStripMenuItem");
            var tsmi = (ToolStripMenuItem)item.Invoke(o, null);
            tsmi.Click += (click_sender, click_e) =>
            {
                t.GetProperty("InitBitmap").SetValue(o, mf.ResultImage);
                mf.ResultImage = (Bitmap)filter.Invoke(o, null);      
            };
            mf.tsmi_Filter.DropDownItems.Add(tsmi);
        }

        private static void Classifier_Load(Config cf)
        {
            var path = Application.StartupPath + @"\Classifier\";
            cf.FloderExist(path);
            DirectoryInfo dir = new DirectoryInfo(path);
            FileInfo[] fi = dir.GetFiles();
            if (fi.Length == 0)
                return;
            foreach (var f in fi)
            {
                Config.Classifier.Add(f.FullName);
            }
        }


    }


}
