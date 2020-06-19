using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using static Gmage.ImageProcess;
namespace Gmage.GraphCommand
{
    /// <summary>
    /// 参数
    /// </summary>
    public class Parameter
    {
        public point[] Points { set; get; }
        public int[] iParameter { set; get; }
        public float[] fParameter { set; get; }
        public bool[] bParameter { set; get; }
        public int Hold { set; get; }
        public PictureBox PictureBox { set; get; }
        public Color Color { set; get; }
        public Bitmap OutBitmap { set; get; }

        public Bitmap mask { set; get; }
        public Parameter()
        {

        }
    }

    /// <summary>
    /// 根据FunctionType执行命令
    /// </summary>
    public class GraphCommand
    {
        Graphics graphics = new Graphics();

        public IDictionary<FunctionType, IGraphCommand> Commands = new Dictionary<FunctionType, IGraphCommand>();

        public void AddCommand(FunctionType functionType, IGraphCommand graphCommand)
        {
            Commands.Add(functionType, graphCommand);
        }

        /// <summary>
        /// 根据FunctionType执行命令
        /// </summary>
        /// <param name="functionType">处理类型</param>
        /// <param name="bitmap">原图</param>
        /// <param name="AddUndo">是否能够执行撤回</param>
        /// <returns></returns>
        public Bitmap Execute(FunctionType functionType, Bitmap bitmap,bool AddUndo = true)
        {
            Commands[functionType].bitmap = bitmap.Clone() as Bitmap;
            GC.Collect();
            return graphics.Draw(Commands[functionType],AddUndo);
        }

        public Bitmap Execute(FunctionType functionType, Bitmap bitmap, Parameter Parameter, bool AddUndo = true)
        {
            Commands[functionType].bitmap = bitmap.Clone() as Bitmap;
            Commands[functionType].Parameter = Parameter;
            GC.Collect();
            return graphics.Draw(Commands[functionType], AddUndo);
        }

        public bool Undo(ref Bitmap bitmap)
        {
            return graphics.Undo(ref bitmap);
        }

        public bool Redo(ref Bitmap bitmap)
        {
            return graphics.Redo(ref bitmap);
        }

        public void RemoveStack()
        {
            graphics.Remove();
            GC.Collect();
        }
    }
    /// <summary>
    /// 命令接收
    /// </summary>
    public class Graphics
    {
        public static string CurrentWindow = "";

        Stack<IGraphCommand> Undocommands = new Stack<IGraphCommand>();
        Stack<IGraphCommand> Redocommands = new Stack<IGraphCommand>();
        Stack<Bitmap> UndoBitmaps = new Stack<Bitmap>();
        Stack<Bitmap> RedoBitmaps = new Stack<Bitmap>();

        Dictionary<string, Stack<Bitmap>> DicUndocommands = new Dictionary<string, Stack<Bitmap>>();
        Dictionary<string, Stack<Bitmap>> DicRedocommands = new Dictionary<string, Stack<Bitmap>>();
        //Dictionary<string, Stack<IGraphCommand>> Diccommands = new Dictionary<string, Stack<IGraphCommand>>();

        public Bitmap Draw(IGraphCommand command, bool AddUndo = true)
        {
            if(DicUndocommands.ContainsKey(CurrentWindow))
            {
                UndoBitmaps = DicUndocommands[CurrentWindow];
                RedoBitmaps = DicRedocommands[CurrentWindow];

            }
            else
            {
                UndoBitmaps = new Stack<Bitmap>();
                RedoBitmaps = new Stack<Bitmap>();
                DicUndocommands.Add(CurrentWindow, UndoBitmaps);
                DicRedocommands.Add(CurrentWindow, RedoBitmaps);
            }
            if (command is PenDraw)
            {
                if (Config.parameter.iParameter[0] == 1)
                {
                    //Undocommands.Push(command);
                    UndoBitmaps.Push(command.bitmap);
                    RedoBitmaps.Clear();
                    //Redocommands.Clear();
                }
            }
            else if (AddUndo)
            {
                //Undocommands.Push(command);
                UndoBitmaps.Push(command.bitmap);
                RedoBitmaps.Clear();
               // Redocommands.Clear();
            }
            return command.Draw();
        }

