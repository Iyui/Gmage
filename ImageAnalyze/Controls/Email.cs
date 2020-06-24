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
    public partial class Email : Form
    {
        public Email()
        {
            InitializeComponent();
        }

        private void btn_Send_Click(object sender, EventArgs e)
        {
            try
            {
                program.UpSqlData(textBox1.Text, Config.HashId, Config.DiskId);
            }
            catch { };
            SendMailLocalhost();
        }
        iyui.sql.Program program = new iyui.sql.Program();

        public void SendMailLocalhost()
        {
            
            if (program.SendMail(textBox1.Text, $"[{textBox2.Text}][{_ip}]从Gmage发来的信件"))
                MessageBox.Show("发送成功");
            else
                MessageBox.Show("发送失败");

        }

        private void button1_Click(object sender, EventArgs e)
        {
        
        }
        string _ip = "";
        private void Email_Load(object sender, EventArgs e)
        {
            
            if (program.isLimit("邮箱"))
            {
                try
                {
                    _ip = iyui.sql.Program.GetIpv4();
                }
                catch { };
            }
            else
            {
                MessageBox.Show("未能成功连接到服务器");
                this.Close();
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MessageCenter messageCenter = new MessageCenter();
            messageCenter.Show();
        }
    }
}
