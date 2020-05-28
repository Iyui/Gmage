using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageAnalyze
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

    }
}
