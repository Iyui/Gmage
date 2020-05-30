using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
namespace GmageIF
{
    public interface IGmage
    {
        string Function_Name
        {
            set;get;
        }
        Bitmap InitBitmap
        {
            set;get;
        }

        Bitmap GMage_Filter();

        ToolStripMenuItem Set_ToolStripMenuItem();

    }
}
