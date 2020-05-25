using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Imaging;
using AForge.Imaging;
using System.IO;

namespace ImageAnalyze
{
    public class Fourier
    {
        public static Bitmap FFT(Bitmap inputImage)
        {
            System.Drawing.Image sizeImage = new Bitmap(inputImage, 512, 512);
            //inputImage.Dispose();
            inputImage = (Bitmap)(sizeImage);
            inputImage = ColorToGrayscale(inputImage);
            ComplexImage finalImg = ComplexImage.FromBitmap(inputImage);
            finalImg.ForwardFourierTransform();
            //var data = finalImg.Data;
            return finalImg.ToBitmap();

        }

        //8位灰度图
        private static Bitmap ColorToGrayscale(Bitmap bmp)
        {
            int w = bmp.Width,
            h = bmp.Height,
            r, ic, oc, bmpStride, outputStride, bytesPerPixel;
            PixelFormat pfIn = bmp.PixelFormat;
            ColorPalette palette;
            BitmapData bmpData, outputData;
            Bitmap output;

            //Create the new bitmap
            output = new Bitmap(w, h, PixelFormat.Format8bppIndexed);

            //Build a grayscale color Palette
            palette = output.Palette;
            for (int i = 0; i < 256; i++)
            {
                Color tmp = Color.FromArgb(255, i, i, i);
                palette.Entries[i] = Color.FromArgb(255, i, i, i);
            }
            output.Palette = palette;

            //No need to convert formats if already in 8 bit
            if (pfIn == PixelFormat.Format8bppIndexed)
            {
                output = (Bitmap)bmp.Clone();

                //Make sure the palette is a grayscale palette and not some other
                //8-bit indexed palette
                output.Palette = palette;

                return output;
            }

            //Get the number of bytes per pixel
            switch (pfIn)
            {
                case PixelFormat.Format24bppRgb:
                    bytesPerPixel = 3;
                    break;
                case PixelFormat.Format32bppArgb:
                    bytesPerPixel = 4;
                    break;
                case PixelFormat.Format32bppRgb:
                    bytesPerPixel = 4;
                    break;
                default:
                    throw new InvalidOperationException("Image format not supported");

            }

            //Lock the images
            bmpData = bmp.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.ReadOnly,
            pfIn);
            outputData = output.LockBits(new Rectangle(0, 0, w, h), ImageLockMode.WriteOnly,
            PixelFormat.Format8bppIndexed);
            bmpStride = bmpData.Stride;
            outputStride = outputData.Stride;

            //Traverse each pixel of the image
            unsafe
            {
                byte* bmpPtr = (byte*)bmpData.Scan0.ToPointer(),
                outputPtr = (byte*)outputData.Scan0.ToPointer();

                if (bytesPerPixel == 3)
                {
                    //Convert the pixel to it's luminance using the formula:
                    // L = .299*R + .587*G + .114*B
                    //Note that ic is the input column and oc is the output column
                    for (r = 0; r < h; r++)
                        for (ic = oc = 0; oc < w; ic += 3, ++oc)
                            outputPtr[r * outputStride + oc] = (byte)(int)
                            (0.299f * bmpPtr[r * bmpStride + ic] +
                            0.587f * bmpPtr[r * bmpStride + ic + 1] +
                            0.114f * bmpPtr[r * bmpStride + ic + 2]);
                }
                else //bytesPerPixel == 4
                {
                    //Convert the pixel to it's luminance using the formula:
                    // L = alpha * (.299*R + .587*G + .114*B)
                    //Note that ic is the input column and oc is the output column
                    for (r = 0; r < h; r++)
                        for (ic = oc = 0; oc < w; ic += 4, ++oc)
                            outputPtr[r * outputStride + oc] = (byte)(int)
                            ((bmpPtr[r * bmpStride + ic] / 255.0f) *
                            (0.299f * bmpPtr[r * bmpStride + ic + 1] +
                            0.587f * bmpPtr[r * bmpStride + ic + 2] +
                            0.114f * bmpPtr[r * bmpStride + ic + 3]));
                }
            }

