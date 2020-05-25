﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace ImageAnalyze
{
    public class Gauss
    {
        private double[,] GaussianBlur;//声明私有的高斯模糊卷积核函数         

        /// <summary>
        /// 构造卷积（Convolution）类函数
        /// </summary>
        public Gauss()
        {            //初始化高斯模糊卷积核            
            int k = 273;
            GaussianBlur = new double[5, 5]{{(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k},
                {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                {(double)7/k,(double)26/k,(double)41/k,(double)26/k,(double)7/k},
                {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                {(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k}};
        }

        /// <summary>
        /// 对图像进行平滑处理（利用高斯平滑Gaussian Blur)
        /// </summary>
        /// <param name="bitmap">要处理的位图</param>
        /// <returns>返回平滑处理后的位图</returns>
        public Bitmap Smooth(Bitmap bitmap)
        {
            int[,,] InputPicture = new int[3, bitmap.Width, bitmap.Height];//以GRB以及位图的长宽建立整数输入的位图的数组             
            Color color = new Color();//储存某一像素的颜色            //循环使得InputPicture数组得到位图的RGB            
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    color = bitmap.GetPixel(i, j);
                    InputPicture[0, i, j] = color.R;
                    InputPicture[1, i, j] = color.G;
                    InputPicture[2, i, j] = color.B;
                }
            }
            int[,,] OutputPicture = new int[3, bitmap.Width, bitmap.Height];//以GRB以及位图的长宽建立整数输出的位图的数组            
            Bitmap smooth = new Bitmap(bitmap.Width, bitmap.Height);//创建新位图            
                                                                    //循环计算使得OutputPicture数组得到计算后位图的RGB            
            for (int i = 0; i < bitmap.Width; i++)
            {
                for (int j = 0; j < bitmap.Height; j++)
                {
                    int R = 0;
                    int G = 0;
                    int B = 0;
                    //每一个像素计算使用高斯模糊卷积核进行计算                   
                    for (int r = 0; r < 5; r++)//循环卷积核的每一行                    
                    {
                        for (int f = 0; f < 5; f++)//循环卷积核的每一列            
                        {                            //控制与卷积核相乘的元素          
                            int row = i - 2 + r;
                            int index = j - 2 + f;
                            //当超出位图的大小范围时，选择最边缘的像素值作为该点的像素值   
                            row = row < 0 ? 0 : row;
                            index = index < 0 ? 0 : index;
                            row = row >= bitmap.Width ? bitmap.Width - 1 : row;
                            index = index >= bitmap.Height ? bitmap.Height - 1 : index;
                            //输出得到像素的RGB值                     
                            R += (int)(GaussianBlur[r, f] * InputPicture[0, row, index]);
                            G += (int)(GaussianBlur[r, f] * InputPicture[1, row, index]);
                            B += (int)(GaussianBlur[r, f] * InputPicture[2, row, index]);
                        }
                    }
                    color = Color.FromArgb(R, G, B);//颜色结构储存该点RGB     
                    smooth.SetPixel(i, j, color);//位图存储该点像素值     
                }
            }
            return smooth;
        }


        // <summary>
        /// 高斯密度函数
        /// </summary>
        /// <param name="z">随机数</param>
        /// <param name="u">数学期望</param>
        /// <param name="a">方差</param>
        /// <returns></returns>
        static double Gossp(double z, double u, double a)
        {
            double p;
            p = (1 / (a * Math.Sqrt(2 * Math.PI)) *
            Math.Pow(Math.E, -(Math.Pow(z - u, 2) / (2 * a * a))));
            return p;
        }
        /// <summary>
        /// 对一幅图形进行高斯噪音处理。
        /// </summary>
        /// <param name="img"></param>
        /// <param name="u">数学期望</param>
        /// <param name="a">方差</param>
        /// <returns></returns>
        public static Bitmap Goss_noise(Bitmap bitmap, double u=0.5, double a=0.1)
        {
            int width = bitmap.Width;
            int height = bitmap.Height;
            Bitmap bitmap2 = new Bitmap(bitmap);
            Rectangle rectangle1 = new Rectangle(0, 0, width, height);
            PixelFormat format = bitmap2.PixelFormat;
            BitmapData data = bitmap2.LockBits(rectangle1, ImageLockMode.ReadWrite, format);
            IntPtr ptr = data.Scan0;
            int numBytes = width * height * 4;
            byte[] rgbValues = new byte[numBytes];
            System.Runtime.InteropServices.Marshal.Copy(ptr, rgbValues, 0, numBytes);
            Random random1 = new Random();
            for (int i = 0; i < numBytes; i += 4)
            {
                for (int j = 0; j < 3; j++)
                {
                    double z;
                    z = random1.NextDouble() - 0.5 + u;
                    double pz = Gossp(z, u, a);
                    double r = random1.NextDouble();
                    // Debug.WriteLineIf(pz < 0.1, string.Format("z={0}\tpz={1}\tr={2}", z,pz,r));
                    if (r <= pz)
                    {
                        double p = rgbValues[i + j];
                        p = p + z * 128;
                        if (p > 255)
                            p = 255;
                        if (p < 0)
                            p = 0;
                        rgbValues[i + j] = (byte)p;
                    }
                }
            }
            System.Runtime.InteropServices.Marshal.Copy(rgbValues, 0, ptr, numBytes);
            bitmap2.UnlockBits(data);
            return bitmap2;
        }

        static int GetRandomSeed() //产生随机种子
        {
            byte[] bytes = new byte[4];
            System.Security.Cryptography.RNGCryptoServiceProvider rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
            rng.GetBytes(bytes);
            return BitConverter.ToInt32(bytes, 0);
        }

        static double GaussNiose()//用box muller的方法产生均值为0，方差为1的正太分布随机数
        {
            // Random ro = new Random(10);
            // long tick = DateTime.Now.Ticks;
            Random ran = new Random(GetRandomSeed());
            // Random rand = new Random();
            double r1 = ran.NextDouble();
            double r2 = ran.NextDouble();
            double result = Math.Sqrt((-2) * Math.Log(r2)) * Math.Sin(2 * Math.PI * r1);
            return result;//返回随机数
        }

        /// <summary>
        /// 添加椒盐噪声
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="Pa"></param>
        /// <param name="Pb"></param>
        /// <returns></returns>
        public static Bitmap AddSalt(Bitmap bitmap, double Pa=-1000, double Pb=1)
        {
            Bitmap Saltpic = new Bitmap(bitmap.Width, bitmap.Height);
            double P = Pb / (1 - Pa);//概率Pb 
            int width = Saltpic.Width;
            int height = Saltpic.Height;
            Random rand = new Random();
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int gray;
                    int noise = 1;
                    double probility = rand.NextDouble();
                    if (probility < Pa)
                    {
                        noise = 255;//有Pa概率 噪声设为最大值  
                    }
                    else
                    {
                        double temp = rand.NextDouble();
                        if (temp < P)//有1 - Pa的几率到达这里，再乘以 P ，刚好等于Pb  
                            noise = 0;
                    }
                    Color color;
                    if (noise != 1)
                    {
                        gray = noise;
                        color = Color.FromArgb(gray, gray, gray);
                    }
                    else
                    {
                        var r = bitmap.GetPixel(j, i).R;
                        var g = bitmap.GetPixel(j, i).G;
                        var b = bitmap.GetPixel(j, i).B;
                        color = Color.FromArgb(r, g, b);
                    }
                    Saltpic.SetPixel(j, i, color);
                }
            }
            return Saltpic;
        }


    }
}