using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using System.IO;
using System.Xml;
using System.Data;
namespace Gmage
{
    public class Config
    {
        public static FunctionType Model;
        public static string ClassifierPath;
        public static bool bReStart;

        public static int homePage;
        public static bool WindowStateMax;


        public static HashSet<string> PluginList = new HashSet<string>();
        public static HashSet<string> Classifier = new HashSet<string>();
      
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

        public bool FloderExist(string path)
        {
            try
            {
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                return true;
            }
            catch { return false; }
        }

        public static int Read_Init_Preferences()
        {
            var val = GmageConfigXML.XmlHandle.LoadPreferences("Conventional", "HomePage","0");
            var value = int.Parse(val);
            homePage = value;
            WindowStateMax = bool.Parse(GmageConfigXML.XmlHandle.LoadPreferences("Conventional", "WindowState", "false"));
            return value;
        }
    }

    public enum Theme
    {
        Dark,Light,
    }

    public enum HomePage
    {
        Gmage = 1,
        Batch = 2,
    }

    public enum FunctionType
    {
        /// <summary>
        /// 空
        /// </summary>
        Empty,
        /// <summary>
        /// 灰度化
        /// </summary>
        Grey,
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
        /// 指定位图的轮廓图像
        /// </summary>
        Line,
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
        Recognition,
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
        /// <summary>
        /// 腐蚀
        /// </summary>
        Erosion,
        /// <summary>
        /// 膨胀
        /// </summary>
        Swell,
        /// <summary>
        /// 高帽
        /// </summary>
        Tophap,
        /// <summary>
        /// 骨架提取
        /// </summary>
        Skeleton,
        Boundary,
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
        Loading,
        PrgressInfo,
        PathTable,
        History,

        BatchError,
        BatchDeadlyError,
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
        public DataTable PathTable;
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

        public static void RollBackMessage(float pro, MessageType mt = MessageType.Progress)
        {
            messageClass.MessageSend(new MessageEventArgs(pro, mt));
        }

        public static void RollBackMessage(string message, MessageType mt = MessageType.Message)
        {
            messageClass.MessageSend(new MessageEventArgs(message,mt));
        }

        public static void RollBackMessage(object message, MessageType mt = MessageType.Message)
        {
            messageClass.MessageSend(new MessageEventArgs(message, mt));
        }

        public static void RollBackMessage(string[] fileNames)
        {
           messageClass.MessageSend(new MessageEventArgs(fileNames));
        }

    }
}

namespace GmageGeneral
{

    public class FileHandle
    {
        /// <summary>
        /// 打开程序目录下的文件夹,不存在则新建,并返回路径
        /// </summary>
        public static string GetFolderPath(string strFolder)
        {
            string floder = Application.StartupPath + "\\" + strFolder;
            if (!Directory.Exists(floder))
                Directory.CreateDirectory(floder);
            return floder;
        }
    }
}
namespace GmageConfigXML
{
    #region 通用的XML类

    /// <summary>
    /// 通用XML文档对象
    /// </summary>
    public class XmlClass
    {
        private XmlDocument xmlDoc;
        private string strRootNode = "RootNode";    //根节点默认为RootNode

        /// <summary>
        /// 通用XML文档对象
        /// </summary>
        public XmlClass(string strRoot = null)
        {
            if (null == xmlDoc)
            {
                xmlDoc = new XmlDocument();
                XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", null);
                xmlDoc.AppendChild(xmldecl);
                if (strRoot != null && strRoot != "")
                    strRootNode = strRoot;
                XmlElement root = xmlDoc.CreateElement(strRootNode);
                xmlDoc.AppendChild(root);
            }
        }

        public void ClearData()
        {
            XmlNode xmlroot = xmlDoc.SelectSingleNode(strRootNode);
            xmlroot.RemoveAll();
        }

        public void SaveToFile(string strFile)
        {
            xmlDoc.Save(strFile);
        }
        /// <summary>
        /// 加载XML文件,若失败返回false
        /// </summary>
        /// <param name="strFile"></param>
        /// <returns></returns>
        public bool OpenFromFile(string strFile)
        {
            try
            {
                if (File.Exists(strFile))
                {
                    xmlDoc.Load(strFile);
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
                //xmlDoc = null;
            }
        }



        public void SetAttribute(string name, string value, string node1 = null, string node2 = null, string node3 = null)
        {
            XmlElement xmlNode = null;
            if (node1 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode);
            else if (node2 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1);
            else if (node3 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2);
            else
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2 + "/" + node3);
            xmlNode.SetAttribute(name, value);
        }
        public string GetAttribute(string name, string node1 = null, string node2 = null, string node3 = null)
        {
            XmlElement xmlNode = null;
            if (node1 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode);
            else if (node2 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1);
            else if (node3 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2);
            else
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2 + "/" + node3);
            if (null == xmlNode)
                return null;
            else
                return xmlNode.GetAttribute(name);
        }



