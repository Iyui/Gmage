﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using static ImageAnalyze.Noise.Noise;
namespace ImageAnalyze
{
    public class ImageProcess
    {
        #region 翻转和旋转
        /// <summary>
        /// 顺时针90度
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap Clockwise90(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.Rotate90FlipNone);
            return bitmap;
        }

        /// <summary>
        /// 旋转180度
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap Clockwise180(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.Rotate180FlipNone);
            return bitmap;
        }
        /// <summary>
        /// 逆时针90度
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap Clockwise270(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return bitmap;
        }
        /// <summary>
        /// 垂直镜像
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap RotateNoneFlipX(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return bitmap;
        }

        /// <summary>
        /// 水平镜像
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap RotateNoneFlipY(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            bitmap.RotateFlip(RotateFlipType.RotateNoneFlipY);
            return bitmap;
        }

        #endregion

        #region 简单的像素处理

        /// <summary>
        /// 反色 像素法
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap Complementary(Bitmap initbitmap)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    Color c = bitmap.GetPixel(i, j);
                    int cR = 255 - c.R;
                    int cG = 255 - c.G;
                    int cB = 255 - c.B;
                    bitmap.SetPixel(i, j, Color.FromArgb(cR, cG, cB));
                }
            }

            return bitmap;
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
                        temp = (byte)(pix[2] * .3 + pix[1] * .59 + pix[0] * .11);
                        pix[0] = pix[1] = pix[2] = temp;
                        pix += 3;
                    }
                    pix += bitmapdat.Stride - bitmapdat.Width * 3;
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
        public static Bitmap Binarization(Bitmap initbitmap, int threshold = 128)
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
        public static Bitmap BinarizationP(Bitmap initbitmap, int threshold = 128)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap; // 加载图像
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

        #endregion

        #region 
        /// <summary>
        /// 图像亮度调整
        /// </summary>
        /// <param name="initbitmap">原始图</param>
        /// <param name="degree">亮度[-255, 255]</param>
        /// <returns></returns>
        public static Bitmap Lighten(Bitmap initbitmap, int degree = 0)
        {
            if (initbitmap == null)
            {
                return null;
            }
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            if (degree < -255) degree = -255;
            if (degree > 255) degree = 255;

            try
            {

                int width = bitmap.Width;
                int height = bitmap.Height;

                int pix = 0;

                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的亮度
                            for (int i = 0; i < 3; i++)
                            {
                                pix = p[i] + degree;

                                if (degree < 0) p[i] = (byte)Math.Max(0, pix);
                                if (degree > 0) p[i] = (byte)Math.Min(255, pix);

                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }

                bitmap.UnlockBits(data);

                return bitmap;
            }
            catch
            {
                return null;
            }

        }

        /// <summary>
        /// 图像对比度调整
        /// </summary>
        /// <param name="initbitmap">原始图</param>
        /// <param name="degree">对比度[-100, 100]</param>
        /// <returns></returns>
        public static Bitmap Contrast(Bitmap initbitmap, int degree = 0)
        {
            if (initbitmap == null)
            {
                return null;
            }

            if (degree < -100) degree = -100;
            if (degree > 100) degree = 100;
            Bitmap bitmap = initbitmap.Clone() as Bitmap;
            try
            {

                double pixel = 0;
                double contrast = (100.0 + degree) / 100.0;
                contrast *= contrast;
                int width = bitmap.Width;
                int height = bitmap.Height;
                BitmapData data = bitmap.LockBits(new Rectangle(0, 0, width, height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* p = (byte*)data.Scan0;
                    int offset = data.Stride - width * 3;
                    for (int y = 0; y < height; y++)
                    {
                        for (int x = 0; x < width; x++)
                        {
                            // 处理指定位置像素的对比度
                            for (int i = 0; i < 3; i++)
                            {
                                pixel = ((p[i] / 255.0 - 0.5) * contrast + 0.5) * 255;
                                if (pixel < 0) pixel = 0;
                                if (pixel > 255) pixel = 255;
                                p[i] = (byte)pixel;
                            } // i
                            p += 3;
                        } // x
                        p += offset;
                    } // y
                }
                bitmap.UnlockBits(data);
                return bitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 锐化
        /// </summary>
        /// <param name="initbitmap">原始Bitmap</param>
        /// <param name="val">锐化程度。取值[0,1]。值越大锐化程度越高</param>
        /// <returns>锐化后的图像</returns>
        public static Bitmap Sharpen(Bitmap initbitmap, float degree = 1)
        {
            if (initbitmap == null)
            {
                return null;
            }

            int w = initbitmap.Width;
            int h = initbitmap.Height;

            try
            {

                Bitmap bmpRtn = new Bitmap(w, h, PixelFormat.Format24bppRgb);

                BitmapData srcData = initbitmap.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = bmpRtn.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);

                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    int stride = srcData.Stride;
                    byte* p;

                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            //取周围9点的值。位于边缘上的点不做改变。
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                //不做
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                int r1, r2, r3, r4, r5, r6, r7, r8, r0;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b0;

                                float vR, vG, vB;

                                //左上
                                p = pIn - stride - 3;
                                r1 = p[2];
                                g1 = p[1];
                                b1 = p[0];

                                //正上
                                p = pIn - stride;
                                r2 = p[2];
                                g2 = p[1];
                                b2 = p[0];

                                //右上
                                p = pIn - stride + 3;
                                r3 = p[2];
                                g3 = p[1];
                                b3 = p[0];

                                //左侧
                                p = pIn - 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];

                                //右侧
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];

                                //右下
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];

                                //正下
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];

                                //右下
                                p = pIn + stride + 3;
                                r8 = p[2];
                                g8 = p[1];
                                b8 = p[0];

                                //自己
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];

                                vR = (float)r0 - (float)(r1 + r2 + r3 + r4 + r5 + r6 + r7 + r8) / 8;
                                vG = (float)g0 - (float)(g1 + g2 + g3 + g4 + g5 + g6 + g7 + g8) / 8;
                                vB = (float)b0 - (float)(b1 + b2 + b3 + b4 + b5 + b6 + b7 + b8) / 8;

                                vR = r0 + vR * degree;
                                vG = g0 + vG * degree;
                                vB = b0 + vB * degree;

                                if (vR > 0)
                                {
                                    vR = Math.Min(255, vR);
                                }
                                else
                                {
                                    vR = Math.Max(0, vR);
                                }

                                if (vG > 0)
                                {
                                    vG = Math.Min(255, vG);
                                }
                                else
                                {
                                    vG = Math.Max(0, vG);
                                }

                                if (vB > 0)
                                {
                                    vB = Math.Min(255, vB);
                                }
                                else
                                {
                                    vB = Math.Max(0, vB);
                                }

                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;

                            }

                            pIn += 3;
                            pOut += 3;
                        }// end of x

                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    } // end of y
                }

                initbitmap.UnlockBits(srcData);
                bmpRtn.UnlockBits(dstData);
                return bmpRtn;
            }
            catch
            {
                return null;
            }
        }
        #endregion

        #region 噪声
        /// <summary>
        /// 椒盐噪声
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap SaltNoise(Bitmap initBitmap, double Pa = 0.001, double Pb = 0.001)
        {
            return SaltP(initBitmap, Pa, Pb);
        }

        /// <summary>
        /// 高斯噪声
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussNoise(Bitmap initBitmap)
        {
            return Goss_noise(initBitmap);
        }
        #endregion

        #region 滤波
        /// <summary>
        /// 高斯平滑
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussBlur(Bitmap initBitmap)
        {
            Filter.Filter filter = new Filter.Filter();
            return filter.Smooth(initBitmap);
        }

        /// <summary>
        /// 高斯平滑 指针法
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap GaussBlurP(Bitmap initBitmap)
        {
            Filter.Filter filter = new Filter.Filter();
            return filter.GaussSmooth(initBitmap);
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap MedianFilter(Bitmap initBitmap)
        {
            return Filter.Filter.MedianFilter(initBitmap);
        }
        #endregion

        #region 边缘检测
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
        #endregion



        #region 未用算法实现 
        /// <summary>
        /// 傅里叶变换 频率谱
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap FFT(Bitmap initBitmap)
        {
            return Fourier.FFT(initBitmap);
        }

        /// <summary>
        /// 傅里叶逆变换
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <returns></returns>
        public static Bitmap BFT(Bitmap initBitmap)
        {
            return Fourier.BFT(initBitmap);
        }

        /// <summary>
        /// 极坐标变换
        /// </summary>
        /// <param name="initBitmap"></param>
        /// <param name="x">The transformation center, where the output precision is maximal</param>
        /// <param name="y">The transformation center, where the output precision is maximal</param>
        /// <param name="M">Magnitude scale parameter</param>
        /// <returns></returns>
        public static Bitmap Polar(Bitmap initBitmap, int M = 100, float x = 0, float y = 0)
        {
            var pointF = new PointF(x, y);

            var img = new Image<Bgr, byte>(initBitmap);

            var img2 = new Image<Bgr, byte>(initBitmap);

            CvInvoke.LogPolar(img, img2, pointF, M);

            return img2.ToBitmap();
        }


        #region 面部识别
        /// <summary>
        /// 面部识别
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="Classifier">训练好的分类器</param>
        /// <returns></returns>
        public static Bitmap Recognite_Face(Bitmap bitmap, string Classifier = "haarcascade_frontalface_alt.xml")
        {
            //如果支持用显卡,则用显卡运算
                CvInvoke.UseOpenCL = CvInvoke.HaveOpenCLCompatibleGpuDevice;

                //构建级联分类器,利用已经训练好的数据,识别人脸
                //var face = new CascadeClassifier("haarcascade_frontalface_alt.xml");
                var face = new CascadeClassifier("Classifier/" + Classifier);

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
                var resultImg = ShowCut(facesDetected, img);
                Grayimg.Dispose();
                img.Dispose();
                face.Dispose();
                GC.Collect();
                return resultImg;
            

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
        #endregion

        #endregion
    }
}
