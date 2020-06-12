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
                case MessageType.BatchError:
                    mL_Error.Text = "转换失败：" + e.Message;
                    break;
                case MessageType.BatchDeadlyError:
                    Finished();
                    MessageBox.Show(e.Message, "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case MessageType.Progress:
                    if ((int)e.Progress < 100)
                    {
                        mPB_Progress.Visible = true;
                        mPB_Progress.Value = (int)e.Progress;
                    }
                    else
                    {
                        Finished();
                        mPB_Progress.Visible = false;
                    }
                    break;
                case MessageType.ImageInfo:
                    mL_Count.Text = "图片总计：" + ImageTouch.ImagePath.Count.ToString();
                    break;
                case MessageType.PrgressInfo:
                    mL_Remain.Text = "转换剩余：" + e.Progress.ToString();
                    if ((int)e.Progress == 0)
                    {
                        Finished();
                        mL_Remain.Text = "转换剩余：" + "已完成";
                    }
                    break;
                case MessageType.PathTable:
                    dGV_Paths.DataSource = (DataTable)e.oMessage;
                    mL_Count.Text = "图片总计：" + ImageTouch.ImagePath.Count.ToString();
                    dGV_Paths.Refresh();
                    if (ImageTouch.ImagePath.Count > 0)
                        mFB_RemoveImg.Enabled = true;
                    else
                        mFB_RemoveImg.Enabled = false;
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
        private string OUTputPath;
        DataTable dt = new DataTable();
        HashSet<string> ImagePaths = new HashSet<string>();

        public bool TaskFinished
        {
            set => mFB_StartTask.Enabled = value; get => mFB_StartTask.Enabled;
        }
        public BatchForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
            RollBack.messageClass.OnMessageSend += new MessageEventHandler(SubthreadMessageReceive);
            ImageTouch.ImagePath = new HashSet<string>();
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
            dGV_Paths.DefaultCellStyle.BackColor = Color.FromArgb(255, 51, 51, 51);
        }

        private void BatchForm_Load(object sender, EventArgs e)
        {
            Config.Model = FunctionType.Empty;
            // OUTputPath = Application.StartupPath;
            ImageTouch.lastPath = OUTputPath;
            mL_Output.Text = "输出至：" + OUTputPath;
            dt.Columns.Add("路径");
            SetDarkStyle();
        }

        private void mFB_Output_Click(object sender, EventArgs e)
        {
            OUTputPath = ImageTouch.GetFolderPath(true);
            if (Directory.Exists(OUTputPath))
                mFB_OpenFolder.Enabled = true;
            mL_Output.Text = "输出至：" + OUTputPath;
        }

        private void mFB_Index_Click(object sender, EventArgs e)
        {
            var paths = ImageTouch.GetImagePath(false);
            if (paths is null)
                return;
            ThreadSetPathView();
        }

        private void ThreadSetPathView()
        {
            Thread thread = new Thread(SetPathView);
            thread.Start();
        }

        private void ThreadSetPathView(string[] hs)
        {
            Thread thread = new Thread(new ParameterizedThreadStart(SetDropPathView));
            thread.Start(hs);
        }

        private void SetDropPathView(object hs)
        {
            foreach (var s in (string[])hs)
            {
                if (ImageTouch.ImagePath.Add(s) && ImagePaths.Add(s))
                    dt.Rows.Add(s);
            }
            RollBack.RollBackMessage(dt, MessageType.PathTable);
        }

        private void SetPathView()
        {
            foreach (var s in ImageTouch.ImagePath)
            {
                if (ImagePaths.Add(s))
                {
                    dt.Rows.Add(s);
                }
            }
            RollBack.RollBackMessage(dt, MessageType.PathTable);
        }

        private void mFB_AddTask_Click(object sender, EventArgs e)
        {
            BatchModel bm = new BatchModel();
            if (bm.ShowDialog() == DialogResult.OK)
            {
                mL_Task.Text = "任务名称：" + bm.ModelName;
            }
        }

        private void mFB_StartTask_Click(object sender, EventArgs e)
        {
            if (!TaskFinished)
            {
                RollBack.RollBackMessage("任务正在进行", MessageType.BatchDeadlyError);
                return;
            }
            else
            {
                TaskFinished = false;
            }
            if (Config.Model == FunctionType.Empty)
            {
                RollBack.RollBackMessage("请选择处理任务", MessageType.BatchDeadlyError);
                return;
            }
            else
            {
                Thread td = new Thread(new ParameterizedThreadStart(ImageTouch.Batch));
                if (string.IsNullOrEmpty(OUTputPath))
                {
                    RollBack.RollBackMessage("请选择输出文件夹", MessageType.BatchDeadlyError);
                    return;
                }
                td.Start(OUTputPath);
            }
        }

        private void Finished()
        {
            TaskFinished = true;
        }

        private void mFB_OpenFolder_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("explorer.exe", OUTputPath);
        }

        private void dGV_Paths_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dGV_Paths.CurrentRow.DefaultCellStyle.ForeColor != Color.Gray)
            {
                mFB_RemoveImg.Enabled = true;
            }
            var path = dGV_Paths.SelectedCells[0].Value.ToString();
            Image image = new Bitmap(1, 1);
            try
            {
                image = Image.FromFile(path);
            }
            catch
            {

            }
            finally
            {
                pB_View.Image = image;
                pB_View2.Image = SwitchFunc(image.Clone() as Bitmap);
            }
            GC.Collect();
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

        private void mFB_Image_Click(object sender, EventArgs e)
        {
            OpenFileDialog oi = new OpenFileDialog
            {
                //oi.InitialDirectory = "c:\\";
                Filter = "图片(*.jpg,*.jpeg,*.gif,*.bmp) | *.jpg;*.jpeg;*.gif;*.bmp| 所有文件(*.*) | *.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (oi.ShowDialog() == DialogResult.OK)
            {
                var filename = oi.FileName;
                if (ImageTouch.ImagePath.Add(filename))
                {
                    ImagePaths.Add(filename);
                    dt.Rows.Add(filename);
                    RollBack.RollBackMessage(dt, MessageType.PathTable);
                }
            }

        }

        private void mFB_ClearImg_Click(object sender, EventArgs e)
        {
            dt = new DataTable();
            dt.Columns.Add("路径");
            ImageTouch.Clear();
            ImagePaths.Clear();
            RollBack.RollBackMessage(dt, MessageType.PathTable);
        }

        private void mFB_RemoveImg_Click(object sender, EventArgs e)
        {
            var presentItem = "";
            int index = -1;
            foreach (DataGridViewCell presentItems in dGV_Paths.SelectedCells)
            {
                presentItem = presentItems.Value.ToString();
                index = presentItems.RowIndex;
                if (dGV_Paths.Rows[index].DefaultCellStyle.ForeColor != Color.Gray)
                {
                    ImageTouch.ImagePath.Remove(presentItem);
                    ImagePaths.Remove(presentItem);
                    dGV_Paths.Rows[index].DefaultCellStyle.ForeColor = Color.Gray;
                }
                else
                {
                    ImageTouch.ImagePath.Add(presentItem);
                    ImagePaths.Add(presentItem);
                    dGV_Paths.Rows[index].DefaultCellStyle.ForeColor = Color.White;
                }
            }
            RollBack.RollBackMessage(null, MessageType.ImageInfo);
            GC.Collect();
        }

        private void dGV_Paths_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                ThreadSetPathView(file);
            }
        }

        private void dGV_Paths_DragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void mFB_HomePage_Click(object sender, EventArgs e)
        {
            GmageConfigXML.XmlHandle.SetPreferences("Conventional", "HomePage","0");
            Config.homePage = 0;
            Config.bReStart = true;
            Application.Exit();
        }
    }

    public static class ImageTouch
    {
        public static HashSet<string> ImagePath
        {
            set => _ImagePath = value; get => _ImagePath;
        }
        static HashSet<string> _ImagePath = new HashSet<string>();
        public static string FolderPath
        {
            set; get;
        }
        public static string lastPath;
        /// <summary>
        /// 获取文件夹路径
        /// </summary>
        /// <param name="ShowNewFolderButton">是否显示新建文件夹按钮</param>
        /// <returns></returns>
        public static string GetFolderPath(bool ShowNewFolderButton)
        {
            string Path = lastPath;
            FolderBrowserDialog dialog = new FolderBrowserDialog()
            {
                ShowNewFolderButton = ShowNewFolderButton,
            };
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
                return Path;
            }
            return "";

        }

        public static HashSet<string> GetImagePath(bool ShowNewFolderButton = true)
        {
            FolderPath = "";
            FolderPath = GetFolderPath(ShowNewFolderButton);
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

        private static int BatchErrorCount = 0;
        /// <summary>
        /// 批量处理
        /// </summary>
        public static void Batch(object SavePath)
        {
            BatchErrorCount = 0;
            if (ImagePath.Count == 0)
            {
                RollBack.RollBackMessage("至少需要选择一张图片", MessageType.BatchDeadlyError);
                return;
            }
            var path = ImagePath.ToList();
            for (int i = 0; i < path.Count; i++)
            {
                try
                {
                    var image = (Bitmap)Image.FromFile(path[i]);
                    var TouchedImage = Config.graphCommand.Execute(Config.Model, image,false);

                    TouchedImage.Save(SavePath + "\\" + Path.GetFileName(path[i]));
                    TouchedImage.Dispose();
                    GC.Collect();
                }
                catch
                {
                    BatchErrorCount++;
                    RollBack.RollBackMessage(BatchErrorCount.ToString(), MessageType.BatchError);
                }
                finally
                {
                    RollBack.RollBackMessage((i + 1) / path.Count * 100f);
                    RollBack.RollBackMessage(path.Count - (i + 1), MessageType.PrgressInfo);
                }
            }
        }

        public static void Clear()
        {
            _ImagePath.Clear();
        }
    }
}
