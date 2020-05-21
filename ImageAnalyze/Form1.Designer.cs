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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
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
            this.button5 = new System.Windows.Forms.Button();
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
            this.splitContainer1.Size = new System.Drawing.Size(1066, 624);
            this.splitContainer1.SplitterDistance = 508;
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
            this.splitContainer2.Panel2.Controls.Add(this.ct_InitChart);
            this.splitContainer2.Size = new System.Drawing.Size(508, 624);
            this.splitContainer2.SplitterDistance = 551;
            this.splitContainer2.TabIndex = 0;
            // 
            // pB_Init
            // 
            this.pB_Init.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pB_Init.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pB_Init.Location = new System.Drawing.Point(0, 0);
            this.pB_Init.Name = "pB_Init";
            this.pB_Init.Size = new System.Drawing.Size(508, 551);
            this.pB_Init.TabIndex = 0;
            this.pB_Init.TabStop = false;
            // 
            // ct_InitChart
            // 
            chartArea11.Name = "ChartArea1";
            this.ct_InitChart.ChartAreas.Add(chartArea11);
            this.ct_InitChart.Dock = System.Windows.Forms.DockStyle.Fill;
            legend11.Name = "Legend1";
            this.ct_InitChart.Legends.Add(legend11);
            this.ct_InitChart.Location = new System.Drawing.Point(0, 0);
            this.ct_InitChart.Name = "ct_InitChart";
            this.ct_InitChart.Size = new System.Drawing.Size(508, 69);
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
            this.splitContainer3.Panel2.Controls.Add(this.button5);
            this.splitContainer3.Panel2.Controls.Add(this.button4);
            this.splitContainer3.Panel2.Controls.Add(this.button1);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Histogram);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Complementary);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Threshod);
            this.splitContainer3.Panel2.Controls.Add(this.btn_Gray);
            this.splitContainer3.Panel2.Controls.Add(this.button3);
            this.splitContainer3.Panel2.Controls.Add(this.button2);
            this.splitContainer3.Panel2.Controls.Add(this.btn_SelectImage);
            this.splitContainer3.Size = new System.Drawing.Size(554, 624);
            this.splitContainer3.SplitterDistance = 475;
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
            this.splitContainer4.Panel2.Controls.Add(this.chart2);
            this.splitContainer4.Size = new System.Drawing.Size(475, 624);
            this.splitContainer4.SplitterDistance = 546;
            this.splitContainer4.TabIndex = 0;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.pictureBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(475, 546);
            this.pictureBox2.TabIndex = 1;
            this.pictureBox2.TabStop = false;
            // 
            // chart2
            // 
            chartArea12.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea12);
            this.chart2.Dock = System.Windows.Forms.DockStyle.Fill;
            legend12.Name = "Legend1";
            this.chart2.Legends.Add(legend12);
            this.chart2.Location = new System.Drawing.Point(0, 0);
            this.chart2.Name = "chart2";
            this.chart2.Size = new System.Drawing.Size(475, 74);
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
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(2, 215);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(67, 23);
            this.button5.TabIndex = 10;
            this.button5.Text = "频域变换";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1066, 624);
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
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
    }
}

