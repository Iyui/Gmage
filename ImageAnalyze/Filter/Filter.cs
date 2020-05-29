using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing.Imaging;
using System.Drawing;
namespace Gmage.Filter
{
    public class Filter
    {
        private double[,] GaussianBlur;//声明私有的高斯模糊卷积核函数            

        int k = 273;
        // 构造卷积
        public Filter()
        {
            //初始化高斯模糊卷积核            
            GaussianBlur = new double[5, 5]{{(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k},
                {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                {(double)7/k,(double)26/k,(double)41/k,(double)26/k,(double)7/k},
                {(double)4/k,(double)16/k,(double)26/k,(double)16/k,(double)4/k},
                {(double)1/k,(double)4/k,(double)7/k,(double)4/k,(double)1/k}};
        }
        /// <summary>
        /// 高斯平滑（高斯模糊）
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

        /// <summary>
        /// 高斯平滑 指针法
        /// </summary>
        /// <param name="bitmap">要处理的位图</param>
        /// <returns>返回平滑处理后的位图</returns>
        public Bitmap GaussSmooth(Bitmap bitmap)
        {
            Bitmap src = (Bitmap)bitmap.Clone(); // 加载图像
            Bitmap srcResult = new Bitmap(src.Width, src.Height); // 加载图像

            BitmapData srcdat = src.LockBits(new Rectangle(Point.Empty, src.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图
            BitmapData srcdatResult = srcResult.LockBits(new Rectangle(Point.Empty, srcResult.Size), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb); // 锁定位图

            unsafe // 不安全代码
            {
                fixed (double* pG = GaussianBlur)
                {
                    byte* p = (byte*)srcdat.Scan0; // 像素首地址
                    byte* pR = (byte*)srcdatResult.Scan0; // 像素首地址
                    for (int i = 0; i < srcdat.Width; i++)
                    {
                        for (int j = 0; j < srcdat.Height; j++)
                        {
                            //每一个像素计算使用高斯模糊卷积核进行计算                   
                            for (int r = 0; r < GaussianBlur.GetLength(0); r++)//循环卷积核的每一行                    
                            {
                                for (int f = 0; f < GaussianBlur.GetLength(1); f++)//循环卷积核的每一列            
                                {                            //控制与卷积核相乘的元素          
                                    int row = i - 2 + r;
                                    int index = j - 2 + f;
                                    //当超出位图的大小范围时，选择最边缘的像素值作为该点的像素值   
                                    row = row < 0 ? 0 : row;
                                    index = index < 0 ? 0 : index;
                                    row = row >= bitmap.Width ? bitmap.Width - 1 : row;
                                    index = index >= bitmap.Height ? bitmap.Height - 1 : index;
                                    //输出得到像素的RGB值                     
                                    pR[j * srcdat.Stride] += (byte)(pG[r * 5 + f] * p[row * 3 + index * srcdat.Stride]);
                                    pR[j * srcdat.Stride + 1] += (byte)(pG[r * 5 + f] * p[row * 3 + index * srcdat.Stride + 1]);
                                    pR[j * srcdat.Stride + 2] += (byte)(pG[r * 5 + f] * p[row * 3 + index * srcdat.Stride + 2]);
                                }
                            }
                        }
                        pR += 3;
                        pR += srcdat.Stride - srcdat.Width * 3;
                    }
                };
            }
            src.UnlockBits(srcdat); // 解锁
            srcResult.UnlockBits(srcdatResult); // 解锁
            return srcResult;
        }

        /// <summary>
        /// 中值滤波
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public static Bitmap MedianFilter(Bitmap bitmap)
        {

            Bitmap pic = bitmap.Clone() as Bitmap;
            int width = pic.Width;
            int height = pic.Height;
            int[,] resultPicR = new int[height, width];
            int[,] resultPicG = new int[height, width];
            int[,] resultPicB = new int[height, width];
            int indexR, indexG, indexB;
            int[] filterR = new int[9];
            int[] filterG = new int[9];
            int[] filterB = new int[9];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    indexR= indexG= indexB = 0;
                    int R,G,B;
                    for (int ii = -1; ii < 2; ii++)
                    {
                        for (int jj = -1; jj < 2; jj++)
                        {
                            if (j + jj >= 0 && j + jj < width && i + ii >= 0 && i + ii < height)
                            {
                                R = pic.GetPixel(j + jj, i + ii).R;
                                G = pic.GetPixel(j + jj, i + ii).G;
                                B = pic.GetPixel(j + jj, i + ii).B;
                            }
                            else { R=G=B=0; }
                            //R
                            if (indexR == 0) { filterR[indexR] = R; indexR++; }
                            else
                            {
                                if (R >= filterR[indexR - 1])
                                {
                                    filterR[indexR++] = R;
                                }
                                else
                                {
                                    int current = indexR - 1;
                                    while (current > 0 && filterR[current] > R)
                                    {
                                        filterR[current + 1] = filterR[current];
                                        current--;
                                    }
                                    filterR[current + 1] = R;
                                    indexR++;
                                }

                            }
                            //G
                            if (indexG == 0) { filterG[indexG] = G; indexG++; }
                            else
                            {
                                if (G >= filterG[indexG - 1])
                                {
                                    filterG[indexG++] = G;
                                }
                                else
                                {
                                    int current = indexG - 1;
                                    while (current > 0 && filterG[current] > G)
                                    {
                                        filterG[current + 1] = filterG[current];
                                        current--;
                                    }
                                    filterG[current + 1] = G;
                                    indexG++;
                                }

                            }

                            //B
                            if (indexB == 0) { filterB[indexB] = B; indexB++; }
                            else
                            {
                                if (B >= filterB[indexB - 1])
                                {
                                    filterB[indexB++] = B;
                                }
                                else
                                {
                                    int current = indexB - 1;
                                    while (current > 0 && filterB[current] > B)
                                    {
                                        filterB[current + 1] = filterB[current];
                                        current--;
                                    }
                                    filterB[current + 1] = B;
                                    indexB++;
                                }

                            }
                        }
                    }
                    resultPicR[i, j] = filterR[4];
                    resultPicG[i, j] = filterG[4];
                    resultPicB[i, j] = filterB[4];
                }
            }
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    int R = resultPicR[i, j];
                    int G = resultPicG[i, j];
                    int B = resultPicB[i, j];
                    Color color = Color.FromArgb(R, G, B);
                    pic.SetPixel(j, i, color);
                }
            }
            return pic;
        }

       
    }
}
