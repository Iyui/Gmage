using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
namespace ImageAnalyze
{
    public class ImageProcess
    {
        /// <summary>
        /// 反色 像素法
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap Complementary(Image img)
        {
            Bitmap cBitmap = new Bitmap(img);
            for (int i = 0; i < cBitmap.Width; i++)
            {
                for (int j = 0; j < cBitmap.Height; j++)
                {
                    Color c = cBitmap.GetPixel(i, j);
                    int cR = 255 - c.R;
                    int cG = 255 - c.G;
                    int cB = 255 - c.B;
                    cBitmap.SetPixel(i, j, Color.FromArgb(cR, cG, cB));
                }
            }

            return cBitmap;
        }

        /// <summary>
        /// 反色 指针法
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap ComplementaryP(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            BitmapData bitmapdat = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图
            unsafe // 不安全代码
            {
                byte* pix = (byte*)bitmapdat.Scan0; // 像素首地址
                for (int i = 0; i < bitmapdat.Stride * bitmapdat.Height; i++)
                    pix[i] = (byte)(255 - pix[i]);
            }
            bitmap.UnlockBits(bitmapdat); // 解锁
            return bitmap;
        }

        /// <summary>
        /// 灰度化c.R * .3 + c.G * .59 + c.B * .11 像素法
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ImageToGrey(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int gray = Gray(c);
                    bitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return bitmap;
        }
        /// <summary>
        /// 灰度化 指针法
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap ImageToGreyP(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            BitmapData bitmapdat = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图
            byte temp = 0;
            unsafe // 不安全代码
            {
                byte* pix = (byte*)bitmapdat.Scan0; // 像素首地址
                for (int i = 0; i < bitmapdat.Height; i++)
                {
                    for (int j = 0; j < bitmapdat.Width; j++)
                    {
                        temp = (byte)(pix[2] * .3 + pix[1] * .59 + pix[0] * .11 );
                        pix[0] = pix[1] = pix[2] = temp;
                        pix += 3;
                    }
                    pix += bitmapdat.Stride - bitmapdat.Width*3;
                }
            }

            bitmap.UnlockBits(bitmapdat); // 解锁
            return bitmap;
        }

        public static int Gray(Color c)
        {
            return (int)(c.R * .3 + c.G * .59 + c.B * .11);
        }

        public static int Gray2(Color c)
        {
            return (int)(c.R + c.G + c.B) / 3;
        }

