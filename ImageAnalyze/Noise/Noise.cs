using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Imaging;
namespace Gmage.Noise
{
    public class Noise
    {
        public Noise()
        {
           
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
        public static Bitmap Gauss_noise(Bitmap bitmap, double u = 0.5, double a = 0.1)
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
        /// <param name="initbitmap"></param>
        /// <param name="Pa"></param>
        /// <param name="Pb"></param>
        /// <returns></returns>
        public static Bitmap AddSalt(Bitmap initbitmap, double Pa = 0.001, double Pb = 0.001)
        {
            Bitmap bitmap = new Bitmap(initbitmap.Width, initbitmap.Height);
            int width = bitmap.Width;
            int height = bitmap.Height;
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
                        noise = 255;//有Pa的几率添加椒噪声
                    }
                    else
                    {
                        double temp = rand.NextDouble();
                        if (temp < Pb)//有Pb的几率添加盐噪声
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
                        var r = initbitmap.GetPixel(j, i).R;
                        var g = initbitmap.GetPixel(j, i).G;
                        var b = initbitmap.GetPixel(j, i).B;
                        color = Color.FromArgb(r, g, b);
                    }
                    bitmap.SetPixel(j, i, color);
                }
            }
            return bitmap;
        }

        /// <summary>
        /// 椒盐噪声 指针法
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap SaltP(Bitmap initbitmap, double Pa, double Pb)
        {
            Bitmap bitmap = initbitmap.Clone() as Bitmap; // 加载图像
            BitmapData bitmapdat = bitmap.LockBits(new Rectangle(Point.Empty, bitmap.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图
            Random rand = new Random();
            unsafe // 不安全代码
            {
                byte* pix = (byte*)bitmapdat.Scan0; // 像素首地址
                for (int i = 0; i < bitmapdat.Height; i++)
                {
                    for (int j = 0; j < bitmapdat.Width; j++)
                    {
                        //int gray;
                        //int noise = 1;
                        double probility = rand.NextDouble();
                        if (probility < Pa)
                            pix[0] = pix[1] = pix[2] = 255;
                        else
                        {
                            probility = rand.NextDouble();
                            if (probility < Pb)//有Pb的几率添加盐噪声
                                pix[0] = pix[1] = pix[2] = 0;
                        }
                        pix += 3;
                    }
                    pix += bitmapdat.Stride - bitmapdat.Width * 3;
                }
            }
            bitmap.UnlockBits(bitmapdat); // 解锁
            return bitmap;
        }


    }
}
