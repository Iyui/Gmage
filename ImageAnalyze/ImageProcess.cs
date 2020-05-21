using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageAnalyze
{
    public class ImageProcess
    {
        /// <summary>
        /// 反色
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
        /// 灰度化
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ImageToGrey(Image img)
        {
            Bitmap cBitmap = new Bitmap(img);
            for (int i = 0; i < cBitmap.Width; i++)
            {
                for (int j = 0; j < cBitmap.Height; j++)
                {
                    Color c = cBitmap.GetPixel(i, j);
                    int gray = Gray(c);
                    cBitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return cBitmap;
        }

        public static int Gray(Color c)
        {
            return (int)(c.R * .3 + c.G * .59 + c.B * .11);
        }

        public static int Gray2(Color c)
        {
            return (int)(c.R + c.G+ c.B)/3;
        }

        /// <summary>
        /// 灰度化
        /// </summary>
        /// <param name="img"></param>
        /// <returns></returns>
        public static Bitmap ImageToGrey2(Image img)
        {
            Bitmap cBitmap = new Bitmap(img);
            for (int i = 0; i < cBitmap.Width; i++)
            {
                for (int j = 0; j < cBitmap.Height; j++)
                {
                    Color c = cBitmap.GetPixel(i, j);
                    int gray = Gray2(c);
                    cBitmap.SetPixel(i, j, Color.FromArgb(gray, gray, gray));
                }
            }
            return cBitmap;
        }

        /// <summary>
        /// 二值化
        /// </summary>
        /// <param name="img"></param>
        /// <param name="threshold">阈值</param>
        /// <returns></returns>
        public static Bitmap Threshoding(Image img, int threshold = 128)
        {
            Bitmap tBitmap = new Bitmap(img);
            for (int i = 0; i < tBitmap.Width; i++)
            {
                for (int j = 0; j < tBitmap.Height; j++)
                {
                    Color c = tBitmap.GetPixel(i, j);
                    int rgb = (int)(c.R * .3 + c.G * .59 + c.B * .11);
                    if (rgb < threshold)
                        tBitmap.SetPixel(i, j, Color.FromArgb(0, 0, 0));
                    else
                        tBitmap.SetPixel(i, j, Color.FromArgb(255, 255, 255));
                }
            }
            return tBitmap;
        }
    }
}