        /// <summary>
        /// 灰度化 (c.R + c.G + c.B) / 3
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ImageToGrey2(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int gray = Gray2(c);
                    bitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 二值化 像素法
        /// </summary>
        /// <param name="img"></param>
        /// <param name="threshold">阈值</param>
        /// <returns></returns>
        public static Bitmap Threshoding(Bitmap initbitmap, int threshold = 128)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int rgb = (int)(c.R * .3 + c.G * .59 + c.B * .11);
                    if (rgb < threshold)
                        bitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        bitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 二值化 指针法
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap ThreshodingP(Bitmap initbitmap, int threshold = 128)
        {
            Bitmap bitmap = new Bitmap(Image.FromHbitmap(initbitmap.GetHbitmap())); // 加载图像
            BitmapData bitmapdat = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图
            unsafe // 不安全代码
            {
                byte* pix = (byte*)bitmapdat.Scan0; // 像素首地址
                for (int i = 0; i < bitmapdat.Height; i++)
                {
                    for (int j = 0; j < bitmapdat.Width; j++)
                    {
                        if (pix[2] * .3 + pix[1] * .59 + pix[0] * .11 > threshold)
                            pix[0] = pix[1] = pix[2] = 255;
                        else
                            pix[0] = pix[1] = pix[2] = 0;
                        pix += 3;
                    }
                    pix += bitmapdat.Stride - bitmapdat.Width * 3;
                }
            }
            bitmap.UnlockBits(bitmapdat); // 解锁
            return bitmap;
        }

        /// <summary>
        /// 面部识别
        /// </summary>
        /// <param name="img"></param>
        /// <param name="Grayimg"></param>
        /// <param name="save"></param>
        /// <returns></returns>
        public static Bitmap Recognite_Face(Bitmap bitmap)
        {

            //如果支持用显卡,则用显卡运算
            CvInvoke.UseOpenCL = CvInvoke.HaveOpenCLCompatibleGpuDevice;

            //构建级联分类器,利用已经训练好的数据,识别人脸
            //var face = new CascadeClassifier("haarcascade_frontalface_alt.xml");
            var face = new CascadeClassifier("lbpcascade_animeface.xml");

            // var face = new CascadeClassifier("haarcascade_frontalface_alt.xml");

            //加载要识别的图片
            //var img = new Image<Bgr, byte>("0.png");
            //var img2 = new Image<Gray, byte>(img.ToBitmap());
            Image<Bgr, byte> img = new Image<Bgr, byte>(bitmap);
            var Grayimg = new Image<Gray, byte>(bitmap);
            //把图片从彩色转灰度
            CvInvoke.CvtColor(img, Grayimg, ColorConversion.Bgr2Gray);

            //亮度增强
            CvInvoke.EqualizeHist(Grayimg, Grayimg);
            //在这一步就已经识别出来了,返回的是人脸所在的位置和大小
            var facesDetected = face.DetectMultiScale(Grayimg, 1.1, 10, new Size(50, 50));

            //循环把人脸部分切出来并保存
            // CutandSave(facesDetected);
            return ShowCut(facesDetected, img);


            ////释放资源退出
            //img.Dispose();
            //Grayimg.Dispose();
            //face.Dispose();

            //return;
        }

        private static Bitmap ShowCut(Rectangle[] facesDetected, Image<Bgr, byte> bitmap)
        {
            Bitmap rectg = bitmap.ToBitmap();
            foreach (var item in facesDetected)
            {
                var bmpRect = new Bitmap(item.Width, item.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);
                var g = Graphics.FromImage(bmpRect);
                rectg = DrawRectangle(rectg, item.X, item.Y, item.Width, item.Height);
            }
            return rectg;
        }

        /// <summary>
        /// 画矩形
        /// </summary>
        /// <param name="x">左上角的坐标</param>
        /// <param name="y">右下角的坐标</param>
        private static Bitmap DrawRectangle(Bitmap image, int x, int y, int width, int height)
        {
            var g = Graphics.FromImage(image);
            var pen = new Pen(Color.Red);
            g.DrawRectangle(pen, x, y, width, height);
            return image;
        }

        /// <summary>
        /// 椒盐噪声
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap SaltNoise(Bitmap initBitmap)
        {
            return Noise.SaltP(initBitmap);
        }

        /// <summary>
        /// 高斯噪声
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussNoise(Bitmap initBitmap)
        {
            return Noise.Goss_noise(initBitmap);
        }

        /// <summary>
        /// 高斯平滑
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussBlur(Bitmap initBitmap)
        {
            Noise convolution = new Noise();
            return convolution.Smooth(initBitmap);
        }

        /// <summary>
        /// 高斯平滑 指针法
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussBlurP(Bitmap initBitmap)
        {
            Noise convolution = new Noise();
            return convolution.GaussSmooth(initBitmap);
        }

        /// <summary>
        /// 边缘检测Robert算子
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <param name="Threshold"></param>
        /// <returns></returns>
        public static Bitmap EdgeDetector_Robert(Bitmap initBitmap, int Threshold = 80)
        {
            return EdgeDetector.Robert(initBitmap, Threshold);
        }
        /// <summary>
        /// 边缘检测Smoothed
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap EdgeDetector_Smoothed(Bitmap initBitmap)
        {
            return EdgeDetector.Smoothed(initBitmap);
        }

        /// <summary>
        /// 傅里叶变换 频率谱
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap FFT(Bitmap initBitmap)
        {
            return Fourier.FFT(initBitmap);
        }
        public static Bitmap Polar(Bitmap initBitmap, int M = 100)
        {
            var img = new Image<Bgr, byte>(initBitmap);

            var img2 = new Image<Bgr, byte>(initBitmap);

            CvInvoke.LogPolar(img, img2, new PointF(
          img.Width / 2,
          img.Height / 2
                   ), M);
            return img2.ToBitmap();
        }
    }
}
