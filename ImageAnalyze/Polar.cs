using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageAnalyze
{
    public partial class PolarCoordinate : Form
    {

        private Bitmap bmpHist;
        public PolarCoordinate(Bitmap bmp)
        {
            InitializeComponent();
            bmpHist = bmp;
        }


        public class PolarValue
        {
            float ang = 0;
            float val = 0;

            // 角度
            public float Angle
            {
                get { return ang; }
                set { ang = value; }
            }

            // 数值
            public float Value
            {
                get { return val; }
                set { val = value; }
            }

            public PolarValue(float angle, float value)
            {
                this.ang = angle;
                this.val = value;
            }
        }

        // 数据列表
        public List<PolarValue> values = new List<PolarValue>();
        float min = 0;
        float max = 10000;

        // 合并后的映射方法
        private PointF getMappedPoint(float angle, float value)
        {
            // 计算映射在坐标图中的半径
            float r = radius * (value - min) / (max - min);
            // 计算GDI+坐标
            PointF pt = new PointF();
            pt.X = (float)(r * Math.Cos(angle * Math.PI / 180) + center.X);
            pt.Y = (float)(r * Math.Sin(angle * Math.PI / 180) + center.Y);
            return pt;
        }

        private void Polar(int x, int y, out float r, out float theta)
        {
            if (x < (int)center.X)
                x = x - (int)center.X;
            if (y < (int)center.Y)
                y = y - (int)center.Y;
            r = (float)Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));

            if(x==0)
                theta = (float)Math.Atan(y);
            else 
                theta = (float)Math.Atan(y / x);
        }

        // 画圆
        float radius;
        PointF center;
        

        private void PolarCoordinate_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Brush curPen = Brushes.Black;
            for (int i = 0; i < polarList.Count; i++)
            {
                g.FillEllipse(curPen, values[i].Angle, values[i].Value, 2, 2);
            }
        }
        List<float[]>  polarList = new List<float[]>();
        private void PolarCoordinate_Load(object sender, EventArgs e)
        {
            center = new PointF(
               this.Width / 2,
                this.Height / 2
               );
            radius = Math.Min(Width, Height) / 2;
            float[] polar = new float[5];
            polarList = new List<float[]>();
            for (int i = 0; i < bmpHist.Width; i++)
            {
                for (int j = 0; j < bmpHist.Height; j++)
                {
                    Polar(i, j, out float r, out float theta);
                    
                    Color c = bmpHist.GetPixel(i, j);

                    values.Add(new PolarValue(theta, r));

                    var p = getMappedPoint(theta, r);

                 //0:r,1:角度，2、3、4：R G B
                    polar[0] = p.X;// + midWidth;
                    polar[1] = p.Y;// + midHeight;
                    polar[2] = c.R;
                    polar[3] = c.G;
                    polar[4] = c.B;
                    polarList.Add(polar);
                }
            }
           // drawPoints();
   
           Invalidate();
        }

        private void drawPoints()
        {
           // Graphics g = new Graphics();
           // g.drawpi
           // Bitmap b = new Bitmap(2500, 2500);

            //for (int i = 0; i < polarList.Count; i++)
            //{
            //    Color c = Color.FromArgb((int)polarList[i][2], (int)polarList[i][3], (int)polarList[i][4]);
            //    b.SetPixel((int)polarList[i][0], (int)polarList[i][1], c);
            //    //b.SetPixel((int)values[i].Value, (int)values[i].Angle, c);
            //}
            //pB_Polar.Image = b;
        }
    }
}
