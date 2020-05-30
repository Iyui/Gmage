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
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            var mf = new MainForm();
            ReadPlug_in(mf);
            Application.Run(mf);
        }

        internal static void ReadPlug_in(MainForm mf)
        {
            //搜索某路径下所有dll
            foreach (string fn in Directory.GetFiles(Application.StartupPath+"\\plug_in\\", "*.dll"))
            {
                //获取程序集
                Assembly ass = Assembly.LoadFrom(fn);
                //遍历包含的类型
                foreach (Type t in ass.GetTypes())
                {
                    //判断是否是实现了插件接口
                    if (t.GetInterface("IGmage",true) !=null)
                    {
                        //创建实例
                        object o = ass.CreateInstance(t.ToString());   
                        //执行方法
                        Set_MenuItem(mf,o,t);
                    }
                }
            }
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
    }
}
