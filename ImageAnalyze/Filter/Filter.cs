using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace ImageAnalyze.Filter
{
    public class Filter
    {
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
