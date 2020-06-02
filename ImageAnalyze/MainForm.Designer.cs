namespace Gmage
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
            this.materialContextMenuStrip1 = new MaterialSkin.Controls.MaterialContextMenuStrip();
            this.tsm_CloseTabPage = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.选择图片ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.另存为ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Clear = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.首选项ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Image = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Change = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Lighten = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Contrast = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Gray = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Binarization = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Complementary = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Frequency = new System.Windows.Forms.ToolStripMenuItem();
            this.直方图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图像旋转ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Clockwise180 = new System.Windows.Forms.ToolStripMenuItem();
            this.Clockwise90 = new System.Windows.Forms.ToolStripMenuItem();
            this.Clockwise270 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.RotateNoneFlipX = new System.Windows.Forms.ToolStripMenuItem();
            this.RotateNoneFlipY = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Filter = new System.Windows.Forms.ToolStripMenuItem();
            this.模糊ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Tsmi_GaussBlur = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmi_MedianFilter = new System.Windows.Forms.ToolStripMenuItem();
            this.噪声ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_GaussNoise = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Salt = new System.Windows.Forms.ToolStripMenuItem();
            this.扭曲ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Polar = new System.Windows.Forms.ToolStripMenuItem();
            this.边缘检测ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Robert = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Smoothed = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Sharpen = new System.Windows.Forms.ToolStripMenuItem();
            this.字符化ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.级联分类器ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Classifier = new System.Windows.Forms.ToolStripMenuItem();
            this.识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Batch = new System.Windows.Forms.ToolStripMenuItem();
            this.帮助ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.辅助工具ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_About = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmi_Index = new System.Windows.Forms.ToolStripMenuItem();
            this.mtS_Selected = new MaterialSkin.Controls.MaterialTabSelector();
            this.mTC_ImageTab = new MaterialSkin.Controls.MaterialTabControl();
            this.panel2 = new System.Windows.Forms.Panel();
            this.mPB_Bar = new MaterialSkin.Controls.MaterialProgressBar();
            this.panel1 = new System.Windows.Forms.Panel();
            this.materialContextMenuStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialContextMenuStrip1
            // 
            this.materialContextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.materialContextMenuStrip1.Depth = 0;
            this.materialContextMenuStrip1.Enabled = false;
            this.materialContextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.materialContextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsm_CloseTabPage});
            this.materialContextMenuStrip1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialContextMenuStrip1.Name = "materialContextMenuStrip1";
            this.materialContextMenuStrip1.Size = new System.Drawing.Size(161, 26);
            // 
            // tsm_CloseTabPage
            // 
            this.tsm_CloseTabPage.Enabled = false;
            this.tsm_CloseTabPage.Name = "tsm_CloseTabPage";
            this.tsm_CloseTabPage.Size = new System.Drawing.Size(160, 22);
            this.tsm_CloseTabPage.Text = "关闭当前选项卡";
            this.tsm_CloseTabPage.Click += new System.EventHandler(this.tsm_CloseTabPage_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.ControlText;
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.编辑ToolStripMenuItem,
            this.tsmi_Image,
            this.tsmi_Filter,
            this.级联分类器ToolStripMenuItem,
            this.tsmi_Batch,
            this.帮助ToolStripMenuItem,
            this.tsmi_Index});
            this.menuStrip1.Location = new System.Drawing.Point(1, -1);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(540, 25);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.选择图片ToolStripMenuItem,
            this.toolStripSeparator1,
            this.另存为ToolStripMenuItem});
            this.文件ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 选择图片ToolStripMenuItem
            // 
            this.选择图片ToolStripMenuItem.Name = "选择图片ToolStripMenuItem";
            this.选择图片ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.选择图片ToolStripMenuItem.Text = "打开...";
            this.选择图片ToolStripMenuItem.Click += new System.EventHandler(this.btn_SelectImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(118, 6);
            // 
            // 另存为ToolStripMenuItem
            // 
            this.另存为ToolStripMenuItem.Name = "另存为ToolStripMenuItem";
            this.另存为ToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.另存为ToolStripMenuItem.Text = "另存为...";
            this.另存为ToolStripMenuItem.Click += new System.EventHandler(this.btn_Save_Click);
            // 
            // 编辑ToolStripMenuItem
            // 
            this.编辑ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Clear,
            this.toolStripSeparator2,
            this.首选项ToolStripMenuItem});
            this.编辑ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.编辑ToolStripMenuItem.Name = "编辑ToolStripMenuItem";
            this.编辑ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.编辑ToolStripMenuItem.Text = "编辑";
            // 
            // tsmi_Clear
            // 
            this.tsmi_Clear.Name = "tsmi_Clear";
            this.tsmi_Clear.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Clear.Text = "清除所有效果";
            this.tsmi_Clear.Click += new System.EventHandler(this.tsmi_Clear_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(145, 6);
            // 
            // 首选项ToolStripMenuItem
            // 
            this.首选项ToolStripMenuItem.Name = "首选项ToolStripMenuItem";
            this.首选项ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.首选项ToolStripMenuItem.Text = "首选项";
            // 
            // tsmi_Image
            // 
            this.tsmi_Image.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Change,
            this.tsmi_Frequency,
            this.直方图ToolStripMenuItem,
            this.图像旋转ToolStripMenuItem});
            this.tsmi_Image.ForeColor = System.Drawing.Color.White;
            this.tsmi_Image.Name = "tsmi_Image";
            this.tsmi_Image.Size = new System.Drawing.Size(44, 21);
            this.tsmi_Image.Text = "图像";
            // 
            // tsmi_Change
            // 
            this.tsmi_Change.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Lighten,
            this.tsmi_Contrast,
            this.tsmi_Gray,
            this.tsmi_Binarization,
            this.tsmi_Complementary});
            this.tsmi_Change.Name = "tsmi_Change";
            this.tsmi_Change.Size = new System.Drawing.Size(124, 22);
            this.tsmi_Change.Text = "调整";
            // 
            // tsmi_Lighten
            // 
            this.tsmi_Lighten.Name = "tsmi_Lighten";
            this.tsmi_Lighten.Size = new System.Drawing.Size(112, 22);
            this.tsmi_Lighten.Tag = "Lighten";
            this.tsmi_Lighten.Text = "亮度";
            // 
            // tsmi_Contrast
            // 
            this.tsmi_Contrast.Name = "tsmi_Contrast";
            this.tsmi_Contrast.Size = new System.Drawing.Size(112, 22);
            this.tsmi_Contrast.Tag = "Contrast";
            this.tsmi_Contrast.Text = "对比度";
            // 
            // tsmi_Gray
            // 
            this.tsmi_Gray.Name = "tsmi_Gray";
            this.tsmi_Gray.Size = new System.Drawing.Size(112, 22);
            this.tsmi_Gray.Tag = "Gray";
            this.tsmi_Gray.Text = "灰度化";
            // 
            // tsmi_Binarization
            // 
            this.tsmi_Binarization.Name = "tsmi_Binarization";
            this.tsmi_Binarization.Size = new System.Drawing.Size(112, 22);
            this.tsmi_Binarization.Tag = "Binarization";
            this.tsmi_Binarization.Text = "二值化";
            // 
            // tsmi_Complementary
            // 
            this.tsmi_Complementary.Name = "tsmi_Complementary";
            this.tsmi_Complementary.Size = new System.Drawing.Size(112, 22);
            this.tsmi_Complementary.Tag = "Complementary";
            this.tsmi_Complementary.Text = "反相";
            // 
            // tsmi_Frequency
            // 
            this.tsmi_Frequency.Name = "tsmi_Frequency";
            this.tsmi_Frequency.Size = new System.Drawing.Size(124, 22);
            this.tsmi_Frequency.Tag = "Frequency";
            this.tsmi_Frequency.Text = "频谱图";
            // 
            // 直方图ToolStripMenuItem
            // 
            this.直方图ToolStripMenuItem.Name = "直方图ToolStripMenuItem";
            this.直方图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.直方图ToolStripMenuItem.Text = "直方图";
            this.直方图ToolStripMenuItem.Click += new System.EventHandler(this.btn_Histogram_Click);
            // 
            // 图像旋转ToolStripMenuItem
            // 
            this.图像旋转ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Clockwise180,
            this.Clockwise90,
            this.Clockwise270,
            this.toolStripSeparator3,
            this.RotateNoneFlipX,
            this.RotateNoneFlipY});
            this.图像旋转ToolStripMenuItem.Name = "图像旋转ToolStripMenuItem";
            this.图像旋转ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.图像旋转ToolStripMenuItem.Text = "图像旋转";
            // 
            // Clockwise180
            // 
            this.Clockwise180.Name = "Clockwise180";
            this.Clockwise180.Size = new System.Drawing.Size(146, 22);
            this.Clockwise180.Tag = "Clockwise180";
            this.Clockwise180.Text = "180度";
            // 
            // Clockwise90
            // 
            this.Clockwise90.Name = "Clockwise90";
            this.Clockwise90.Size = new System.Drawing.Size(146, 22);
            this.Clockwise90.Tag = "Clockwise90";
            this.Clockwise90.Text = "90度(顺时针)";
            // 
            // Clockwise270
            // 
            this.Clockwise270.Name = "Clockwise270";
            this.Clockwise270.Size = new System.Drawing.Size(146, 22);
            this.Clockwise270.Tag = "Clockwise270";
            this.Clockwise270.Text = "90度(逆时针)";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(143, 6);
            // 
            // RotateNoneFlipX
            // 
            this.RotateNoneFlipX.Name = "RotateNoneFlipX";
            this.RotateNoneFlipX.Size = new System.Drawing.Size(146, 22);
            this.RotateNoneFlipX.Tag = "RotateNoneFlipX";
            this.RotateNoneFlipX.Text = "垂直镜像";
            // 
            // RotateNoneFlipY
            // 
            this.RotateNoneFlipY.Name = "RotateNoneFlipY";
            this.RotateNoneFlipY.Size = new System.Drawing.Size(146, 22);
            this.RotateNoneFlipY.Tag = "RotateNoneFlipY";
            this.RotateNoneFlipY.Text = "水平镜像";
            // 
            // tsmi_Filter
            // 
            this.tsmi_Filter.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.模糊ToolStripMenuItem,
            this.噪声ToolStripMenuItem,
            this.扭曲ToolStripMenuItem,
            this.边缘检测ToolStripMenuItem,
            this.tsmi_Sharpen,
            this.字符化ToolStripMenuItem});
            this.tsmi_Filter.ForeColor = System.Drawing.Color.White;
            this.tsmi_Filter.Name = "tsmi_Filter";
            this.tsmi_Filter.Size = new System.Drawing.Size(44, 21);
            this.tsmi_Filter.Text = "滤镜";
            // 
            // 模糊ToolStripMenuItem
            // 
            this.模糊ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Tsmi_GaussBlur,
            this.toolStripSeparator4,
            this.tsmi_MedianFilter});
            this.模糊ToolStripMenuItem.Name = "模糊ToolStripMenuItem";
            this.模糊ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.模糊ToolStripMenuItem.Text = "模糊/滤波";
            // 
            // Tsmi_GaussBlur
            // 
            this.Tsmi_GaussBlur.Name = "Tsmi_GaussBlur";
            this.Tsmi_GaussBlur.Size = new System.Drawing.Size(124, 22);
            this.Tsmi_GaussBlur.Tag = "GaussBlur";
            this.Tsmi_GaussBlur.Text = "高斯模糊";
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(121, 6);
            // 
            // tsmi_MedianFilter
            // 
            this.tsmi_MedianFilter.Name = "tsmi_MedianFilter";
            this.tsmi_MedianFilter.ShortcutKeyDisplayString = "";
            this.tsmi_MedianFilter.Size = new System.Drawing.Size(124, 22);
            this.tsmi_MedianFilter.Tag = "MedianFilter";
            this.tsmi_MedianFilter.Text = "中值滤波";
            // 
            // 噪声ToolStripMenuItem
            // 
            this.噪声ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_GaussNoise,
            this.tsmi_Salt});
            this.噪声ToolStripMenuItem.Name = "噪声ToolStripMenuItem";
            this.噪声ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.噪声ToolStripMenuItem.Text = "噪声";
            // 
            // tsmi_GaussNoise
            // 
            this.tsmi_GaussNoise.Name = "tsmi_GaussNoise";
            this.tsmi_GaussNoise.Size = new System.Drawing.Size(180, 22);
            this.tsmi_GaussNoise.Tag = "GaussNoise";
            this.tsmi_GaussNoise.Text = "高斯噪声";
            // 
            // tsmi_Salt
            // 
            this.tsmi_Salt.Name = "tsmi_Salt";
            this.tsmi_Salt.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Salt.Text = "椒盐噪声";
            this.tsmi_Salt.Click += new System.EventHandler(this.btn_Salt_Click);
            // 
            // 扭曲ToolStripMenuItem
            // 
            this.扭曲ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Polar});
            this.扭曲ToolStripMenuItem.Name = "扭曲ToolStripMenuItem";
            this.扭曲ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.扭曲ToolStripMenuItem.Text = "扭曲";
            // 
            // tsmi_Polar
            // 
            this.tsmi_Polar.Name = "tsmi_Polar";
            this.tsmi_Polar.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Polar.Tag = "Polar";
            this.tsmi_Polar.Text = "极坐标";
            // 
            // 边缘检测ToolStripMenuItem
            // 
            this.边缘检测ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Robert,
            this.tsmi_Smoothed});
            this.边缘检测ToolStripMenuItem.Name = "边缘检测ToolStripMenuItem";
            this.边缘检测ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.边缘检测ToolStripMenuItem.Text = "边缘检测";
            // 
            // tsmi_Robert
            // 
            this.tsmi_Robert.Name = "tsmi_Robert";
            this.tsmi_Robert.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Robert.Tag = "Robert";
            this.tsmi_Robert.Text = "Robert";
            // 
            // tsmi_Smoothed
            // 
            this.tsmi_Smoothed.Name = "tsmi_Smoothed";
            this.tsmi_Smoothed.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Smoothed.Tag = "Smoothed";
            this.tsmi_Smoothed.Text = "Smoothed";
            // 
            // tsmi_Sharpen
            // 
            this.tsmi_Sharpen.Name = "tsmi_Sharpen";
            this.tsmi_Sharpen.Size = new System.Drawing.Size(180, 22);
            this.tsmi_Sharpen.Tag = "Sharpen";
            this.tsmi_Sharpen.Text = "锐化";
            // 
            // 字符化ToolStripMenuItem
            // 
            this.字符化ToolStripMenuItem.Name = "字符化ToolStripMenuItem";
            this.字符化ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.字符化ToolStripMenuItem.Text = "字符画";
            // 
            // 级联分类器ToolStripMenuItem
            // 
            this.级联分类器ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmi_Classifier,
            this.识别ToolStripMenuItem});
            this.级联分类器ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.级联分类器ToolStripMenuItem.Name = "级联分类器ToolStripMenuItem";
            this.级联分类器ToolStripMenuItem.Size = new System.Drawing.Size(80, 21);
            this.级联分类器ToolStripMenuItem.Text = "级联分类器";
            // 
            // tsmi_Classifier
            // 
            this.tsmi_Classifier.Name = "tsmi_Classifier";
            this.tsmi_Classifier.Size = new System.Drawing.Size(136, 22);
            this.tsmi_Classifier.Text = "分类器选择";
            // 
            // 识别ToolStripMenuItem
            // 
            this.识别ToolStripMenuItem.Name = "识别ToolStripMenuItem";
            this.识别ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.识别ToolStripMenuItem.Text = "识别";
            this.识别ToolStripMenuItem.Click += new System.EventHandler(this.btn_FaceRecognition_Click);
            // 
            // tsmi_Batch
            // 
            this.tsmi_Batch.ForeColor = System.Drawing.Color.White;
            this.tsmi_Batch.Name = "tsmi_Batch";
            this.tsmi_Batch.Size = new System.Drawing.Size(56, 21);
            this.tsmi_Batch.Text = "批处理";
            this.tsmi_Batch.Click += new System.EventHandler(this.button2_Click);
            // 
            // 帮助ToolStripMenuItem
            // 
            this.帮助ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.辅助工具ToolStripMenuItem,
            this.tsmi_About});
            this.帮助ToolStripMenuItem.ForeColor = System.Drawing.Color.White;
            this.帮助ToolStripMenuItem.Name = "帮助ToolStripMenuItem";
            this.帮助ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.帮助ToolStripMenuItem.Text = "帮助";
            // 
            // 辅助工具ToolStripMenuItem
            // 
            this.辅助工具ToolStripMenuItem.Name = "辅助工具ToolStripMenuItem";
            this.辅助工具ToolStripMenuItem.Size = new System.Drawing.Size(142, 22);
            this.辅助工具ToolStripMenuItem.Text = "辅助工具";
            // 
            // tsmi_About
            // 
            this.tsmi_About.Name = "tsmi_About";
            this.tsmi_About.Size = new System.Drawing.Size(142, 22);
            this.tsmi_About.Text = "关于Gmage";
            this.tsmi_About.Click += new System.EventHandler(this.tsmi_About_Click);
            // 
            // tsmi_Index
            // 
            this.tsmi_Index.ForeColor = System.Drawing.Color.White;
            this.tsmi_Index.Name = "tsmi_Index";
            this.tsmi_Index.Size = new System.Drawing.Size(56, 21);
            this.tsmi_Index.Text = "选项卡";
            // 
            // mtS_Selected
            // 
            this.mtS_Selected.BaseTabControl = null;
            this.mtS_Selected.ContextMenuStrip = this.materialContextMenuStrip1;
            this.mtS_Selected.Depth = 0;
            this.mtS_Selected.Location = new System.Drawing.Point(72, 44);
            this.mtS_Selected.MouseState = MaterialSkin.MouseState.HOVER;
            this.mtS_Selected.Name = "mtS_Selected";
            this.mtS_Selected.Size = new System.Drawing.Size(719, 18);
            this.mtS_Selected.TabIndex = 18;
            this.mtS_Selected.Text = "materialTabSelector1";
            this.mtS_Selected.TabIndexChanged += new System.EventHandler(this.materialTabSelector1_TabIndexChanged);
            // 
            // mTC_ImageTab
            // 
            this.mTC_ImageTab.AllowDrop = true;
            this.mTC_ImageTab.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mTC_ImageTab.Depth = 0;
            this.mTC_ImageTab.Location = new System.Drawing.Point(12, 68);
            this.mTC_ImageTab.MouseState = MaterialSkin.MouseState.HOVER;
            this.mTC_ImageTab.Name = "mTC_ImageTab";
            this.mTC_ImageTab.SelectedIndex = 0;
            this.mTC_ImageTab.Size = new System.Drawing.Size(770, 648);
            this.mTC_ImageTab.TabIndex = 19;
            this.mTC_ImageTab.Visible = false;
            this.mTC_ImageTab.SelectedIndexChanged += new System.EventHandler(this.materialTabSelector1_TabIndexChanged);
            this.mTC_ImageTab.TabIndexChanged += new System.EventHandler(this.materialTabSelector1_TabIndexChanged);
            this.mTC_ImageTab.DragDrop += new System.Windows.Forms.DragEventHandler(this.mTC_ImageTab_DragDrop);
            this.mTC_ImageTab.DragOver += new System.Windows.Forms.DragEventHandler(this.mTC_ImageTab_DragOver);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Location = new System.Drawing.Point(72, 26);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(719, 17);
            this.panel2.TabIndex = 20;
            // 
            // mPB_Bar
            // 
            this.mPB_Bar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mPB_Bar.BackColor = System.Drawing.SystemColors.Highlight;
            this.mPB_Bar.Depth = 0;
            this.mPB_Bar.ForeColor = System.Drawing.SystemColors.Control;
            this.mPB_Bar.Location = new System.Drawing.Point(0, 61);
            this.mPB_Bar.MouseState = MaterialSkin.MouseState.HOVER;
            this.mPB_Bar.Name = "mPB_Bar";
            this.mPB_Bar.Size = new System.Drawing.Size(794, 5);
            this.mPB_Bar.Step = 1;
            this.mPB_Bar.TabIndex = 22;
            this.mPB_Bar.Visible = false;
            // 
            // panel1
            // 
            this.panel1.AllowDrop = true;
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.BackgroundImage = global::Gmage.Properties.Resources.Gmage;
            this.panel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panel1.Location = new System.Drawing.Point(13, 131);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(769, 423);
            this.panel1.TabIndex = 21;
            this.panel1.Click += new System.EventHandler(this.btn_SelectImage_Click);
            this.panel1.DragDrop += new System.Windows.Forms.DragEventHandler(this.mTC_ImageTab_DragDrop);
            this.panel1.DragOver += new System.Windows.Forms.DragEventHandler(this.mTC_ImageTab_DragOver);
            // 
            // MainForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(794, 728);
            this.Controls.Add(this.mPB_Bar);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.mtS_Selected);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mTC_ImageTab);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gmage";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.materialContextMenuStrip1.ResumeLayout(false);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialContextMenuStrip materialContextMenuStrip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 选择图片ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 另存为ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Clear;
        private System.Windows.Forms.ToolStripMenuItem 首选项ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Image;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Change;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Lighten;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Contrast;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Gray;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Binarization;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Complementary;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Frequency;
        private System.Windows.Forms.ToolStripMenuItem 直方图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图像旋转ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 模糊ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Tsmi_GaussBlur;
        private System.Windows.Forms.ToolStripMenuItem tsmi_MedianFilter;
        private System.Windows.Forms.ToolStripMenuItem 噪声ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_GaussNoise;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Salt;
        private System.Windows.Forms.ToolStripMenuItem 扭曲ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Polar;
        private System.Windows.Forms.ToolStripMenuItem 边缘检测ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Robert;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Smoothed;
        private System.Windows.Forms.ToolStripMenuItem 字符化ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Batch;
        private System.Windows.Forms.ToolStripMenuItem 帮助ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_About;
        private System.Windows.Forms.ToolStripMenuItem 辅助工具ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsm_CloseTabPage;
        private MaterialSkin.Controls.MaterialTabSelector mtS_Selected;
        private MaterialSkin.Controls.MaterialTabControl mTC_ImageTab;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Sharpen;
        private System.Windows.Forms.ToolStripMenuItem 级联分类器ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Classifier;
        private System.Windows.Forms.ToolStripMenuItem 识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Clockwise180;
        private System.Windows.Forms.ToolStripMenuItem Clockwise90;
        private System.Windows.Forms.ToolStripMenuItem Clockwise270;
        private System.Windows.Forms.ToolStripMenuItem RotateNoneFlipX;
        private System.Windows.Forms.ToolStripMenuItem RotateNoneFlipY;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.ToolStripMenuItem tsmi_Index;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        internal System.Windows.Forms.ToolStripMenuItem tsmi_Filter;
        private MaterialSkin.Controls.MaterialProgressBar mPB_Bar;
    }
}

