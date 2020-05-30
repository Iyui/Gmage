using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GmageIF;
using System.Drawing;

namespace GmageIF
{
    public class IfTestClass : IGmage
    {
        public Bitmap Mage(Bitmap bitmap)
        {
            return bitmap;
        }
    }
}
