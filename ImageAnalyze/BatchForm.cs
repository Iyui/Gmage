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
using System.IO;
using System.Threading;
using static Gmage.ImageProcess;
namespace Gmage
{
    public partial class BatchForm : MaterialForm
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
                case MessageType.ImageInfo:
                    break;
                case MessageType.PrgressInfo:
                    mL_Remain.Text = "转换剩余："+e.Progress.ToString();
                    if((int)e.Progress==0)
                        mL_Remain.Text = "转换剩余：" + "已完成";
                    break;
            }
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

        

        private readonly MaterialSkinManager materialSkinManager;
        private string INputPath;
        private string OUTputPath;
        List<string> ImagePaths = new List<string>();
        public BatchForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            RollBack.messageClass.OnMessageSend += new MessageEventHandler(SubthreadMessageReceive);
        }


        private void SetDarkStyle()
        {
            Control[] controls = new Control[] { gB_Task, groupBox1, pB_View, dGV_Paths, gB_View2 };
            foreach (var control in controls)
            {
                control.ForeColor = ((int)TextShade.WHITE).ToColor();
            }
              dGV_Paths.BackgroundColor = Color.FromArgb(255, 51, 51, 51);
              mPB_Progress.BackColor = Color.FromArgb(255, 51, 51, 51);
        }

        private void BatchForm_Load(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Empty;
           // OUTputPath = Application.StartupPath;
            ImageTouch.lastPath = OUTputPath;
            mL_Output.Text = "输出至：" + OUTputPath;
            SetDarkStyle();
        }

        private void mFB_Output_Click(object sender, EventArgs e)
        {
            OUTputPath = ImageTouch.GetFolderPath();
            mL_Output.Text = "输出至：" + OUTputPath;
        }

        private void mFB_Index_Click(object sender, EventArgs e)
        {
           // LoadForm lf = new LoadForm();
           // lf.Show();
            ImagePaths = ImageTouch.GetImagePath();
            if (ImagePaths is null)
                return;
            for (int i = 0; i < ImagePaths.Count; i++)
            {
                object[] row = {
                           ImagePaths[i]};
                dGV_Paths.Rows.Insert(i, row);
                dGV_Paths.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 51, 51, 51);
                RollBack.RollBackMessage((ImagePaths.Count - i).ToString(), MessageType.Loading);
            }
            mL_Count.Text = "图片总计："+ ImagePaths.Count.ToString();
            //lf.Close();
        }

        private void mFB_AddTask_Click(object sender, EventArgs e)
        {
            BatchModel bm = new BatchModel();
            if(bm.ShowDialog()==DialogResult.OK)
            {
                mL_Task.Text = "任务名称：" + bm.ModelName;
            }
        }

        private void mFB_StartTask_Click(object sender, EventArgs e)
        {
            if (Config.Model == FunctionType.Empty)
                MessageBox.Show("请选择处理任务");
            else
            {
                Thread td = new Thread(new ParameterizedThreadStart(ImageTouch.Batch));
                td.Start(OUTputPath);
                //MessageBox.Show("转化完成");
            }
        }

        private void BatchForm_Resize(object sender, EventArgs e)
        {
            //this.Size = new Size(917, 534);
        }

        private void mLV_ImgInfo_ColumnWidthChanging(object sender, ColumnWidthChangingEventArgs e)
        {
           
        }

        private void mLV_ImgInfo_ColumnWidthChanged(object sender, ColumnWidthChangedEventArgs e)
        {

        }

        private void mLV_ImgInfo_ColumnWidthChanging_1(object sender, ColumnWidthChangingEventArgs e)
        {
        }

        private void mFB_OpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", OUTputPath);
        }

        private void dGV_Paths_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            GC.Collect();
            var path = dGV_Paths.SelectedCells[0].Value.ToString();
            var image = Image.FromFile(path);
            pB_View.Image = image;
            pB_View2.Image = SwitchFunc(image.Clone() as Bitmap); 
        }

        private void dGV_Paths_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            GC.Collect();
            var path = dGV_Paths.SelectedCells[0].Value.ToString();
            ClickOpenLocation(path);
        }

        public void ClickOpenLocation(string location)
        {
            System.Diagnostics.Process.Start("Explorer", "/select," + @location);
        }
    }

    public static class ImageTouch
    {
        public static List<string> ImagePath
        {
            get=> _ImagePath;
        }
        static List<string> _ImagePath = new List<string>();
        public static string FolderPath
        {
            set; get;
        }
        public static string lastPath;
        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="hint"></param>
        /// <returns></returns>
        public static string GetFolderPath()
        {
            string Path = lastPath;
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            if (lastPath != "")
                dialog.SelectedPath = lastPath;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                lastPath = dialog.SelectedPath;
                if (string.IsNullOrEmpty(dialog.SelectedPath))
                {
                    MessageBox.Show("文件夹路径不能为空", "提示");
                    return "";
                }
                Path = dialog.SelectedPath;
                lastPath = Path;
            }
            return Path;
        }

        public static List<string> GetImagePath()
        {
            FolderPath = "";
            FolderPath = GetFolderPath();
            if (FolderPath == "")
            {
                //MessageBox.Show("文件夹路径不能为空", "提示");
                return null;
            }
            var files = Directory.GetFiles(FolderPath, "*.jpg");
            for (int i = 0; i < files.Count(); i++)
            {
                var imgpath = files[i];
                _ImagePath.Add(imgpath);
            }
            return _ImagePath;
        }

        /// <summary>
        /// 批量处理
        /// </summary>
        public static void Batch(object SavePath)
        {
            var path = ImagePath;
            for (int i = 0; i < path.Count; i++)
            {
                var image =  (Bitmap)Image.FromFile(path[i]);
                var TouchedImage = SwitchFunc(image).Clone() as Bitmap ;
                TouchedImage.Save(SavePath+"\\"+ Path.GetFileName(ImagePath[i]));
                RollBack.RollBackMessage((i+1) / path.Count * 100f);
                RollBack.RollBackMessage(path.Count- (i + 1),MessageType.PrgressInfo);
                TouchedImage.Dispose();
                GC.Collect();
            }
        }

       
    }
}