        public bool Undo(ref Bitmap bitmap)
        {
            if (DicUndocommands.ContainsKey(CurrentWindow))
            {
                UndoBitmaps = DicUndocommands[CurrentWindow];
                RedoBitmaps = DicRedocommands[CurrentWindow];
            }
            else
            {
                bitmap = null;
                return false;
            }
            //IGraphCommand command = commands.Pop();
            //command.Undo();
            if (UndoBitmaps.Any())
            {
                //var commands = Undocommands.Pop();
                //Redocommands.Push(commands);
                RedoBitmaps.Push(bitmap);
                bitmap = UndoBitmaps.Pop();

                return true;
            }
            bitmap = null;
            return false;
        }

        public bool Redo(ref Bitmap bitmap)
        {
            if (DicUndocommands.ContainsKey(CurrentWindow))
            {
                UndoBitmaps = DicUndocommands[CurrentWindow];
                RedoBitmaps = DicRedocommands[CurrentWindow];
            }
            if (RedoBitmaps.Any())
            {
                UndoBitmaps.Push(bitmap);
                bitmap = RedoBitmaps.Pop();
                //var commands = Redocommands.Pop();
                //Undocommands.Push(commands);
                return true;
            }
            bitmap = null;
            return false;
        }

        public void Remove()
        {
            if (DicUndocommands.ContainsKey(CurrentWindow))
            {
                DicUndocommands[CurrentWindow].Clear();
                DicUndocommands.Remove(CurrentWindow);
            }
            if (DicRedocommands.ContainsKey(CurrentWindow))
            {
                DicRedocommands[CurrentWindow].Clear();
                DicRedocommands.Remove(CurrentWindow);
            }
        }
    }

    #region 命令接口
    public interface IGraphCommand
    {
        string _Name { get; }
        Bitmap bitmap
        {
            set; get;
        }
        Parameter Parameter
        {
            set; get;
        }

        Bitmap Draw();
        void Undo();
    }

    #endregion

    #region 翻转和旋转

