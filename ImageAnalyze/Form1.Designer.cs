namespace ImageAnalyze
{
    partial class Form1
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.pB_Init = new System.Windows.Forms.PictureBox();
            this.ct_InitChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.splitContainer3 = new System.Windows.Forms.SplitContainer();
            this.splitContainer4 = new System.Windows.Forms.SplitContainer();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.btn_Histogram = new System.Windows.Forms.Button();
            this.btn_Complementary = new System.Windows.Forms.Button();
            this.btn_Threshod = new System.Windows.Forms.Button();
            this.btn_Gray = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_SelectImage = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.btn_Frequency = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pB_Init)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.ct_InitChart)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).BeginInit();
            this.splitContainer3.Panel1.SuspendLayout();
            this.splitContainer3.Panel2.SuspendLayout();
            this.splitContainer3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).BeginInit();
            this.splitContainer4.Panel1.SuspendLayout();
            this.splitContainer4.Panel2.SuspendLayout();
            this.splitContainer4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer3);
            this.splitContainer1.Size = new System.Drawing.Size(930, 764);
            this.splitContainer1.SplitterDistance = 443;
            this.splitContainer1.TabIndex = 0;
            // 
            // splitContainer2
            // 
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            this.splitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.Controls.Add(this.pB_Init);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer2.Panel2.Controls.Add(this.ct_InitChart);
            this.splitContainer2.Size = new System.Drawing.Size(443, 764);
            this.splitContainer2.SplitterDistance = 404;
            this.splitContainer2.TabIndex = 0;
            // 
            // pB_Init
            // 
            this.pB_Init.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pB_Init.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Init.Location = new System.Drawing.Point(0, 0);
            this.pB_Init.Name = "pB_Init";
            this.pB_Init.Size = new System.Drawing.Size(443, 404);
            this.pB_Init.TabIndex = 0;
            this.pB_Init.TabStop = false;
            // 
            // ct_InitChart
            // 
            chartArea1.Name = "ChartArea1";
            this.ct_InitChart.ChartAreas.Add(chartArea1);
            this.ct_InitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend1.Name = "Legend1";
            this.ct_InitChart.Legends.Add(legend1);
            this.ct_InitChart.Location = new System.Drawing.Point(0, 0);
            this.ct_InitChart.Name = "ct_InitChart";
            this.ct_InitChart.Size = new System.Drawing.Size(443, 356);
            this.ct_InitChart.TabIndex = 0;
            this.ct_InitChart.Text = "chart1";
            // 
            // splitContainer3
            // 
            this.splitContainer3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer3.Location = new System.Drawing.Point(0, 0);
            this.splitContainer3.Name = "splitContainer3";
            // 
            // splitContainer3.Panel1
            // 
            this.splitContainer3.Panel1.Controls.Add(this.splitContainer4);
            // 
            // splitContainer3.Panel2
            // 
            this.splitContainer3.Panel2.Controls.Add(this.btn_Frequency);
            this.splitContainer3.Panel2.Controls.Add(this.button4);
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Histogram);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Complementary);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Threshod);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Gray);
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Panel2.Controls.Add(this.btn_SelectImage);
            this.splitContainer3.Size = new System.Drawing.Size(483, 764);
            this.splitContainer3.SplitterDistance = 414;
            this.splitContainer3.TabIndex = 0;
            // 
            // splitContainer4
            // 
            this.splitContainer4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer4.Location = new System.Drawing.Point(0, 0);
            this.splitContainer4.Name = "splitContainer4";
            this.splitContainer4.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer4.Panel1
            // 
            this.splitContainer4.Panel1.Controls.Add(this.pictureBox2);
            // 
            // splitContainer4.Panel2
            // 
            this.splitContainer4.Panel2.Controls.Add(this.pictureBox1);
            this.splitContainer4.Panel2.Controls.Add(this.chart2);
            this.splitContainer4.Size = new System.Drawing.Size(414, 764);
            this.splitContainer4.SplitterDistance = 406;
            this.splitContainer4.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(414, 406);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // chart2
            // 
            chartArea2.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea2);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend2.Name = "Legend1";
            this.chart2.Legends.Add(legend2);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(414, 354);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart2";
            // 
            // btn_Histogram
            // 
            this.btn_Histogram.Location = new System.Drawing.Point(2, 157);
            this.btn_Histogram.Name = "btn_Histogram";
            this.btn_Histogram.Size = new System.Drawing.Size(67, 23);
            this.btn_Histogram.TabIndex = 7;
            this.btn_Histogram.Text = "直方图";
            this.btn_Histogram.UseVisualStyleBackColor = true;
            this.btn_Histogram.Click += new System.EventHandler(this.btn_Histogram_Click);
            // 
            // btn_Complementary
            // 
            this.btn_Complementary.Location = new System.Drawing.Point(2, 128);
            this.btn_Complementary.Name = "btn_Complementary";
            this.btn_Complementary.Size = new System.Drawing.Size(67, 23);
            this.btn_Complementary.TabIndex = 6;
            this.btn_Complementary.Text = "反色";
            this.btn_Complementary.UseVisualStyleBackColor = true;
            this.btn_Complementary.Click += new System.EventHandler(this.btn_Complementary_Click);
            // 
            // btn_Threshod
            // 
            this.btn_Threshod.Location = new System.Drawing.Point(2, 99);
            this.btn_Threshod.Name = "btn_Threshod";
            this.btn_Threshod.Size = new System.Drawing.Size(67, 23);
            this.btn_Threshod.TabIndex = 5;
            this.btn_Threshod.Text = "二值化";
            this.btn_Threshod.UseVisualStyleBackColor = true;
            this.btn_Threshod.Click += new System.EventHandler(this.btn_Threshod_Click);
            // 
            // btn_Gray
            // 
            this.btn_Gray.Location = new System.Drawing.Point(2, 41);
            this.btn_Gray.Name = "btn_Gray";
            this.btn_Gray.Size = new System.Drawing.Size(67, 23);
            this.btn_Gray.TabIndex = 4;
            this.btn_Gray.Text = "灰度化";
            this.btn_Gray.UseVisualStyleBackColor = true;
            this.btn_Gray.Click += new System.EventHandler(this.btn_Gray_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(3, 273);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(67, 23);
            this.button3.TabIndex = 3;
            this.button3.Text = "高通滤波";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(2, 244);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(67, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "低通滤波";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // btn_SelectImage
            // 
            this.btn_SelectImage.Location = new System.Drawing.Point(3, 12);
            this.btn_SelectImage.Name = "btn_SelectImage";
            this.btn_SelectImage.Size = new System.Drawing.Size(67, 23);
            this.btn_SelectImage.TabIndex = 0;
            this.btn_SelectImage.Text = "选择图片";
            this.btn_SelectImage.UseVisualStyleBackColor = true;
            this.btn_SelectImage.Click += new System.EventHandler(this.btn_SelectImage_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(2, 70);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(67, 23);
            this.button1.TabIndex = 8;
            this.button1.Text = "灰度2";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(2, 186);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(67, 23);
            this.button4.TabIndex = 9;
            this.button4.Text = "时域变换";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // btn_Frequency
            // 
            this.btn_Frequency.Location = new System.Drawing.Point(2, 215);
            this.btn_Frequency.Name = "btn_Frequency";
            this.btn_Frequency.Size = new System.Drawing.Size(67, 23);
            this.btn_Frequency.TabIndex = 10;
            this.btn_Frequency.Text = "频域变换";
            this.btn_Frequency.UseVisualStyleBackColor = true;
            this.btn_Frequency.Click += new System.EventHandler(this.btn_Frequency_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(414, 354);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox3.Location = new System.Drawing.Point(0, 0);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(443, 356);
            this.pictureBox3.TabIndex = 2;
            this.pictureBox3.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 764);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "图像分析及处理";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pB_Init)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.ct_InitChart)).EndInit();
            this.splitContainer3.Panel1.ResumeLayout(false);
            this.splitContainer3.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer3)).EndInit();
            this.splitContainer3.ResumeLayout(false);
            this.splitContainer4.Panel1.ResumeLayout(false);
            this.splitContainer4.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer4)).EndInit();
            this.splitContainer4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
        private System.Windows.Forms.PictureBox pB_Init;
        private System.Windows.Forms.DataVisualization.Charting.Chart ct_InitChart;
        private System.Windows.Forms.SplitContainer splitContainer3;
        private System.Windows.Forms.SplitContainer splitContainer4;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btn_SelectImage;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button btn_Gray;
        private System.Windows.Forms.Button btn_Threshod;
        private System.Windows.Forms.Button btn_Complementary;
        private System.Windows.Forms.Button btn_Histogram;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btn_Frequency;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

