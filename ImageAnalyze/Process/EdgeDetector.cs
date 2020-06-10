using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace Gmage
{
    public class EdgeDetector
    {
        public static Bitmap Robert(Bitmap initbitmap, int threshold)
        {
            if (initbitmap != null)
            {

                int Height = initbitmap.Height;
                int Width = initbitmap.Width;
                Bitmap bitmap = new Bitmap(Width, Height, PixelFormat.Format24bppRgb);
                Bitmap MyBitmap = initbitmap;
                BitmapData oldData = MyBitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb); //原图
                BitmapData newData = bitmap.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);  //新图即边缘图
                unsafe
                {
                    //首先第一段代码是提取边缘，边缘置为黑色，其他部分置为白色
                    byte* pin_1 = (byte*)(oldData.Scan0.ToPointer());
                    byte* pin_2 = pin_1 + (oldData.Stride);
                    byte* pout = (byte*)(newData.Scan0.ToPointer());
                    for (int y = 0; y < oldData.Height - 1; y++)
                    {
                        for (int x = 0; x < oldData.Width; x++)
                        {
                            //使用robert算子
                            double b = Math.Sqrt(((double)pin_1[0] - (double)(pin_2[0] + 3)) * ((double)pin_1[0] - (double)(pin_2[0] + 3)) + ((double)(pin_1[0] + 3) - (double)pin_2[0]) * ((double)(pin_1[0] + 3) - (double)pin_2[0]));
                            double g = Math.Sqrt(((double)pin_1[1] - (double)(pin_2[1] + 3)) * ((double)pin_1[1] - (double)(pin_2[1] + 3)) + ((double)(pin_1[1] + 3) - (double)pin_2[1]) * ((double)(pin_1[1] + 3) - (double)pin_2[1]));
                            double r = Math.Sqrt(((double)pin_1[2] - (double)(pin_2[2] + 3)) * ((double)pin_1[2] - (double)(pin_2[2] + 3)) + ((double)(pin_1[2] + 3) - (double)pin_2[2]) * ((double)(pin_1[2] + 3) - (double)pin_2[2]));
                            double bgr = (b + g + r) / 3;//一直在纠结要不要除以3，感觉没差，选阈值的时候调整一下就好了- -

                            if (bgr > threshold) //阈值，超过阈值判定为边缘（选取适当的阈值）
                            {
                                b = 255;
                                g = 255;
                                r = 255;

                            }
                            else
                            {
                                b = 0;
                                g = 0;
                                r = 0;
                            }
                            pout[0] = (byte)(b);
                            pout[1] = (byte)(g);
                            pout[2] = (byte)(r);
                            pin_1 = pin_1 + 3;
                            pin_2 = pin_2 + 3;
                            pout = pout + 3;

                        }
                        pin_1 += oldData.Stride - oldData.Width * 3;
                        pin_2 += oldData.Stride - oldData.Width * 3;
                        pout += newData.Stride - newData.Width * 3;
                    }
                    bitmap.UnlockBits(newData);
                    MyBitmap.UnlockBits(oldData);
                    return bitmap;
                }

            }
            return null;

        }


        //定义smoothed算子边缘检测函数
        public static Bitmap Smoothed(Bitmap bitmap)
        {
            int w = bitmap.Width;
            int h = bitmap.Height;
            try
            {
                Bitmap dstBitmap = new Bitmap(w, h, PixelFormat.Format24bppRgb);
                BitmapData srcData = bitmap.LockBits(new Rectangle
                 (0, 0, w, h), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
                BitmapData dstData = dstBitmap.LockBits(new Rectangle
                   (0, 0, w, h), ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
                unsafe
                {
                    byte* pIn = (byte*)srcData.Scan0.ToPointer();
                    byte* pOut = (byte*)dstData.Scan0.ToPointer();
                    byte* p;
                    int stride = srcData.Stride;
                    for (int y = 0; y < h; y++)
                    {
                        for (int x = 0; x < w; x++)
                        {
                            //边缘八个点像素不变
                            if (x == 0 || x == w - 1 || y == 0 || y == h - 1)
                            {
                                pOut[0] = pIn[0];
                                pOut[1] = pIn[1];
                                pOut[2] = pIn[2];
                            }
                            else
                            {
                                int r0, r1, r2, r3, r4, r5, r6, r7, r8;
                                int g1, g2, g3, g4, g5, g6, g7, g8, g0;
                                int b1, b2, b3, b4, b5, b6, b7, b8, b0;
                                double vR, vG, vB;
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
                                //左
                                p = pIn - 3;
                                r4 = p[2];
                                g4 = p[1];
                                b4 = p[0];
                                //右
                                p = pIn + 3;
                                r5 = p[2];
                                g5 = p[1];
                                b5 = p[0];
                                //左下
                                p = pIn + stride - 3;
                                r6 = p[2];
                                g6 = p[1];
                                b6 = p[0];
                                //正下
                                p = pIn + stride;
                                r7 = p[2];
                                g7 = p[1];
                                b7 = p[0];
                                // 右下 
                                p = pIn + stride + 3;
                                r8 = p[2];
                                g8 = p[1];
                                b8 = p[0];
                                //中心点
                                p = pIn;
                                r0 = p[2];
                                g0 = p[1];
                                b0 = p[0];
                                //使用模板
                                vR = (double)(Math.Abs(r3 + r5 + r8 - r1 - r4 - r6) + Math.Abs(r1 + r2 + r3 - r6 - r7 - r8));
                                vG = (double)(Math.Abs(g3 + g5 + g8 - g1 - g4 - g6) + Math.Abs(g1 + g2 + g3 - g6 - g7 - g8));
                                vB = (double)(Math.Abs(b3 + b5 + b8 - b1 - b4 - b6) + Math.Abs(b1 + b2 + b3 - b6 - b7 - b8));
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
                                //var gray = vB + vG + vR;
                                //pOut[0] = pOut[1] = pOut[2] = (byte)gray;
                                pOut[0] = (byte)vB;
                                pOut[1] = (byte)vG;
                                pOut[2] = (byte)vR;
                            }
                            pIn += 3;
                            pOut += 3;
                        }
                        pIn += srcData.Stride - w * 3;
                        pOut += srcData.Stride - w * 3;
                    }
                }
                bitmap.UnlockBits(srcData);
                dstBitmap.UnlockBits(dstData);
                return dstBitmap;
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// 骨架提取
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ToSkeleton(Bitmap img)
        {
            int i, j;
            bool[,] origin = new bool[img.Width, img.Height];
            bool[,] save = new bool[img.Width, img.Height];
            bool[] index = new bool[9];
            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    if (img.GetPixel(i, j).R == 0)
                        origin[i, j] = true;
                    else
                        origin[i, j] = false;
                }
            }

            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    save[i, j] = false;
                }
            }
            for (int n = 0; n < 5; n++)
            {
                img = ToErosion(img);
                for (i = 0; i < img.Width; i++)
                {
                    for (j = 0; j < img.Height; j++)
                    {
                        if (img.GetPixel(i, j).R == 0)
                            origin[i, j] = true;
                        else
                            origin[i, j] = false;
                    }
                }
                for (i = 0; i < img.Width; i++)
                {
                    for (j = 0; j < img.Height; j++)
                    {
                        if ((img.GetPixel(i, j).R == 0) == true || save[i, j] == true)
                            origin[i, j] = true;
                    }
                }

                //判断什么点存储进数组
                for (i = 1; i < img.Width - 1; i++)
                {
                    for (j = 1; j < img.Height - 1; j++)
                    {
                        index[0] = origin[i - 1, j - 1];
                        index[1] = origin[i, j - 1];
                        index[2] = origin[i + 1, j - 1];
                        index[3] = origin[i - 1, j];
                        index[4] = origin[i, j];
                        index[5] = origin[i + 1, j];
                        index[6] = origin[i - 1, j + 1];
                        index[7] = origin[i, j + 1];
                        index[8] = origin[i + 1, j + 1];
                        //012
                        //345
                        //678
                        if (index[4] == true &&
                            ((index[0] == true && index[1] == false && index[3] == false) ||
                            (index[1] == true && index[0] == false && index[2] == false) ||
                            (index[2] == true && index[1] == false && index[5] == false) ||
                            (index[3] == true && index[0] == false && index[6] == false) ||
                            (index[5] == true && index[2] == false && index[8] == false) ||
                            (index[6] == true && index[3] == false && index[7] == false) ||
                            (index[7] == true && index[6] == false && index[8] == false) ||
                            (index[8] == true && index[5] == false && index[7] == false)))
                            save[i, j] = true;
                        if (index[4] == true &&
                           ((index[0] == false && index[8] == false) ||
                           (index[1] == false && index[7] == false) ||
                           (index[2] == false && index[6] == false) ||
                           (index[3] == false && index[5] == false)))
                            save[i, j] = true;
                        int s = 0;
                        for (int x = 0; x < 9; x++)
                        {
                            if (index[x] == true)
                                s = s + 1;
                        }
                        if (index[4] == true && s < 5)
                            save[i, j] = true;
                    }
                }

            }

            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    if (save[i, j] == true)
                        img.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        img.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return img;
        }


        /// <summary>
        /// 高帽
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ToTopHap(Bitmap img)
        {
            int[,] result1 = new int[img.Width, img.Height];
            int[,] result2 = new int[img.Width, img.Height];
            int[,] result = new int[img.Width, img.Height];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result1[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }
            img = ToErosion(img);
            img = ToSwell(img);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result2[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result[i, j] = Math.Abs(result1[i, j] - result2[i, j]);
                }
            }
            img = Picture.GetPicture(img, result);
            return img;
        }

        public static Bitmap ToBoundary(Bitmap img)
        {
            int[,] result1 = new int[img.Width, img.Height];
            int[,] result2 = new int[img.Width, img.Height];
            int[,] result = new int[img.Width, img.Height];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result1[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }
            img = ToErosion(img);
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result2[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result[i, j] = Math.Abs(result1[i, j] - result2[i, j]);
                }
            }

            img = Picture.GetPicture(img, result);
            return img;
        }


        public static int Maxsort(int[] index)
        {
            int max = index[0];
            for (int i = 0; i < index.Length; i++)
                if (max < index[i])
                    max = index[i];
            return max;
        }

        /// <summary>
        /// 腐蚀（来消除小且无意义的物体）
        /// </summary>
        /// <param name="image">二值化图片</param>
        /// <returns></returns>
        public static Bitmap ToErosion(Bitmap img)
        {
            //注意二维数组的定义与C有所不同
            int[,] result = new int[img.Width, img.Height];
            int[,] max = new int[img.Width, img.Height];
            int[] index = new int[9];
            int i, j;

            for (i = 0; i < img.Width; i++)
            {
                for (j = 0; j < img.Height; j++)
                {
                    result[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }

            for (i = 1; i < img.Width - 1; i++)
            {
                for (j = 1; j < img.Height - 1; j++)
                {

                    index[0] = result[i - 1, j - 1];
                    index[1] = result[i, j - 1];
                    index[2] = result[i + 1, j - 1];
                    index[3] = result[i - 1, j];
                    index[4] = result[i, j];
                    index[5] = result[i + 1, j];
                    index[6] = result[i - 1, j + 1];
                    index[7] = result[i, j + 1];
                    index[8] = result[i + 1, j + 1];
                    max[i, j] = Maxsort(index);

                }
            }


            i = 0;
            for (j = 1; j < img.Height - 1; j++)
            {
                index[0] = 255;
                index[1] = result[i, j - 1];
                index[2] = result[i + 1, j - 1];
                index[3] = 255;
                index[4] = result[i, j];
                index[5] = result[i + 1, j];
                index[6] = 255;
                index[7] = result[i, j + 1];
                index[8] = result[i + 1, j + 1];
                max[i, j] = Maxsort(index);
            }
            i = img.Width - 1;
            for (j = 1; j < img.Height - 1; j++)
            {
                index[0] = result[i - 1, j - 1];
                index[1] = result[i, j - 1];
                index[2] = 255;
                index[3] = result[i - 1, j];
                index[4] = result[i, j];
                index[5] = 255;
                index[6] = result[i - 1, j + 1];
                index[7] = result[i, j + 1];
                index[8] = 255;
                max[i, j] = Maxsort(index);
            }
            j = 0;
            for (i = 1; i < img.Width - 1; i++)
            {
                index[0] = 255;
                index[1] = 255;
                index[2] = 255;
                index[3] = result[i - 1, j];
                index[4] = result[i, j];
                index[5] = result[i + 1, j];
                index[6] = result[i - 1, j + 1];
                index[7] = result[i, j + 1];
                index[8] = result[i + 1, j + 1];
                max[i, j] = Maxsort(index);
            }
            j = img.Height - 1;
            for (i = 1; i < img.Width - 1; i++)
            {
                index[0] = result[i - 1, j - 1];
                index[1] = result[i, j - 1];
                index[2] = result[i + 1, j - 1];
                index[3] = result[i - 1, j];
                index[4] = result[i, j];
                index[5] = result[i + 1, j];
                index[6] = 255;
                index[7] = 255;
                index[8] = 255;
                max[i, j] = Maxsort(index);
            }
            img = Picture.GetPicture(img, max);
            return img;
        }

        public static Bitmap ToSwell(Bitmap img)
        {
            //注意二维数组的定义与C有所不同
            int[,] result = new int[img.Width, img.Height];
            int[,] min = new int[img.Width, img.Height];
            int[] index = new int[9];

            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    result[i, j] = (img.GetPixel(i, j).R * 30 + img.GetPixel(i, j).G * 59 + img.GetPixel(i, j).B * 11 + 50) / 100;
                }
            }

            for (int i = 1; i < img.Width - 1; i++)
            {
                for (int j = 1; j < img.Height - 1; j++)
                {
                    index[0] = result[i - 1, j - 1];
                    index[1] = result[i, j - 1];
                    index[2] = result[i + 1, j - 1];
                    index[3] = result[i - 1, j];
                    index[4] = result[i, j];
                    index[5] = result[i + 1, j];
                    index[6] = result[i - 1, j + 1];
                    index[7] = result[i, j + 1];
                    index[8] = result[i + 1, j + 1];
                    min[i, j] = sort(index);

                }
            }

            img = Picture.GetPicture(img, min);
            return img;

        }
        public static int sort(int[] index)
        {
            int min = index[0];
            for (int i = 0; i < index.Length; i++)
                if (min > index[i])
                    min = index[i];
            return min;
        }
    }
}
