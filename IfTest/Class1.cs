using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmageIF;
using System.Drawing;
using System.Windows.Forms;

namespace GmageIF
{
    public class IfTestClass : IGmage
    {

        public string Function_Name
        {
            set; get;
        }
        public Bitmap InitBitmap
        {
            set; get;
        }

        /// <summary>
        /// 操作方法
        /// </summary>
        /// <returns></returns>
        public Bitmap GMage_Filter()
        {
            var bitmap = InitBitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bitmap;
        }

        public ToolStripMenuItem Set_ToolStripMenuItem()
        {
            string IName = "接口测试";
            ToolStripMenuItem item = new ToolStripMenuItem()
            {
                Name = "tsmi_" + IName,
                Text = IName,
                Tag = "tp_" + IName,
            };
            return item;
        }
    }
}
