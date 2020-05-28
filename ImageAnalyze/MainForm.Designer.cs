namespace ImageAnalyze
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.sC_Compare = new System.Windows.Forms.SplitContainer();
            this.pB_Init = new System.Windows.Forms.PictureBox();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btn_BFT = new System.Windows.Forms.Button();
            this.btn_Contrast = new System.Windows.Forms.Button();
            this.btn_Lighten = new System.Windows.Forms.Button();
            this.btn_Sharpen = new System.Windows.Forms.Button();
            this.btn_Save = new System.Windows.Forms.Button();
            this.btn_MedianFilter = new System.Windows.Forms.Button();
            this.btn_FaceRecognition = new System.Windows.Forms.Button();
            this.btn_BackGround = new System.Windows.Forms.Button();
            this.btn_Polar = new System.Windows.Forms.Button();
            this.btn_GaussNoise = new System.Windows.Forms.Button();
            this.btn_Salt = new System.Windows.Forms.Button();
            this.btn_Smoothed = new System.Windows.Forms.Button();
            this.btn_Robert = new System.Windows.Forms.Button();
            this.btn_GaussBlur = new System.Windows.Forms.Button();
            this.btn_Frequency = new System.Windows.Forms.Button();
            this.btn_Histogram = new System.Windows.Forms.Button();
            this.btn_Complementary = new System.Windows.Forms.Button();
            this.btn_Binarization = new System.Windows.Forms.Button();
            this.btn_Gray = new System.Windows.Forms.Button();
            this.btn_SelectImage = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.sC_Compare)).BeginInit();
            this.sC_Compare.Panel1.SuspendLayout();
            this.sC_Compare.Panel2.SuspendLayout();
            this.sC_Compare.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Init)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // sC_Compare
            // 
            this.sC_Compare.Dock = System.Windows.Forms.DockStyle.Fill;
            this.sC_Compare.Location = new System.Drawing.Point(0, 0);
            this.sC_Compare.Name = "sC_Compare";
            // 
            // sC_Compare.Panel1
            // 
            this.sC_Compare.Panel1.Controls.Add(this.pB_Init);
            // 
            // sC_Compare.Panel2
            // 
            this.sC_Compare.Panel2.Controls.Add(this.splitContainer3);
            this.sC_Compare.Size = new System.Drawing.Size(937, 687);
            this.sC_Compare.SplitterDistance = 444;
            this.sC_Compare.TabIndex = 0;
            // 
            // pB_Init
            // 
            this.pB_Init.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pB_Init.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Init.Location = new System.Drawing.Point(0, 0);
            this.pB_Init.Name = "pB_Init";
            this.pB_Init.Size = new System.Drawing.Size(444, 687);
            this.pB_Init.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pB_Init.TabIndex = 1;
            this.pB_Init.TabStop = false;
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.pictureBox2);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_BFT);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Contrast);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Lighten);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Sharpen);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Save);
            this.splitContainer3.Panel2.Controls.Add(this.btn_MedianFilter);
            this.splitContainer3.Panel2.Controls.Add(this.btn_FaceRecognition);
            this.splitContainer3.Panel2.Controls.Add(this.btn_BackGround);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Polar);
            this.splitContainer3.Panel2.Controls.Add(this.btn_GaussNoise);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Salt);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Smoothed);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Robert);
            this.splitContainer3.Panel2.Controls.Add(this.btn_GaussBlur);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Frequency);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Histogram);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Complementary);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Binarization);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Gray);
            this.splitContainer3.Panel2.Controls.Add(this.btn_SelectImage);
            this.splitContainer3.Size = new System.Drawing.Size(489, 687);
            this.splitContainer3.SplitterDistance = 394;
            this.splitContainer3.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(394, 687);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // btn_BFT
            // 
            this.btn_BFT.Location = new System.Drawing.Point(6, 566);
            this.btn_BFT.Name = "btn_BFT";
            this.btn_BFT.Size = new System.Drawing.Size(82, 23);
            this.btn_BFT.TabIndex = 25;
            this.btn_BFT.Text = "傅里叶逆变换";
            this.btn_BFT.UseVisualStyleBackColor = true;
            this.btn_BFT.Visible = false;
            this.btn_BFT.Click += new System.EventHandler(this.btn_BFT_Click);
            // 
            // btn_Contrast
            // 
            this.btn_Contrast.Location = new System.Drawing.Point(6, 231);
            this.btn_Contrast.Name = "btn_Contrast";
            this.btn_Contrast.Size = new System.Drawing.Size(82, 23);
            this.btn_Contrast.TabIndex = 24;
            this.btn_Contrast.Tag = "";
            this.btn_Contrast.Text = "对比度";
            this.btn_Contrast.UseVisualStyleBackColor = true;
            this.btn_Contrast.Click += new System.EventHandler(this.btn_Contrast_Click);
            // 
            // btn_Lighten
            // 
            this.btn_Lighten.Location = new System.Drawing.Point(6, 202);
            this.btn_Lighten.Name = "btn_Lighten";
            this.btn_Lighten.Size = new System.Drawing.Size(82, 23);
            this.btn_Lighten.TabIndex = 23;
            this.btn_Lighten.Tag = "";
            this.btn_Lighten.Text = "亮度";
            this.btn_Lighten.UseVisualStyleBackColor = true;
            this.btn_Lighten.Click += new System.EventHandler(this.btn_Lighten_Click);
            // 
            // btn_Sharpen
            // 
            this.btn_Sharpen.Location = new System.Drawing.Point(6, 173);
            this.btn_Sharpen.Name = "btn_Sharpen";
            this.btn_Sharpen.Size = new System.Drawing.Size(82, 23);
            this.btn_Sharpen.TabIndex = 22;
            this.btn_Sharpen.Tag = "";
            this.btn_Sharpen.Text = "锐化";
            this.btn_Sharpen.UseVisualStyleBackColor = true;
            this.btn_Sharpen.Click += new System.EventHandler(this.btn_Sharpen_Click);
            // 
            // btn_Save
            // 
            this.btn_Save.Location = new System.Drawing.Point(6, 41);
            this.btn_Save.Name = "btn_Save";
            this.btn_Save.Size = new System.Drawing.Size(82, 23);
            this.btn_Save.TabIndex = 21;
            this.btn_Save.Text = "另存为";
            this.btn_Save.UseVisualStyleBackColor = true;
            this.btn_Save.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // btn_MedianFilter
            // 
            this.btn_MedianFilter.Location = new System.Drawing.Point(6, 433);
            this.btn_MedianFilter.Name = "btn_MedianFilter";
            this.btn_MedianFilter.Size = new System.Drawing.Size(82, 23);
            this.btn_MedianFilter.TabIndex = 20;
            this.btn_MedianFilter.Tag = "";
            this.btn_MedianFilter.Text = "中值滤波";
            this.btn_MedianFilter.UseVisualStyleBackColor = true;
            this.btn_MedianFilter.Click += new System.EventHandler(this.btn_MedianFilter_Click);
            // 
            // btn_FaceRecognition
            // 
            this.btn_FaceRecognition.Location = new System.Drawing.Point(6, 608);
            this.btn_FaceRecognition.Name = "btn_FaceRecognition";
            this.btn_FaceRecognition.Size = new System.Drawing.Size(82, 23);
            this.btn_FaceRecognition.TabIndex = 19;
            this.btn_FaceRecognition.Tag = "";
            this.btn_FaceRecognition.Text = "面部识别";
            this.btn_FaceRecognition.UseVisualStyleBackColor = true;
            this.btn_FaceRecognition.Click += new System.EventHandler(this.btn_FaceRecognition_Click);
            // 
            // btn_BackGround
            // 
            this.btn_BackGround.Location = new System.Drawing.Point(6, 652);
            this.btn_BackGround.Name = "btn_BackGround";
            this.btn_BackGround.Size = new System.Drawing.Size(82, 23);
            this.btn_BackGround.TabIndex = 18;
            this.btn_BackGround.Tag = "";
            this.btn_BackGround.Text = "桌面捕捉";
            this.btn_BackGround.UseVisualStyleBackColor = true;
            this.btn_BackGround.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_Polar
            // 
            this.btn_Polar.Location = new System.Drawing.Point(6, 508);
            this.btn_Polar.Name = "btn_Polar";
            this.btn_Polar.Size = new System.Drawing.Size(82, 23);
            this.btn_Polar.TabIndex = 17;
            this.btn_Polar.Tag = "";
            this.btn_Polar.Text = "极坐标变换";
            this.btn_Polar.UseVisualStyleBackColor = true;
            this.btn_Polar.Click += new System.EventHandler(this.btn_Polar_Click);
            // 
            // btn_GaussNoise
            // 
            this.btn_GaussNoise.Location = new System.Drawing.Point(6, 404);
            this.btn_GaussNoise.Name = "btn_GaussNoise";
            this.btn_GaussNoise.Size = new System.Drawing.Size(82, 23);
            this.btn_GaussNoise.TabIndex = 16;
            this.btn_GaussNoise.Tag = "";
            this.btn_GaussNoise.Text = "高斯噪声";
            this.btn_GaussNoise.UseVisualStyleBackColor = true;
            this.btn_GaussNoise.Click += new System.EventHandler(this.btn_GaussNoise_Click);
            // 
            // btn_Salt
            // 
            this.btn_Salt.Location = new System.Drawing.Point(6, 375);
            this.btn_Salt.Name = "btn_Salt";
            this.btn_Salt.Size = new System.Drawing.Size(82, 23);
            this.btn_Salt.TabIndex = 15;
            this.btn_Salt.Tag = "";
            this.btn_Salt.Text = "椒盐噪声";
            this.btn_Salt.UseVisualStyleBackColor = true;
            this.btn_Salt.Click += new System.EventHandler(this.btn_Salt_Click);
            // 
            // btn_Smoothed
            // 
            this.btn_Smoothed.Location = new System.Drawing.Point(6, 346);
            this.btn_Smoothed.Name = "btn_Smoothed";
            this.btn_Smoothed.Size = new System.Drawing.Size(82, 23);
            this.btn_Smoothed.TabIndex = 13;
            this.btn_Smoothed.Tag = "smoothed算子";
            this.btn_Smoothed.Text = "边缘检测S";
            this.btn_Smoothed.UseVisualStyleBackColor = true;
            this.btn_Smoothed.Click += new System.EventHandler(this.btn_Smoothed_Click);
            // 
            // btn_Robert
            // 
            this.btn_Robert.Location = new System.Drawing.Point(6, 317);
            this.btn_Robert.Name = "btn_Robert";
            this.btn_Robert.Size = new System.Drawing.Size(82, 23);
            this.btn_Robert.TabIndex = 12;
            this.btn_Robert.Tag = "robert算子";
            this.btn_Robert.Text = "边缘检测R";
            this.btn_Robert.UseVisualStyleBackColor = true;
            this.btn_Robert.Click += new System.EventHandler(this.btn_Robert_Click);
            // 
            // btn_GaussBlur
            // 
            this.btn_GaussBlur.Location = new System.Drawing.Point(6, 462);
            this.btn_GaussBlur.Name = "btn_GaussBlur";
            this.btn_GaussBlur.Size = new System.Drawing.Size(82, 23);
            this.btn_GaussBlur.TabIndex = 11;
            this.btn_GaussBlur.Text = "高斯平滑";
            this.btn_GaussBlur.UseVisualStyleBackColor = true;
            this.btn_GaussBlur.Click += new System.EventHandler(this.btn_Gaussian_Click);
            // 
            // btn_Frequency
            // 
            this.btn_Frequency.Location = new System.Drawing.Point(6, 537);
            this.btn_Frequency.Name = "btn_Frequency";
            this.btn_Frequency.Size = new System.Drawing.Size(82, 23);
            this.btn_Frequency.TabIndex = 10;
            this.btn_Frequency.Text = "傅里叶变换";
            this.btn_Frequency.UseVisualStyleBackColor = true;
            this.btn_Frequency.Click += new System.EventHandler(this.btn_Frequency_Click);
            // 
            // btn_Histogram
            // 
            this.btn_Histogram.Location = new System.Drawing.Point(6, 276);
            this.btn_Histogram.Name = "btn_Histogram";
            this.btn_Histogram.Size = new System.Drawing.Size(82, 23);
            this.btn_Histogram.TabIndex = 7;
            this.btn_Histogram.Text = "直方图";
            this.btn_Histogram.UseVisualStyleBackColor = true;
            this.btn_Histogram.Click += new System.EventHandler(this.btn_Histogram_Click);
            // 
            // btn_Complementary
            // 
            this.btn_Complementary.Location = new System.Drawing.Point(6, 144);
            this.btn_Complementary.Name = "btn_Complementary";
            this.btn_Complementary.Size = new System.Drawing.Size(82, 23);
            this.btn_Complementary.TabIndex = 6;
            this.btn_Complementary.Text = "反色";
            this.btn_Complementary.UseVisualStyleBackColor = true;
            this.btn_Complementary.Click += new System.EventHandler(this.btn_Complementary_Click);
            // 
            // btn_Binarization
            // 
            this.btn_Binarization.Location = new System.Drawing.Point(6, 115);
            this.btn_Binarization.Name = "btn_Binarization";
            this.btn_Binarization.Size = new System.Drawing.Size(82, 23);
            this.btn_Binarization.TabIndex = 5;
            this.btn_Binarization.Text = "二值化";
            this.btn_Binarization.UseVisualStyleBackColor = true;
            this.btn_Binarization.Click += new System.EventHandler(this.btn_Threshod_Click);
            // 
            // btn_Gray
            // 
            this.btn_Gray.Location = new System.Drawing.Point(6, 87);
            this.btn_Gray.Name = "btn_Gray";
            this.btn_Gray.Size = new System.Drawing.Size(82, 23);
            this.btn_Gray.TabIndex = 4;
            this.btn_Gray.Text = "灰度化";
            this.btn_Gray.UseVisualStyleBackColor = true;
            this.btn_Gray.Click += new System.EventHandler(this.btn_Gray_Click);
            // 
            // btn_SelectImage
            // 
            this.btn_SelectImage.Location = new System.Drawing.Point(6, 12);
            this.btn_SelectImage.Name = "btn_SelectImage";
            this.btn_SelectImage.Size = new System.Drawing.Size(82, 23);
            this.btn_SelectImage.TabIndex = 0;
            this.btn_SelectImage.Text = "选择图片";
            this.btn_SelectImage.UseVisualStyleBackColor = true;
            this.btn_SelectImage.Click += new System.EventHandler(this.btn_SelectImage_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(937, 687);
            this.Controls.Add(this.sC_Compare);
            this.Name = "MainForm";
            this.Text = "图像分析及处理";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.sC_Compare.Panel1.ResumeLayout(false);
            this.sC_Compare.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sC_Compare)).EndInit();
            this.sC_Compare.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Init)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer sC_Compare;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.Button btn_SelectImage;
        private System.Windows.Forms.Button btn_Gray;
        private System.Windows.Forms.Button btn_Binarization;
        private System.Windows.Forms.Button btn_Complementary;
        private System.Windows.Forms.Button btn_Histogram;
        private System.Windows.Forms.Button btn_Frequency;
        private System.Windows.Forms.PictureBox pB_Init;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btn_GaussBlur;
        private System.Windows.Forms.Button btn_Smoothed;
        private System.Windows.Forms.Button btn_Robert;
        private System.Windows.Forms.Button btn_GaussNoise;
        private System.Windows.Forms.Button btn_Salt;
        private System.Windows.Forms.Button btn_Polar;
        private System.Windows.Forms.Button btn_BackGround;
        private System.Windows.Forms.Button btn_FaceRecognition;
        private System.Windows.Forms.Button btn_MedianFilter;
        private System.Windows.Forms.Button btn_Save;
        private System.Windows.Forms.Button btn_Sharpen;
        private System.Windows.Forms.Button btn_Contrast;
        private System.Windows.Forms.Button btn_Lighten;
        private System.Windows.Forms.Button btn_BFT;
    }
}

