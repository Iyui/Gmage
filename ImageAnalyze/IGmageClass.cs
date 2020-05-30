using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmageIF;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Windows.Forms;
using Gmage;

namespace ImageAnalyze
{
    internal class IGmageClass
    {
        internal void ReadExpansionDll()
        {
            //搜索某路径下所有dll
            foreach (string fn in Directory.GetFiles(@"\expansion\", "*.dll"))
            {
                //获取程序集
                Assembly ass = Assembly.LoadFrom(fn);
                //遍历包含的类型
                foreach (Type t in ass.GetTypes())
                {
                    //判断是否是实现了插件接口
                    if (t.GetInterface("IGmage") == typeof(IGmage))
                    {
                        //创建实例
                        object o = ass.CreateInstance(t.ToString());
                        //获取方法
                        MethodInfo mi = t.GetMethod("Mage");
                        //执行方法
                        mi.Invoke(o, new object[] { new Bitmap(1,1) });
                    }
                }
            }
        }

        internal void Set_ToolStripMenuItem(MainForm f)
        {
            string IName = "接口测试";
            ToolStripMenuItem items = new ToolStripMenuItem()
            {
                Name = "tsmi_" + IName,
                Text = IName,
                Tag = "tp_" + IName,
            };
            //items.Click += tsmi_Index_Click;
            f.滤镜ToolStripMenuItem.DropDownItems.Add(items);
        }
    }
}