            //Unlock the images
            bmp.UnlockBits(bmpData);
            output.UnlockBits(outputData);

            return output;
        }

        /*
        ///// <summary>
        ///// 一维频率抽取基2快速傅里叶变换
        ///// 频率抽取：输入为自然顺序，输出为码位倒置顺序
        ///// 基2：待变换的序列长度必须为2的整数次幂
        ///// </summary>
        ///// <param name="sourceData">待变换的序列(复数数组)</param>
        ///// <param name="countN">序列长度,可以指定[0,sourceData.Length-1]区间内的任意数值</param>
        ///// <returns>返回变换后的序列（复数数组）</returns>
        //private Complex[] fft_frequency(Complex[] sourceData, int countN)
        //{
        //    //2的r次幂为N，求出r.r能代表fft算法的迭代次数
        //    int r = Convert.ToInt32(Math.Log(countN, 2));


        //    //分别存储蝶形运算过程中左右两列的结果
        //    Complex[] interVar1 = new Complex[countN];
        //    Complex[] interVar2 = new Complex[countN];
        //    interVar1 = (Complex[])sourceData.Clone();

        //    //w代表旋转因子
        //    Complex[] w = new Complex[countN / 2];
        //    //为旋转因子赋值。（在蝶形运算中使用的旋转因子是已经确定的，提前求出以便调用）
        //    //旋转因子公式 \  /\  /k __
        //    //              \/  \/N  --  exp(-j*2πk/N)
        //    //这里还用到了欧拉公式
        //    for (int i = 0; i < countN / 2; i++)
        //    {
        //        double angle = -i * Math.PI * 2 / countN;
        //        w[i] = new Complex(Math.Cos(angle), Math.Sin(angle));
        //    }

        //    //蝶形运算
        //    for (int i = 0; i < r; i++)
        //    {
        //        //i代表当前的迭代次数，r代表总共的迭代次数.
        //        //i记录着迭代的重要信息.通过i可以算出当前迭代共有几个分组，每个分组的长度

        //        //interval记录当前有几个组
        //        // <<是左移操作符，左移一位相当于*2
        //        //多使用位运算符可以人为提高算法速率^_^
        //        int interval = 1 << i;

        //        //halfN记录当前循环每个组的长度N
        //        int halfN = 1 << (r - i);

        //        //循环，依次对每个组进行蝶形运算
        //        for (int j = 0; j < interval; j++)
        //        {
        //            //j代表第j个组

        //            //gap=j*每组长度，代表着当前第j组的首元素的下标索引
        //            int gap = j * halfN;

        //            //进行蝶形运算
        //            for (int k = 0; k < halfN / 2; k++)
        //            {
        //                interVar2[k + gap] = interVar1[k + gap] + interVar1[k + gap + halfN / 2];
        //                interVar2[k + halfN / 2 + gap] = (interVar1[k + gap] - interVar1[k + gap + halfN / 2]) * w[k * interval];
        //            }
        //        }

        //        //将结果拷贝到输入端，为下次迭代做好准备
        //        interVar1 = (Complex[])interVar2.Clone();
        //    }

        //    //将输出码位倒置
        //    for (uint j = 0; j < countN; j++)
        //    {
        //        //j代表自然顺序的数组元素的下标索引

        //        //用rev记录j码位倒置后的结果
        //        uint rev = 0;
        //        //num作为中间变量
        //        uint num = j;

        //        //码位倒置（通过将j的最右端一位最先放入rev右端，然后左移，然后将j的次右端一位放入rev右端，然后左移...）
        //        //由于2的r次幂=N，所以任何j可由r位二进制数组表示，循环r次即可
        //        for (int i = 0; i < r; i++)
        //        {
        //            rev <<= 1;
        //            rev |= num & 1;
        //            num >>= 1;
        //        }
        //        interVar2[rev] = interVar1[j];
        //    }
        //    return interVar2;

        //}

        ///// <summary>
        ///// 一维频率抽取基2快速傅里叶逆变换
        ///// </summary>
        ///// <param name="sourceData">待反变换的序列（复数数组）</param>
        ///// <param name="countN">序列长度,可以指定[0,sourceData.Length-1]区间内的任意数值</param>
        ///// <returns>返回逆变换后的序列（复数数组）</returns>
        //private Complex[] ifft_frequency(Complex[] sourceData, int countN)
        //{
        //    //将待逆变换序列取共轭，再调用正变换得到结果，对结果统一再除以变换序列的长度N

        //    for (int i = 0; i < countN; i++)
        //    {
        //        sourceData[i] = sourceData[i].Conjugate();
        //    }

        //    Complex[] interVar = new Complex[countN];

        //    interVar = fft_frequency(sourceData, countN);

        //    for (int i = 0; i < countN; i++)
        //    {
        //        interVar[i] = new Complex(interVar[i].Real / countN, -interVar[i].Imaginary / countN);
        //    }

        //    return interVar;
        //}

        public static void FFT(Complex[] t, Complex[] f, int r)   // t为时域，f为频域 r为2的幂数
        {
            long count;
            int i, j, k, p, bsize;
            Complex[] W;
            Complex[] X1;
            Complex[] X2;
            Complex[] X;
            Complex comp = new Complex();
            double angle;  // 计算加权时所需角度
            count = 1 << r;

            W = new Complex[count / 2];
            X1 = new Complex[count];
            X2 = new Complex[count];
            X = new Complex[count];
            for (i = 0; i < count / 2; i++)
            {
                angle = i * Math.PI * 2 / count;
                W[i] = new Complex
                {
                    Real = (double)Math.Cos(angle),
                    Imaginary = -(double)Math.Sin(angle)
                };
                
            }
            for (i = 0; i < count; i++)
            {
                X2[i] = new Complex();
                X[i] = new Complex();
            }
                t.CopyTo(X1, 0);

            for (k = 0; k < r; k++)
            {
                for (j = 0; j < 1 << k; j++)
                {
                    bsize = 1 << (r - k);
                    for (i = 0; i < bsize / 2; i++)
                    {
                        p = j * bsize;
                        X2[i + p] = new Complex
                        {
                            Imaginary = X1[i + p].Imaginary + X1[i + p + bsize / 2].Imaginary,
                            Real = X1[i + p].Real + X1[i + p + bsize / 2].Real
                        };

                        comp.Imaginary = X1[i + p].Imaginary - X1[i + p + bsize / 2].Imaginary;
                        comp.Real = X1[i + p].Real - X1[i + p + bsize / 2].Real;

                        X2[i + p + bsize / 2].Real = comp.Real * W[i * (1 << k)].Real -
                            comp.Imaginary * W[i * (1 << k)].Imaginary;
                        X2[i + p + bsize / 2].Imaginary = comp.Real * W[i * (1 << k)].Imaginary +
                         comp.Imaginary * W[i * (1 << k)].Real; ;
                    }
                }
                X = X1;
                X1 = X2;
                X2 = X;
            }

            for (j = 0; j < count; j++)
            {
                p = 0;
                for (i = 0; i < r; i++)
                {
                    if ((j & (1 << i)) != 0)
                    {
                        p += 1 << (r - i - 1);
                    }
                }
                f[j] = new Complex
                {
                    Real = X1[p].Real,
                    Imaginary = X1[p].Imaginary
                };
            }
        }

        // 二维傅立叶变换
        public static Bitmap BitmapFFT(Bitmap tp)
        {
            // 原图像的宽与高
            int w = tp.Width;
            int h = tp.Height;
            // 傅立叶变换的实际宽高
            long lw = 1;
            long lh = 1;
            // 迭代次数
            int wp = 0; int hp = 0;
            long i, j;
            long n, m;
            double temp;
            byte[] ky = new byte[w * h];
            ky = ImageByte.ImageToByte(tp);
            Complex[] t; Complex[] f;

            while (lw * 2 <= w)
            {
                lw *= 2;
                wp++;
            }
            while (lh * 2 <= h)
            {
                lh *= 2;
                hp++;
            }
            t = new Complex[lw * lh];
            f = new Complex[lw * lh];
            Complex[] tw = new Complex[lw];
            Complex[] th = new Complex[lw];
            for (i = 0; i < lh; i++)
            {
                for (j = 0; j < lw; j++)
                {
                    t[i * lw + j] = new Complex
                    {
                        Real = ky[i * w + j],
                        Imaginary = 0
                    };
                }
            }
            for (i = 0; i < lh; i++) // 垂直方向傅立叶变换
            {

                Array.Copy(t, i * lw, tw, 0, lw);
                Array.Copy(f, i * lw, th, 0, lw);
                FFT(tw, th, wp);
                // Array.Copy(tw, 0, t, i * lw, lw);
                Array.Copy(th, 0, f, i * lw, lw);
            }

            for (i = 0; i < lh; i++)
            {
                for (j = 0; j < lw; j++)
                {
                    t[j * lh + i].Real = f[i * lw + j].Real;
                    t[j * lh + i].Imaginary = f[i * lw + j].Imaginary;
                }
            }

            Complex[] ow = new Complex[lh];
            Complex[] oh = new Complex[lh];
            for (i = 0; i < lw; i++)
            {
                Array.Copy(t, i * lh, ow, 0, lh);
                Array.Copy(f, i * lh, oh, 0, lh);
                FFT(ow, oh, hp);
                //Array.Copy(ow, 0, t, i * lh, lh);
                oh.CopyTo(f, i * lh);
            }

            for (i = 0; i < lh; i++)
            {
                for (j = 0; j < lw; j++)
                {
                    temp = Math.Sqrt(f[j * lh + i].Real * f[j * lh + i].Real + f[j * lh + i].Imaginary * f[j * lh + i].Imaginary) / 100;
                    if (temp > 255)
                    {
                        temp = 255;
                    }
                    n = i < lh / 2 ? i + lh / 2 : i - lh / 2;
                    m = j < lw / 2 ? j + lw / 2 : j - lw / 2;
                    ky[n * w + m] = (byte)temp;
                }
            }
            tp = ImageByte.BytetoImage(ky);
            return tp;

        }
         */
    }



    /*
    /// <summary>
    /// 复数类
    /// </summary>
    public class Complex
    {

        #region 属性

        /// <summary>
        /// 获取或设置复数的实部
        /// </summary>
        public double Real { get; set; } = 0.0;

        /// <summary>
        /// 获取或设置复数的虚部
        /// </summary>
        public double Imaginary { get; set; } = 0.0;

        #endregion


        #region 构造函数

        /// <summary>
        /// 默认构造函数，得到的复数为0
        /// </summary>
        public Complex()
            : this(0, 0)
        {

        }

        /// <summary>
        /// 只给实部赋值的构造函数，虚部将取0
        /// </summary>
        /// <param name="dbreal">实部</param>
        public Complex(double dbreal)
            : this(dbreal, 0)
        {

        }

        /// <summary>
        /// 一般形式的构造函数
        /// </summary>
        /// <param name="dbreal">实部</param>
        /// <param name="dbImage">虚部</param>
        public Complex(double dbreal, double dbImage)
        {
            Real = dbreal;
            Imaginary = dbImage;
        }

        /// <summary>
        /// 以拷贝另一个复数的形式赋值的构造函数
        /// </summary>
        /// <param name="other">复数</param>
        public Complex(Complex other)
        {
            Real = other.Real;
            Imaginary = other.Imaginary;
        }

        #endregion

        #region 重载

        //加法的重载
        public static Complex operator +(Complex comp1, Complex comp2)
        {
            return comp1.Add(comp2);
        }

        //减法的重载
        public static Complex operator -(Complex comp1, Complex comp2)
        {
            return comp1.Substract(comp2);
        }

        //乘法的重载
        public static Complex operator *(Complex comp1, Complex comp2)
        {
            return comp1.Multiply(comp2);
        }

        //==的重载
        public static bool operator ==(Complex z1, Complex z2)
        {
            return ((z1.Real == z2.Real) && (z1.Imaginary == z2.Imaginary));
        }

        //!=的重载
        public static bool operator !=(Complex z1, Complex z2)
        {
            if (z1.Real == z2.Real)
            {
                return (z1.Imaginary != z2.Imaginary);
            }
            return true;
        }

        /// <summary>
        /// 重载ToString方法,打印复数字符串
        /// </summary>
        /// <returns>打印字符串</returns>
        public override string ToString()
        {
            if (Real == 0 && Imaginary == 0)
            {
                return string.Format("{0}", 0);
            }
            if (Real == 0 && (Imaginary != 1 && Imaginary != -1))
            {
                return string.Format("{0} i", Imaginary);
            }
            if (Imaginary == 0)
            {
                return string.Format("{0}", Real);
            }
            if (Imaginary == 1)
            {
                return string.Format("i");
            }
            if (Imaginary == -1)
            {
                return string.Format("- i");
            }
            if (Imaginary < 0)
            {
                return string.Format("{0} - {1} i", Real, -Imaginary);
            }
            return string.Format("{0} + {1} i", Real, Imaginary);
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 复数加法
        /// </summary>
        /// <param name="comp">待加复数</param>
        /// <returns>返回相加后的复数</returns>
        public Complex Add(Complex comp)
        {
            double x = Real + comp.Real;
            double y = Imaginary + comp.Imaginary;

            return new Complex(x, y);
        }

        /// <summary>
        /// 复数减法
        /// </summary>
        /// <param name="comp">待减复数</param>
        /// <returns>返回相减后的复数</returns>
        public Complex Substract(Complex comp)
        {
            double x = Real - comp.Real;
            double y = Imaginary - comp.Imaginary;

            return new Complex(x, y);
        }

        /// <summary>
        /// 复数乘法
        /// </summary>
        /// <param name="comp">待乘复数</param>
        /// <returns>返回相乘后的复数</returns>
        public Complex Multiply(Complex comp)
        {
            double x = Real * comp.Real - Imaginary * comp.Imaginary;
            double y = Real * comp.Imaginary + Imaginary * comp.Real;

            return new Complex(x, y);
        }

        /// <summary>
        /// 获取复数的模/幅度
        /// </summary>
        /// <returns>返回复数的模</returns>
        public double GetModul()
        {
            return Math.Sqrt(Real * Real + Imaginary * Imaginary);
        }

        /// <summary>
        /// 获取复数的相位角，取值范围（-π，π]
        /// </summary>
        /// <returns>返回复数的相角</returns>
        public double GetAngle()
        {
            #region 原先求相角的实现，后发现Math.Atan2已经封装好后注释
            ////实部和虚部都为0
            //if (real == 0 && imaginary == 0)
            //{
            //    return 0;
            //}
            //if (real == 0)
            //{
            //    if (imaginary > 0)
            //        return Math.PI / 2;
            //    else
            //        return -Math.PI / 2;
            //}
            //else
            //{
            //    if (real > 0)
            //    {
            //        return Math.Atan2(imaginary, real);
            //    }
            //    else
            //    {
            //        if (imaginary >= 0)
            //            return Math.Atan2(imaginary, real) + Math.PI;
            //        else
            //            return Math.Atan2(imaginary, real) - Math.PI;
            //    }
            //}
            #endregion

            return Math.Atan2(Imaginary, Real);
        }

        /// <summary>
        /// 获取复数的共轭复数
        /// </summary>
        /// <returns>返回共轭复数</returns>
        public Complex Conjugate()
        {
            return new Complex(this.Real, -this.Imaginary);
        }

        #endregion
    }

    public class ImageByte
    {
        public static Bitmap BytetoImage(byte[] streamByte)
        {
            MemoryStream ms = new MemoryStream(streamByte,0, streamByte.Count());
            // Bitmap BMP = new Bitmap(ms);
            Image img = Image.FromStream(ms,true);
            return (Bitmap)img;
        }
        //将Image转换成流数据，并保存为byte[] 
        public static byte[] ImageToByte(Image img)
        {
            MemoryStream mstream = new MemoryStream();
            img.Save(mstream, System.Drawing.Imaging.ImageFormat.Bmp);
            byte[] byData = new byte[mstream.Length];
            mstream.Position = 0;
            mstream.Read(byData, 0, byData.Length); mstream.Close();
            return byData;
        }
    }
    */
}