﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static ImageAnalyze.ImageProcess;

namespace ImageAnalyze.Process
{
    public partial class Threshold : Form
    {
        private MainForm f;
        public int Hold
        {
            set => tB_Threshold.Value = value;
            get => tB_Threshold.Value;
        }

        public Bitmap InitBitmap
        {
            set; get;
        }

        public Bitmap ResultBitmap
        {
            set; get;
        }

        public Threshold(MainForm f, Point p, int hold)
        {
            InitializeComponent();
            Hold = hold;
            this.f = f;
            this.PointToScreen(p);
            this.Location = p;
        }

        private void SetScrollStyle()
        {
            switch (Config.Model)
            {
                case FunctionType.Lighten:
                    tB_Threshold.Minimum = -255;
                    break;
                case FunctionType.Contrast:
                    tB_Threshold.Minimum = -100;
                    tB_Threshold.Maximum = 100;
                    break;
            }
        }

        private void tB_Threshold_Scroll(object sender, EventArgs e)
        {
            f.SetImageCallback(SetThreshold());
            SetThresholdText();
        }

        private Bitmap SetThreshold()
        {
            GC.Collect();
            switch (Config.Model)
            {
                default:
                    break;
                case FunctionType.Binarization:
                    ResultBitmap = BinarizationP(InitBitmap, Hold);
                    break;
                case FunctionType.Robert:
                    ResultBitmap = EdgeDetector_Robert(InitBitmap, Hold);
                    break;
                case FunctionType.Polar:
                    ResultBitmap = Polar(InitBitmap, Hold);
                    break;
                case FunctionType.Sharpen:
                    ResultBitmap = Sharpen(InitBitmap, Hold / 25.5f);
                    break;
                case FunctionType.Lighten:
                    ResultBitmap = Lighten(InitBitmap, Hold);
                    break;
                case FunctionType.Contrast:
                    ResultBitmap = Contrast(InitBitmap, Hold);
                    break;
            }
            return ResultBitmap;
        }

        private void SetThresholdText()
        {
            switch (Config.Model)
            {
                default:
                    label1.Text = $"阈值:\r\n{Hold.ToString()}";
                    break;
                case FunctionType.Binarization:
                    label1.Text = $"M:\r\n{Hold.ToString()}";
                    break;
                case FunctionType.Sharpen:
                    label1.Text = $"锐化程度:\r\n{(Hold / 25.5f).ToString("0.00%")}";
                    break;
            }
        }

        private void Threshold_Load(object sender, EventArgs e)
        {
            SetThresholdText();
            SetScrollStyle();
        }
    }
}