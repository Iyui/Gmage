using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;

namespace Gmage.Process
{

    /// <summary>
    /// 提供对位图图像和颜色的一系列操作的对象
    /// </summary>
    public class Thin
    {
        /// <summary> 
        /// 基于RGB根据指定阈值判断两个颜色是否相近
        /// </summary> 
        public bool CompareRGB(Color Color1, Color Color2, float Distance)
        {

            int r = Convert.ToInt16(Color1.R) - Convert.ToInt16(Color2.R);
            int g = Convert.ToInt16(Color1.G) - Convert.ToInt16(Color2.G);
            int b = Convert.ToInt16(Color1.B) - Convert.ToInt16(Color2.B);
            int absDis = (int)Math.Sqrt(r * r + g * g + b * b);
            if (absDis < Distance)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary> 
        /// 基于HSB根据指定阈值判断两个颜色是否相近
        /// </summary> 
        public bool CompareHSB(Color Color1, Color Color2, float Distance)
        {
            //向量距离
            //Dim h As Single = (Color1.GetHue - Color2.GetHue) / 360
            //Dim s As Single = Color1.GetSaturation - Color2.GetSaturation
            //Dim b As Single = Color1.GetBrightness - Color2.GetBrightness
            //Dim absDis As Single = Math.Sqrt(h * h + s * s + b * b)
            //If absDis < Distance Then
            //    Return True
            //Else
            //    Return False
            //End If
            //向量夹角
            float h1 = Color1.GetHue() / 360;
            float s1 = Color1.GetSaturation();
            float b1 = Color1.GetBrightness();
            float h2 = Color2.GetHue() / 360;
            float s2 = Color2.GetSaturation();
            float b2 = Color2.GetBrightness();
            float absDis = (float)((h1 * h2 + s1 * s2 + b1 * b2) / (Math.Sqrt(h1 * h1 + s1 * s1 + b1 * b1) * Math.Sqrt(h2 * h2 + s2 * s2 + b2 * b2)));
            if (absDis > Distance / 5 + 0.8)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        /// <summary> 
        /// 返回指定颜色的中值
        /// </summary> 
        public object gethHD(Color color1)
        {
            int HD = 0;
            int r = 0;
            int g = 0;
            int b = 0;
            r = color1.R;
            g = color1.G;
            b = color1.B;
            HD = (r + g + b) / 3;
            return HD;
        }
        /// <summary>
        /// 返回指定位图的颜色数组
        /// </summary>
        /// <param name="gBitmap"></param>
        /// <returns></returns>
        public Color[,] GetColorArr(ref Bitmap gBitmap)
        {
            Color[,] TempArr = new Color[gBitmap.Width, gBitmap.Height];
            for (int i = 0; i <= gBitmap.Width - 1; i++)
            {
                for (int j = 0; j <= gBitmap.Height - 1; j++)
                {
                    TempArr[i, j] = gBitmap.GetPixel(i, j);
                }
            }
            return TempArr;
        }



        /// <summary>
        /// 返回指定位图的轮廓图像
        /// </summary>
        /// <param name="gBitmap"></param>
        /// <param name="gDistance"></param>
        /// <returns></returns>
        public Bitmap GetOutLineImage(Bitmap gBitmap, float gDistance, bool IsHSB = false)
        {
            short[] xArray2 = {
            0,
            1,
            0,
            -1
            };
            short[] yArray2 = {
            -1,
            0,
            1,
            0
            };
            //Dim ResultBitmap As New Bitmap(gBitmap) '在原图的基础上绘图
            Bitmap ResultBitmap = new Bitmap(gBitmap.Width, gBitmap.Height);
            Color Color1 = default(Color);
            Color Color2 = default(Color);
            var ColorArr = GetColorArr(ref gBitmap);
            for (int i = 1; i <= gBitmap.Width - 2; i++)
            {
                for (int j = 1; j <= gBitmap.Height - 2; j++)
                {
                    ResultBitmap.SetPixel(i, j, Color.White);
                    Color1 = ColorArr[i, j];
                    for (int p = 0; p <= 3; p++)
                    {
                        Color2 = ColorArr[i + xArray2[p], j + yArray2[p]];
                        if (!CompareColor(Color1, Color2, gDistance, IsHSB) & CompareColorExtra(Color1, Color2, IsHSB))
                        {
                            ResultBitmap.SetPixel(i, j, Color.Black);
                            // ResultBitmap.SetPixel(i, j, ColorArr[i, j])
                        }
                    }
                }
            }
            return ResultBitmap;
        }

        dynamic CompareColor (Color C1, Color C2, float Distance, bool IsHSB = false)
        {
            Color Color1 = default(Color);
            Color Color2 = default(Color);
            return IsHSB ? CompareHSB(Color1, Color2, Distance) : CompareRGB(Color1, Color2, Distance);
        }

        dynamic CompareColorExtra(Color C1, Color C2, bool IsHSB = false)
        {
            Color Color1 = default(Color);
            Color Color2 = default(Color);
            return IsHSB ? Color1.GetBrightness() - Color2.GetBrightness() > 0 : (int)gethHD(Color1) - (int)gethHD(Color2) > 0;
        }

        public static unsafe Bitmap ToThinner(Bitmap srcImg)
        {
            int iw = srcImg.Width;
            int ih = srcImg.Height;


            bool bModified;     //二值图像修改标志
            bool bCondition1;   //细化条件1标志
            bool bCondition2;   //细化条件2标志
            bool bCondition3;   //细化条件3标志
            bool bCondition4;   //细化条件4标志


            int nCount;


            //5X5像素块
            byte[,] neighbour = new byte[5, 5];
            //新建临时存储图像
            Bitmap NImg = new Bitmap(iw, ih, srcImg.PixelFormat);


            bModified = true;     //细化修改标志, 用作循环条件


            BitmapData dstData = srcImg.LockBits(new Rectangle(0, 0, iw, ih), ImageLockMode.ReadWrite, srcImg.PixelFormat);
            byte* data = (byte*)(dstData.Scan0);
            //将图像转换为0,1二值得图像;
            int step = dstData.Stride;
            for (int i = 0; i < dstData.Height; i++)
            {
                for (int j = 0; j < dstData.Width; j++)
                {
                    if (data[i * step + j] > 128)
                        data[i * step + j] = 0;
                    else
                        data[i * step + j] = 1;
                }
            }


            BitmapData dstData1 = NImg.LockBits(new Rectangle(0, 0, iw, ih), ImageLockMode.ReadWrite, NImg.PixelFormat);
            byte* data1 = (byte*)(dstData1.Scan0);
            int step1 = dstData1.Stride;
            //细化循环开始
            while (bModified)
            {
                bModified = false;


                //初始化临时二值图像NImg
                for (int i = 0; i < dstData1.Height; i++)
                {
                    for (int j = 0; j < dstData1.Width; j++)
                    {
                        data1[i * step1 + j] = 0;
                    }
                }


                for (int i = 2; i < ih - 2; i++)
                {
                    for (int j = 2; j < iw - 2; j++)
                    {
                        bCondition1 = false;
                        bCondition2 = false;
                        bCondition3 = false;
                        bCondition4 = false;


                        if (data[i * step + j] == 0)       //若图像的当前点为白色，则跳过
                            continue;
                        for (int k = 0; k < 5; k++)
                        {
                            //取以当前点为中心的5X5块
                            for (int l = 0; l < 5; l++)
                            {
                                //1代表黑色, 0代表白色
                                //neighbour[k, l] = bw[i + k - 2, j + l - 2];
                                neighbour[k, l] = data[(i + k - 2) * step + (j + l - 2)];
                            }
                        }


                        //(1)判断条件2<=n(p)<=6
                        nCount = neighbour[1, 1] + neighbour[1, 2] + neighbour[1, 3] +
                neighbour[2, 1] + neighbour[2, 3] +
                neighbour[3, 1] + neighbour[3, 2] + neighbour[3, 3];
                        if (nCount >= 2 && nCount <= 6)
                            bCondition1 = true;
                        else
                        {
                            data1[i * step1 + j] = 1;
                            continue;       //跳过, 加快速度
                        }


                        //(2)判断s(p)=1
                        nCount = 0;
                        if (neighbour[2, 3] == 0 && neighbour[1, 3] == 1)
                            nCount++;
                        if (neighbour[1, 3] == 0 && neighbour[1, 2] == 1)
                            nCount++;
                        if (neighbour[1, 2] == 0 && neighbour[1, 1] == 1)
                            nCount++;
                        if (neighbour[1, 1] == 0 && neighbour[2, 1] == 1)
                            nCount++;
                        if (neighbour[2, 1] == 0 && neighbour[3, 1] == 1)
                            nCount++;
                        if (neighbour[3, 1] == 0 && neighbour[3, 2] == 1)
                            nCount++;
                        if (neighbour[3, 2] == 0 && neighbour[3, 3] == 1)
                            nCount++;
                        if (neighbour[3, 3] == 0 && neighbour[2, 3] == 1)
                            nCount++;
                        if (nCount == 1)
                            bCondition2 = true;
                        else
                        {
                            data1[i * step1 + j] = 1;
                            continue;
                        }


                        //(3)判断p0*p2*p4=0 or s(p2)!=1
                        if (neighbour[2, 3] * neighbour[1, 2] * neighbour[2, 1] == 0)
                            bCondition3 = true;
                        else
                        {
                            nCount = 0;
                            if (neighbour[0, 2] == 0 && neighbour[0, 1] == 1)
                                nCount++;
                            if (neighbour[0, 1] == 0 && neighbour[1, 1] == 1)
                                nCount++;
                            if (neighbour[1, 1] == 0 && neighbour[2, 1] == 1)
                                nCount++;
                            if (neighbour[2, 1] == 0 && neighbour[2, 2] == 1)
                                nCount++;
                            if (neighbour[2, 2] == 0 && neighbour[2, 3] == 1)
                                nCount++;
                            if (neighbour[2, 3] == 0 && neighbour[1, 3] == 1)
                                nCount++;
                            if (neighbour[1, 3] == 0 && neighbour[0, 3] == 1)
                                nCount++;
                            if (neighbour[0, 3] == 0 && neighbour[0, 2] == 1)
                                nCount++;
                            if (nCount != 1) //s(p2)!=1
                                bCondition3 = true;
                            else
                            {
                                data1[i * step1 + j] = 1;
                                continue;
                            }
                        }


                        //(4)判断p2*p4*p6=0 or s(p4)!=1
                        if (neighbour[1, 2] * neighbour[2, 1] * neighbour[3, 2] == 0)
                            bCondition4 = true;
                        else
                        {
                            nCount = 0;
                            if (neighbour[1, 1] == 0 && neighbour[1, 0] == 1)
                                nCount++;
                            if (neighbour[1, 0] == 0 && neighbour[2, 0] == 1)
                                nCount++;
                            if (neighbour[2, 0] == 0 && neighbour[3, 0] == 1)
                                nCount++;
                            if (neighbour[3, 0] == 0 && neighbour[3, 1] == 1)
                                nCount++;
                            if (neighbour[3, 1] == 0 && neighbour[3, 2] == 1)
                                nCount++;
                            if (neighbour[3, 2] == 0 && neighbour[2, 2] == 1)
                                nCount++;
                            if (neighbour[2, 2] == 0 && neighbour[1, 2] == 1)
                                nCount++;
                            if (neighbour[1, 2] == 0 && neighbour[1, 1] == 1)
                                nCount++;
                            if (nCount != 1)//s(p4)!=1
                                bCondition4 = true;


                        }
                        if (bCondition1 && bCondition2 && bCondition3 && bCondition4)
                        {
                            data1[i * step1 + j] = 0;
                            bModified = true;
                        }
                        else
                        {
                            data1[i * step1 + j] = 1;
                        }
                    }
                }


                //将细化了的临时图像bw_tem[w,h]copy到bw[w,h],完成一次细化
                for (int i = 2; i < ih - 2; i++)
                    for (int j = 2; j < iw - 2; j++)
                        data[i * step + j] = data1[i * step1 + j];
            }


            for (int i = 2; i < ih - 2; i++)
            {
                for (int j = 2; j < iw - 2; j++)
                {
                    if (data[i * step + j] == 1)
                        data[i * step + j] = 0;
                    else
                        data[i * step + j] = 255;
                }
            }
            srcImg.UnlockBits(dstData);
            NImg.UnlockBits(dstData1);
            return (srcImg);
        }



    }
}


