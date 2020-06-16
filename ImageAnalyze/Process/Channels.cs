using System.Drawing;
using System.Drawing.Imaging;

namespace Gmage
{
    /// <summary>
    /// 通道
    /// </summary>
    public static class Channels
    {

        public static Bitmap GreenToRed(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.R, pixel.R, pixel.G);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        public static Bitmap BlueToRed(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.R, pixel.G, pixel.R);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        public static Bitmap RedToGreen(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.G, pixel.G, pixel.B);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        public static Bitmap BlueToGreen(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.R, pixel.G, pixel.G);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        public static Bitmap RedToBlue(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.B, pixel.R, pixel.B);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        public static Bitmap GreenToBlue(Bitmap bitmap)
        {
            Color pixel;
            Bitmap bitmapResult = (Bitmap)bitmap.Clone();

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    pixel = bitmap.GetPixel(x, y);
                    pixel = Color.FromArgb(pixel.R, pixel.B, pixel.B);
                    bitmapResult.SetPixel(x, y, pixel);
                }
            }
            return bitmapResult;
        }

        /// <summary>
        /// 3通道调整
        /// </summary>
        /// <param name="initbitmap"></param>
        /// <returns></returns>
        public static Bitmap Channel(Bitmap initbitmap, float rp,float gp,float bp)
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
                        pix[0] = (byte)(pix[0] * bp > 255 ? 255 : pix[0] * bp);
                        pix[1] = (byte)(pix[1] * gp > 255 ? 255 : pix[1] * gp);
                        pix[2] = (byte)(pix[2] * rp > 255 ? 255 : pix[2] * rp);
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
