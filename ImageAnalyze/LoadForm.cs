using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Threading;
namespace Gmage
{
    public partial class LoadForm : MaterialForm
    {
        /// <summary>
        /// 消息处理
        /// </summary>
        /// <param name="e"></param>
        private void MessageManage(MessageEventArgs e)
        {
            switch (e.messageType)
            {
                case MessageType.ImageReading:
                    break;
                case MessageType.RunTime:
                    break;
                case MessageType.Loading:
                    mL_load.Text ="正在加载：" +e.Message;
                    break;
                case MessageType.Error:
                    break;
                case MessageType.DeadlyError:
                    MessageBox.Show(e.Message, "致命错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Progress:
                    if ((int)e.Progress < 100)
                    {
                        mPB_Progress.Visible = true;
                        mPB_Progress.Value = (int)e.Progress;
                    }
                    else
                        mPB_Progress.Visible = false;
                    break;
               
            }
        }
        public LoadForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            RollBack.messageClass.OnMessageSend += new MessageEventHandler(SubthreadMessageReceive);
        }
        private readonly MaterialSkinManager materialSkinManager;

        private void LoadForm_Load(object sender, EventArgs e)
        {

        }

        private void SubthreadMessageReceive(MessageEventArgs e)
        {
            try
            {
                if (this.IsHandleCreated && !this.IsDisposed)
                {
                    MessageEventHandler handler = new MessageEventHandler(MessageManage);
                    this.Invoke(handler, new object[] { e });
                }
            }
            catch (Exception)
            {
                //throw new Exception("", ex);
            }
        }
    }
}
