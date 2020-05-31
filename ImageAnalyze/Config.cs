using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
namespace Gmage
{
    public class Config
    {
        public static FunctionType Model;
        public static string ClassifierPath;
        /// <summary>
        /// 设置右键菜单单选
        /// </summary>
        /// <param name="cms">参数-右键可选项类</param>
        public void IsCheckedControl(ToolStripMenuItem cms, ContextMenuStrip contextMenuStrip)
        {
            foreach (ToolStripMenuItem item in contextMenuStrip.Items)
            {
                if (cms.Name == "tsmI_Save")
                    return;
                //不是当前项的取消选择
                if (item.Name == cms.Name)
                {
                    Config.Model = (FunctionType)Enum.Parse(typeof(FunctionType), cms.Tag.ToString());
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

        /// <summary>
        /// 设置右键菜单单选
        /// </summary>
        /// <param name="cms">参数-右键可选项类</param>
        public void IsCheckedControl(ToolStripMenuItem cms, ToolStripMenuItem cmsf)
        {
            foreach (ToolStripMenuItem item in cmsf.DropDownItems)
            {
                //不是当前项的取消选择
                if (item.Name == cms.Name)
                {
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

        /// <summary>
        /// 设置菜单单选
        /// </summary>
        /// <param name="cms">参数-右键可选项类</param>
        public void IsCheckedControl(ToolStripMenuItem cms, string name)
        {
            foreach (ToolStripMenuItem item in cms.DropDownItems)
            {
                //不是当前项的取消选择
                if (item.Tag.ToString() == name)
                {
                    item.Checked = true; //设选中状态为true
                }
                else
                {
                    item.Checked = false; //设选中状态为false
                }
            }
        }

    }



    public enum FunctionType
    {
        /// <summary>
        /// 灰度化
        /// </summary>
        Empty,
        /// <summary>
        /// 灰度化
        /// </summary>
        Gray,
        /// <summary>
        /// 二值化
        /// </summary>
        Binarization,
        /// <summary>
        /// 反色
        /// </summary>
        Complementary,
        /// <summary>
        /// 锐化
        /// </summary>
        Sharpen,
        /// <summary>
        /// 亮度
        /// </summary>
        Lighten,
        /// <summary>
        /// 对比度
        /// </summary>
        Contrast,
        /// <summary>
        /// Robert边缘检测
        /// </summary>
        Robert,
        /// <summary>
        /// Smoothed边缘检测
        /// </summary>
        Smoothed,
        /// <summary>
        /// 椒盐噪声
        /// </summary>
        Salt,
        /// <summary>
        /// 高斯噪声
        /// </summary>
        GaussNoise,
        /// <summary>
        /// 中值滤波
        /// </summary>
        MedianFilter,
        /// <summary>
        /// 高斯平滑
        /// </summary>
        GaussBlur,
        /// <summary>
        /// 极坐标变换
        /// </summary>
        Polar,
        /// <summary>
        /// 傅里叶变换（频率谱）
        /// </summary>
        Frequency,
        /// <summary>
        /// 傅里叶逆变换
        /// </summary>
        BFT,
        /// <summary>
        /// 面部识别
        /// </summary>
        FaceRecognition,
        /// <summary>
        /// 旋转180度
        /// </summary>
        Clockwise180,
        /// <summary>
        /// 旋转90度
        /// </summary>
        Clockwise90,
        /// <summary>
        /// 旋转270度
        /// </summary>
        Clockwise270,
        /// <summary>
        /// 垂直镜像
        /// </summary>
        RotateNoneFlipX,
        /// <summary>
        /// 水平镜像
        /// </summary>
        RotateNoneFlipY,
    }

    public enum MessageType
    {
        ImageReading,
        Message,
        RunTime,
        FolderPath,
        FilePath,
        Error,
        DeadlyError,
        Progress,
        ImageInfo,
        PrgressInfo,
    }

    public class MessageEventArgs : EventArgs
    {
        public MessageType messageType;
        public object oMessage;
        public String Message; //传递字符串信息
        public float Progress;
        public Image imageinfo;
        public string PrgressInfo;
        public string[] FileNames;
        public MessageEventArgs(object obj, MessageType type)
        {
            this.oMessage = obj;
            this.messageType = type;
        }

        public MessageEventArgs(string message, MessageType type = MessageType.Message)
        {
            PrgressInfo = message;
            this.Message = message;
            this.messageType = type;
        }

        public MessageEventArgs(float progress, MessageType type = MessageType.Progress)
        {
            this.Progress = progress;
            this.messageType = type;
        }

        public MessageEventArgs(Image img, MessageType type = MessageType.ImageInfo)
        {
            this.imageinfo = img;
            this.messageType = type;
        }

        public MessageEventArgs(string[] fileNames, MessageType type = MessageType.ImageReading)
        {
            this.FileNames = fileNames;
            this.messageType = type;
        }


    }

    public delegate void MessageEventHandler(MessageEventArgs e);

    public class MessageClass
    {
        public event MessageEventHandler OnMessageSend = null;

        public void MessageSend(MessageEventArgs e)
        {
            OnMessageSend?.Invoke(e);
        }
    }

    public static class RollBack
    {
        public static MessageClass messageClass = new MessageClass();
    }
}
