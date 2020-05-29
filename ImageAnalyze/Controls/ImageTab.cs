using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmage.Controls
{
    public partial class ImageTab : UserControl
    {
        public ImageTab()
        {
            InitializeComponent();
        }

        public Image Image
        {
            set => pB_Init.Image = value;
            get => pB_Init.Image;
        }

        public string PictureBoxName
        {
            set => pB_Init.Name= value;
            get => pB_Init.Name;

        }

        public Color TabBackColor
        {
            set => BackColor = value;
            get => BackColor;
        }
    }
}