        public void AddDataValue(string[] nodes, string[,] elements)
        {
            for (int i = 0; i < elements.GetLength(1); i++)
            {
                elements[1, i] = elements[1, i].Replace("(", "-");
                elements[1, i] = elements[1, i].Replace(")", "-");
            }
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode);

            int iEnd = nodes.Length - 1;
            for (int i = 0; i < iEnd; i++)
            {
                XmlNode xmlNodeTmp = xmlNode.SelectSingleNode(nodes[i]);
                if (null == xmlNodeTmp)
                {
                    xmlNodeTmp = xmlDoc.CreateElement(nodes[i]);
                    xmlNode.AppendChild(xmlNodeTmp);
                }
                xmlNode = xmlNodeTmp;
            }

            XmlNode xmlNodeTmpEnd = xmlDoc.CreateElement(nodes[iEnd]);
            xmlNode.AppendChild(xmlNodeTmpEnd);

            for (int i = 0; i < elements.GetLength(1); i++)
            {
                XmlElement xeValue = xmlDoc.CreateElement(elements[0, i]);
                xeValue.InnerText = elements[1, i];
                xmlNodeTmpEnd.AppendChild(xeValue);
            }
        }

        public void AddDataValue(string element, string value, string node1 = null, string node2 = null, string node3 = null)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode);

            if (node1 != null)
            {
                XmlNode xmlNodeTmp = xmlNode.SelectSingleNode(node1);
                if (null == xmlNodeTmp)
                {
                    xmlNodeTmp = xmlDoc.CreateElement(node1);
                    xmlNode.AppendChild(xmlNodeTmp);
                }
                xmlNode = xmlNodeTmp;

                if (node2 != null)
                {
                    xmlNodeTmp = xmlNode.SelectSingleNode(node2);
                    if (null == xmlNodeTmp)
                    {
                        xmlNodeTmp = xmlDoc.CreateElement(node2);
                        xmlNode.AppendChild(xmlNodeTmp);
                    }
                    xmlNode = xmlNodeTmp;

                    if (node3 != null)
                    {
                        xmlNodeTmp = xmlNode.SelectSingleNode(node3);
                        if (null == xmlNodeTmp)
                        {
                            xmlNodeTmp = xmlDoc.CreateElement(node3);
                            xmlNode.AppendChild(xmlNodeTmp);
                        }
                        xmlNode = xmlNodeTmp;
                    }
                }
            }

            XmlElement xeValue = xmlDoc.CreateElement(element);
            xeValue.InnerText = value;
            xmlNode.AppendChild(xeValue);
        }

        public void SetDataValue(string element, string value)
        {
            XmlNode xmlroot = xmlDoc.SelectSingleNode(strRootNode);

            XmlNode xmlelement = xmlroot.SelectSingleNode(element);
            if (null == xmlelement)
            {
                XmlElement xeValue = xmlDoc.CreateElement(element);
                xeValue.InnerText = value;
                xmlroot.AppendChild(xeValue);
            }
            else
            {
                xmlelement.InnerText = value;
            }
        }
        /// <summary>
        /// 取节点值,若不存在节点,返回null
        /// </summary>
        /// <param name="element"></param>
        /// <returns></returns>
        public string GetDataValue(string element)
        {
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode + "/" + element);

            if (null == xmlNode)
                return null;
            else
                return xmlNode.InnerText;
        }

        public void SetDataValue(string node, string element, string value)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlroot = xmlDoc.SelectSingleNode(strRootNode);

            XmlNode xmlnode = xmlroot.SelectSingleNode(node);
            if (null == xmlnode)
            {
                xmlnode = xmlDoc.CreateElement(node);
                xmlroot.AppendChild(xmlnode);
            }

            XmlNode xmlelement = xmlnode.SelectSingleNode(element);
            if (null == xmlelement)
            {
                XmlElement xeValue = xmlDoc.CreateElement(element);
                xeValue.InnerText = value;
                xmlnode.AppendChild(xeValue);
            }
            else
            {
                xmlelement.InnerText = value;
            }
        }

        public string GetDataValue(string node, string element)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode + "/" + node + "/" + element);

            if (null == xmlNode)
                return null;
            else
                return xmlNode.InnerText;
        }

        public void SetDataValue(string node1, string node2, string element, string value)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlroot = xmlDoc.SelectSingleNode(strRootNode);

            XmlNode xmlnode1 = xmlroot.SelectSingleNode(node1);
            if (null == xmlnode1)
            {
                xmlnode1 = xmlDoc.CreateElement(node1);
                xmlroot.AppendChild(xmlnode1);
            }

            XmlNode xmlnode2 = xmlnode1.SelectSingleNode(node2);
            if (null == xmlnode2)
            {
                xmlnode2 = xmlDoc.CreateElement(node2);
                xmlnode1.AppendChild(xmlnode2);
            }

            XmlNode xmlelement = xmlnode2.SelectSingleNode(element);
            if (null == xmlelement)
            {
                XmlElement xeValue = xmlDoc.CreateElement(element);
                xeValue.InnerText = value;
                xmlnode2.AppendChild(xeValue);
            }
            else
            {
                xmlelement.InnerText = value;
            }
        }

        public string GetDataValue(string node1, string node2, string element)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2 + "/" + element);

            if (null == xmlNode)
                return null;
            else
                return xmlNode.InnerText;
        }

        public void SetDataValue(string node1, string node2, string node3, string element, string value)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlroot = xmlDoc.SelectSingleNode(strRootNode);

            XmlNode xmlnode1 = xmlroot.SelectSingleNode(node1);
            if (null == xmlnode1)
            {
                xmlnode1 = xmlDoc.CreateElement(node1);
                xmlroot.AppendChild(xmlnode1);
            }

            XmlNode xmlnode2 = xmlnode1.SelectSingleNode(node2);
            if (null == xmlnode2)
            {
                xmlnode2 = xmlDoc.CreateElement(node2);
                xmlnode1.AppendChild(xmlnode2);
            }

            XmlNode xmlnode3 = xmlnode2.SelectSingleNode(node3);
            if (null == xmlnode3)
            {
                xmlnode3 = xmlDoc.CreateElement(node3);
                xmlnode2.AppendChild(xmlnode3);
            }

            XmlNode xmlelement = xmlnode3.SelectSingleNode(element);
            if (null == xmlelement)
            {
                XmlElement xeValue = xmlDoc.CreateElement(element);
                xeValue.InnerText = value;
                xmlnode3.AppendChild(xeValue);
            }
            else
            {
                xmlelement.InnerText = value;
            }
        }

        public string GetDataValue(string node1, string node2, string node3, string element)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode xmlNode = xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2 + "/" + node3 + "/" + element);

            if (null == xmlNode)
                return null;
            else
                return xmlNode.InnerText;
        }

        public void SetComment(string str, string CommentStyle, string node1 = null, string node2 = null, string node3 = null)
        {
            XmlNode xmlNode = null;
            if (node1 == null)

                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode);
            else if (node2 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1);
            else if (node3 == null)
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2);
            else
                xmlNode = (XmlElement)xmlDoc.SelectSingleNode(strRootNode + "/" + node1 + "/" + node2 + "/" + node3);
            //xmlNode.ParentNode.InsertAfter(xmlDoc.CreateComment(str), xmlNode);
            if (CommentStyle == "pre")
                xmlNode.PrependChild(xmlDoc.CreateComment(str));
            else
                xmlNode.AppendChild(xmlDoc.CreateComment(str));
        }
    }

    #endregion

    public class XmlHandle
    {
        private static XmlDocument xmlDoc;

        public static string xmlGmageConfigFileName
        {
            get
            {
                return "Gmage.xml";
            }
        }

        public static XmlDocument xmlGmageConfig
        {
            get
            {
                if (null == xmlDoc)
                {
                    xmlDoc = new XmlDocument();
                    XmlDeclaration xmldecl = xmlDoc.CreateXmlDeclaration("1.0", null, null);
                    xmlDoc.AppendChild(xmldecl);
                    XmlNode root = xmlDoc.CreateElement("GMAGE");
                    xmlDoc.AppendChild(root);
                }
                return xmlDoc;
            }
            set
            {
                xmlDoc = value;
            }
        }

        public static bool SaveGmageConfig()
        {
            try
            {
                xmlGmageConfig.Save(Application.StartupPath + "\\" + xmlGmageConfigFileName);
            }
            catch (Exception)
            {
                MessageBox.Show("请给程序管理员权限。修改方法：找到shgarden.exe文件，右击文件选属性，在属性的“兼容性”里“特权等级”中勾选“以管理员身份运行此程序”即可！");
                return false;
            }
            return true;
        }

        public static void LoadGmageConfig()
        {
            string path = Application.StartupPath + "\\" + xmlGmageConfigFileName;
            try
            {
                if (File.Exists(path))
                    xmlGmageConfig.Load(path);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show($"加载配置文件[{path}]错误:\r\n\r\n{ex.ToString()}");
                xmlDoc = null;
            }
        }

        /// <summary>
        /// 保存和修改xml数据
        /// </summary>
        /// <param name="strUnit">主要用于区别单位，当不需要区别单位时使用特殊值</param>
        /// <param name="formNode">窗体名</param>
        /// <param name="objectNode">标识</param>
        /// <param name="element">数据类型</param>
        /// <param name="value">值</param>
        /// <param name="bAdd">添加还是修改</param>
        public static void SetGmageConfigElement(string strUnit, string formNode, string objectNode, string element, string value, bool bAdd = false)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            if (value == "")
                return;
            XmlNode xmlroot = xmlGmageConfig.SelectSingleNode("GMAGE");

            XmlNode xmlUnitNode = xmlroot.SelectSingleNode(strUnit);
            if (null == xmlUnitNode)
            {
                xmlUnitNode = xmlGmageConfig.CreateElement(strUnit);
                xmlroot.AppendChild(xmlUnitNode);
            }

            XmlNode xmlFormNode = xmlUnitNode.SelectSingleNode(formNode);
            if (null == xmlFormNode)
            {
                xmlFormNode = xmlGmageConfig.CreateElement(formNode);
                xmlUnitNode.AppendChild(xmlFormNode);
            }

            XmlNode xmlObjectNode = xmlFormNode.SelectSingleNode(objectNode);
            if (null == xmlObjectNode)
            {
                xmlObjectNode = xmlGmageConfig.CreateElement(objectNode);
                xmlFormNode.AppendChild(xmlObjectNode);
            }
            if (bAdd)//新增
            {
                XmlElement xeValue = xmlGmageConfig.CreateElement(element);
                xeValue.InnerText = value;
                xmlObjectNode.AppendChild(xeValue);
            }
            else//更新
            {
                XmlNode xmlelement = xmlObjectNode.SelectSingleNode(element);
                if (null == xmlelement)
                {
                    XmlElement xeValue = xmlGmageConfig.CreateElement(element);
                    xeValue.InnerText = value;
                    //xeValue.SetAttribute("aa", "aaaaa");  //添加属性
                    xmlObjectNode.AppendChild(xeValue);
                }
                else
                {
                    xmlelement.InnerText = value;
                }
            }
        }

        /// <summary>
        /// 获取节点字符串,不存在返回null
        /// </summary>
        /// <param name="strUnit"></param>
        /// <param name="formNode"></param>
        /// <param name="objectNode"></param>
        /// <param name="element"></param>
        /// <returns></returns>
        public static string GetGmageConfigElement(string strUnit, string formNode, string objectNode, string element)
        {
            element = element.Replace("(", "-");
            element = element.Replace(")", "-");
            XmlNode node = xmlGmageConfig.SelectSingleNode("GMAGE/" + strUnit + "/" + formNode + "/" + objectNode + "/" + element);

            if (null == node)
                return null;
            else
                return node.InnerText;
        }
        public static void SetConfigValue(string strName, string strValue)
        {
            XmlNode xmlroot = xmlGmageConfig.SelectSingleNode("GMAGE");

            XmlNode xmlelement = xmlroot.SelectSingleNode(strName);
            if (null == xmlelement)
            {
                XmlElement xeValue = xmlGmageConfig.CreateElement(strName);
                xeValue.InnerText = strValue;
                xmlroot.AppendChild(xeValue);
            }
            else
            {
                xmlelement.InnerText = strValue;
            }
        }
        /// <summary>
        /// 取节点Gmage/strName,若不存在返回默认值strDef
        /// </summary>
        /// <param name="strName">二级节点</param>
        /// <param name="strDef">获取失败的返回值</param>
        public static string GetConfigValue(string strName, string strDef)
        {
            XmlNode node = xmlGmageConfig.SelectSingleNode("GMAGE/" + strName);

            if (null == node)
                return strDef;
            else
                return node.InnerText;
        }
      
        public static void SaveControlValue(string val1, string val2, string val3, string val4)
        {
            SetGmageConfigElement(val1, val2, val3, "Value", val4);
        }


        /// <summary>
        /// 从Gmage.xml取控件数据,不存在时返回null//
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public static string LoadControlValue(string val1, string val2, string val3)
        {
            string str = GetGmageConfigElement(val1,
               val2, val3, "Value");
            return str;
        }

        public static string LoadPreferences(string val1, string val2, string def,string preNood = "Preferences")
        {
            var value = LoadControlValue(preNood, val1, val2);
            if (string.IsNullOrEmpty(value))
            {
                value = def;
            }
            return value;
        }

        public static void SetPreferences(string val1, string val2, string val3)
        {
            SaveControlValue("Preferences", val1, val2, val3);
        }
    }
}
