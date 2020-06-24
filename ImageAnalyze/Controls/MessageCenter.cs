using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gmage.Controls
{
    public partial class MessageCenter : Form
    {
        public MessageCenter()
        {
            InitializeComponent();
        }

        private void MessageCenter_Load(object sender, EventArgs e)
        {
            iyui.sql.Program program = new iyui.sql.Program();
            program.ConditionQuery(dataGridView1, Config.DiskId, Config.HashId);
        }
    }
}
