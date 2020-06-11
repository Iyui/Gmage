using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using static Gmage.ImageProcess;
namespace Gmage.GraphCommand
{
    public class GraphCommand
    {
        public IDictionary<FunctionType, IGraphCommand> Commands = new Dictionary<FunctionType, IGraphCommand>();

        public void AddCommand(FunctionType functionType, IGraphCommand graphCommand)
        {
            Commands.Add(functionType, graphCommand);
        }

        public Bitmap Execute(FunctionType functionType, Bitmap bitmap)
        {
            Commands[functionType].bitmap = bitmap.Clone() as Bitmap;
            return Commands[functionType].Draw();
        }
    }
    /// <summary>
    /// 命令接收
    /// </summary>
    public class Graphics
    {
        Stack<IGraphCommand> commands = new Stack<IGraphCommand>();

        public void Draw(IGraphCommand command)
        {
            command.Draw();
            commands.Push(command);
        }

        public void Undo()
        {
            IGraphCommand command = commands.Pop();
            command.Undo();
        }
    }

    public interface IGraphCommand
    {
        Bitmap bitmap
        {
            set; get;
        }
        Bitmap Draw();
        void Undo();
    }
    #region 翻转和旋转

    /// <summary>
    /// 顺时针90度
    /// </summary>
    public class Clockwise90 : IGraphCommand
    {
        //
        public Bitmap bitmap
        {
            set;get;
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
 
        public Bitmap bitmap
        {
            set; get;
        }
        public Clockwise270( )
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
    public class Complementary : IGraphCommand
    {
        
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
    public class ImageToGrey : IGraphCommand
    {
        
        public Bitmap bitmap
        {
            set; get;
        }
        public ImageToGrey()
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
            return BinarizationP(_bitmap);
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
            return Lighten(_bitmap);
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
            return Contrast(_bitmap);
        }

        public void Undo()
        {

        }
    }

    /// <summary>
    /// 锐化
    /// </summary>
    public class Sharpen : IGraphCommand
    {

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
            return Sharpen(_bitmap);
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

    /// <summary>
    /// 边缘检测Robert算子
    /// </summary>
    public class Robert : IGraphCommand
    {

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
            return EdgeDetector_Robert(_bitmap);
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
    public class TopHap : IGraphCommand
    {

        public Bitmap bitmap
        {
            set; get;
        }
        public TopHap()
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
    /// <summary>
    /// 傅里叶变换 频率谱
    /// </summary>
    public class FFT : IGraphCommand
    {
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

    /// <summary>
    /// 识别
    /// </summary>
    public class Recognite : IGraphCommand
    {

        public Bitmap bitmap
        {
            set; get;
        }
        public Recognite()
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
 
    #endregion
}