    /// <summary>
    /// 顺时针90度
    /// </summary>
    public class Clockwise90 : IGraphCommand
    {
        public string _Name { get; } = "Clockwise90";
        //
        public Bitmap bitmap
        {
            set; get;
        }
        public Parameter Parameter
        {
            set; get;
        }
        public Clockwise90()
        {

        }

        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Clockwise90(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 顺时针180度
    /// </summary>
    public class Clockwise180 : IGraphCommand
    {
        public string _Name { get; } = "Clockwise180";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Clockwise180()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Clockwise180(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 逆时针90度
    /// </summary>
    public class Clockwise270 : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Clockwise270()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Clockwise270(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 垂直镜像
    /// </summary>
    public class RotateNoneFlipX : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public RotateNoneFlipX()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return RotateNoneFlipX(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 水平镜像
    /// </summary>
    public class RotateNoneFlipY : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public RotateNoneFlipY()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return RotateNoneFlipY(_bitmap);
        }

        public void Undo()
        {

        }
    }
    #endregion

    #region 简单的像素处理
    /// <summary>
    /// 反色 像素法
    /// </summary>
    public class RGBChannel : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public RGBChannel()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Channel(_bitmap, Parameter.fParameter[0], Parameter.fParameter[1], Parameter.fParameter[2]);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 反色 像素法
    /// </summary>
    public class Complementary : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Complementary()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Complementary(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 反色 指针法
    /// </summary>
    public class ComplementaryP : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }

        public Bitmap bitmap
        {
            set; get;
        }
        public ComplementaryP()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return ComplementaryP(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 灰度化c.R * .3 + c.G * .59 + c.B * .11 像素法
    /// </summary>
    public class Gray : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Gray()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return ImageToGrey(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 灰度化 指针法
    /// </summary>
    public class ImageToGreyP : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public ImageToGreyP()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return ImageToGreyP(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 二值化 像素法
    /// </summary>
    public class Binarization : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }

        public Binarization()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Binarization(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 二值化 指针法
    /// </summary>
    public class BinarizationP : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public BinarizationP()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return BinarizationP(_bitmap, Parameter.Hold);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 图像亮度调整
    /// </summary>
    public class Lighten : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Lighten()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Lighten(_bitmap, Parameter.Hold);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 图像对比度调整
    /// </summary>
    public class Contrast : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Contrast()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Contrast(_bitmap, Parameter.Hold);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 卡通画
    /// </summary>
    public class Cartoonify : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Cartoonify()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Cartoonify(_bitmap);
        }

        public void Undo()
        {

        }
    }
    #endregion

    #region 滤镜
    /// <summary>
    /// 锐化
    /// </summary>
    public class Sharpen : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Sharpen()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Sharpen(_bitmap, Parameter.Hold / 25.5f);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 柔化
    /// </summary>
    public class Soften : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Soften()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Soften(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 雾化
    /// </summary>
    public class Atomization: IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Atomization()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Atomization(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 柔化
    /// </summary>
    public class Embossment : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Embossment()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Embossment(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 椒盐噪声
    /// </summary>
    public class SaltNoise : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public SaltNoise()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return SaltNoise(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 高斯噪声
    /// </summary>
    public class GaussNoise : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public GaussNoise()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return GaussNoise(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 高斯平滑
    /// </summary>
    public class GaussBlur : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public GaussBlur()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return GaussBlur(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 高斯平滑 指针法
    /// </summary>
    public class GaussBlurP : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public GaussBlurP()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return GaussBlurP(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 中值滤波
    /// </summary>
    public class MedianFilter : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public MedianFilter()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return MedianFilter(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 腐蚀（来消除小且无意义的物体）
    /// </summary>
    public class Erosion : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Erosion()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return ToErosion(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 膨胀
    /// </summary>
    public class Swell : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Swell()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return ToSwell(_bitmap);
        }

        public void Undo()
        {

        }
    }

    public class Mosaic : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Mosaic()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Mosaic(_bitmap,Parameter.Hold/5);
        }

        public void Undo()
        {

        }
    }


    #endregion

    #region 边缘检测
    /// <summary>
    /// 边缘检测Robert算子
    /// </summary>
    public class Robert : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Robert()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return EdgeDetector_Robert(_bitmap, Parameter.Hold);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 边缘检测Smoothed
    /// </summary>
    public class Smoothed : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Smoothed()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return EdgeDetector.Smoothed(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 边界
    /// </summary>
    public class Boundary : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }

        public Boundary()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return EdgeDetector.ToBoundary(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 骨架提取
    /// </summary>
    public class Skeleton : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }

        public Skeleton()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return EdgeDetector_Skeleton(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 高帽
    /// </summary>
    public class Tophap : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Tophap()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return EdgeDetector.ToTopHap(_bitmap);
        }

        public void Undo()
        {

        }
    }

    #endregion

    #region 其他变换
    /// <summary>
    /// 傅里叶变换 频率谱
    /// </summary>
    public class FFT : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }

        public FFT()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Fourier.FFT(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 极坐标变换
    /// </summary>
    public class Polar : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Polar()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Polar(_bitmap);
        }

        public void Undo()
        {

        }
    }
    #endregion

    #region 级联分类器
    /// <summary>
    /// 识别
    /// </summary>
    public class Recognition : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Recognition()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Recognite_Face(_bitmap);
        }

        public void Undo()
        {

        }
    }
    /// <summary>
    /// 肤色检测
    /// </summary>
    public class Skin : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Skin()
        {

        }
        public Bitmap Draw()
        {
            var _bitmap = bitmap.Clone() as Bitmap;
            return Recognite_Skin(_bitmap);
        }

        public void Undo()
        {

        }
    }
    #endregion

    #region 工具栏
    /// <summary>
    /// 裁剪
    /// </summary>
    public class Cut : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public Cut()
        {

        }
        public Bitmap Draw()
        {
            var Location = Parameter.iParameter;
            var _bitmap = bitmap.Clone() as Bitmap;
            return CutImage(_bitmap, Location[0], Location[1], Location[2], Location[3]);
        }
        
        private Bitmap CutImage(Bitmap bitmap, int x, int y, int width, int height)
        {
            if (width == 0 || height == 0)
                return bitmap;
            Image rectg = bitmap;
            var bmpRect = new Bitmap(width, height);
            var g = System.Drawing.Graphics.FromImage(bmpRect);
            g.DrawImage(rectg, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            g.Dispose();
            return bmpRect;
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 画笔
    /// </summary>
    public class PenDraw : IGraphCommand
    {
        public string _Name { get; } = "";
        public Parameter Parameter
        {
            set; get;
        }
        public Bitmap bitmap
        {
            set; get;
        }
        public PenDraw()
        {

        }
        Color _penColor = Color.Yellow;
        float _penWidth = 1;

        public double[] splinex = new double[1001];
        public double[] spliney = new double[1001];
        public int no_of_points = 0;
        int[] a1 = new int[12];
        int[] b1 = new int[12];
        public void bsp(point p1, point p2, point p3, point p4, int divisions)
        {
            double[] a = new double[5];
            double[] b = new double[5];
            a[0] = (-p1.x + 3 * p2.x - 3 * p3.x + p4.x) / 6.0;
            a[1] = (3 * p1.x - 6 * p2.x + 3 * p3.x) / 6.0;
            a[2] = (-3 * p1.x + 3 * p3.x) / 6.0;
            a[3] = (p1.x + 4 * p2.x + p3.x) / 6.0;
            b[0] = (-p1.y + 3 * p2.y - 3 * p3.y + p4.y) / 6.0;
            b[1] = (3 * p1.y - 6 * p2.y + 3 * p3.y) / 6.0;
            b[2] = (-3 * p1.y + 3 * p3.y) / 6.0;
            b[3] = (p1.y + 4 * p2.y + p3.y) / 6.0;

            splinex[0] = a[3];
            spliney[0] = b[3];

            int i;
            for (i = 1; i <= divisions - 1; i++)
            {
                float t = System.Convert.ToSingle(i) / System.Convert.ToSingle(divisions);
                splinex[i] = (a[2] + t * (a[1] + t * a[0])) * t + a[3];
                spliney[i] = (b[2] + t * (b[1] + t * b[0])) * t + b[3];


            }
        }
        public Bitmap Draw()
        {
            var parameter = Parameter.iParameter;
            no_of_points = parameter[0];
            var eX = parameter[1];
            var eY = parameter[2];
            var pt = Parameter.Points;
            var FrontColor = Parameter.Color;
            var _bitmap = bitmap.Clone() as Bitmap;
            Parameter.OutBitmap = _bitmap;
            if (no_of_points > 3)
            {
                pt[0] = pt[1]; pt[1] = pt[2]; pt[2] = pt[3];
                pt[3].setxy(eX, eY);
                double temp = Math.Sqrt(Math.Pow(pt[2].x - pt[1].x, 2F) + Math.Pow(pt[2].y - pt[1].y, 2F));
                int interpol = System.Convert.ToInt32(temp);
                bsp(pt[0], pt[1], pt[2], pt[3], interpol);
                int i;
                var bmpOut = _bitmap;

                System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmpOut);

                int x, y;

                g.SmoothingMode = SmoothingMode.AntiAlias;  //使绘图质量最高，即消除锯齿
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.CompositingQuality = CompositingQuality.HighQuality;

                for (i = 0; i <= interpol - 1; i++)
                {
                    x = Convert.ToInt32(splinex[i]);
                    y = Convert.ToInt32(spliney[i]);

                    _penColor = FrontColor;

                    g.DrawEllipse(new Pen(_penColor, _penWidth), x - 1, y, _penWidth, _penWidth);
                    g.DrawEllipse(new Pen(_penColor, _penWidth), x + 1, y, _penWidth, _penWidth);
                    g.DrawEllipse(new Pen(_penColor, _penWidth), x, y - 1, _penWidth, _penWidth);
                    g.DrawEllipse(new Pen(_penColor, _penWidth), x, y + 1, _penWidth, _penWidth);


                    //g.DrawLine(new Pen(_penColor, _penWidth), new Point(x - 1, y), new Point(x - 1 + _x_offset, y + _y_offset));
                    //g.DrawLine(new Pen(_penColor, _penWidth), new Point(x + 1, y), new Point(x + 1 + _x_offset, y + _y_offset));
                    //g.DrawLine(new Pen(_penColor, _penWidth), new Point(x, y - 1), new Point(x + _x_offset, y - 1 + _y_offset));
                    //g.DrawLine(new Pen(_penColor, _penWidth), new Point(x, y + 1), new Point(x + _x_offset, y + 1 + _y_offset));  
                }
                Parameter.OutBitmap = bmpOut;
                g.Dispose();
                GC.Collect();
            }
            else
            {
                pt[no_of_points].setxy(eX, eY);
            }
            return Parameter.OutBitmap;
        }

        private Bitmap CutImage(Bitmap bitmap, int x, int y, int width, int height)
        {
            Image rectg = bitmap;
            var bmpRect = new Bitmap(width, height);
            var g = System.Drawing.Graphics.FromImage(bmpRect);
            g.DrawImage(rectg, new Rectangle(0, 0, width, height), new Rectangle(x, y, width, height), GraphicsUnit.Pixel);
            g.Dispose();
            return bmpRect;
        }

        public void Undo()
        {

        }
    }
    #endregion

}
