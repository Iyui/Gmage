namespace Gmage
{
    partial class Preferences
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.materialTabSelector1 = new MaterialSkin.Controls.MaterialTabSelector();
            this.materialTabControl1 = new MaterialSkin.Controls.MaterialTabControl();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cB_FirstForm = new System.Windows.Forms.ComboBox();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.mRB_LIght = new MaterialSkin.Controls.MaterialRadioButton();
            this.mRB_Dark = new MaterialSkin.Controls.MaterialRadioButton();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.MCB_ChildIndex = new MaterialSkin.Controls.MaterialCheckBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.materialFlatButton6 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton5 = new MaterialSkin.Controls.MaterialFlatButton();
            this.lB_Plugin = new System.Windows.Forms.ListBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lB_Classifier = new System.Windows.Forms.ListBox();
            this.materialFlatButton4 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton3 = new MaterialSkin.Controls.MaterialFlatButton();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mFB_OK = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialFlatButton2 = new MaterialSkin.Controls.MaterialFlatButton();
            this.materialTabControl1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // materialTabSelector1
            // 
            this.materialTabSelector1.BaseTabControl = this.materialTabControl1;
            this.materialTabSelector1.Depth = 0;
            this.materialTabSelector1.Location = new System.Drawing.Point(114, 26);
            this.materialTabSelector1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabSelector1.Name = "materialTabSelector1";
            this.materialTabSelector1.Size = new System.Drawing.Size(674, 38);
            this.materialTabSelector1.TabIndex = 0;
            this.materialTabSelector1.Text = "materialTabSelector1";
            // 
            // materialTabControl1
            // 
            this.materialTabControl1.Controls.Add(this.tabPage4);
            this.materialTabControl1.Controls.Add(this.tabPage1);
            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Add(this.tabPage3);
            this.materialTabControl1.Depth = 0;
            this.materialTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.materialTabControl1.Location = new System.Drawing.Point(0, 0);
            this.materialTabControl1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialTabControl1.Multiline = true;
            this.materialTabControl1.Name = "materialTabControl1";
            this.materialTabControl1.SelectedIndex = 0;
            this.materialTabControl1.Size = new System.Drawing.Size(776, 372);
            this.materialTabControl1.TabIndex = 1;
            // 
            // tabPage4
            // 
            this.tabPage4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage4.Controls.Add(this.groupBox3);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage4.Size = new System.Drawing.Size(768, 346);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "常规";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cB_FirstForm);
            this.groupBox3.ForeColor = System.Drawing.Color.White;
            this.groupBox3.Location = new System.Drawing.Point(22, 15);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 65);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "默认界面";
            // 
            // cB_FirstForm
            // 
            this.cB_FirstForm.BackColor = System.Drawing.Color.White;
            this.cB_FirstForm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cB_FirstForm.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cB_FirstForm.Font = new System.Drawing.Font("宋体", 10F);
            this.cB_FirstForm.ForeColor = System.Drawing.Color.White;
            this.cB_FirstForm.Items.AddRange(new object[] {
            "主页面",
            "批处理"});
            this.cB_FirstForm.Location = new System.Drawing.Point(37, 22);
            this.cB_FirstForm.Name = "cB_FirstForm";
            this.cB_FirstForm.Size = new System.Drawing.Size(121, 21);
            this.cB_FirstForm.TabIndex = 1;
            // 
            // tabPage1
            // 
            this.tabPage1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(768, 346);
            this.tabPage1.TabIndex = 5;
            this.tabPage1.Text = "界面";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.mRB_LIght);
            this.groupBox1.Controls.Add(this.mRB_Dark);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(200, 314);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "视觉体验";
            // 
            // mRB_LIght
            // 
            this.mRB_LIght.AutoSize = true;
            this.mRB_LIght.Depth = 0;
            this.mRB_LIght.Font = new System.Drawing.Font("Roboto", 10F);
            this.mRB_LIght.Location = new System.Drawing.Point(21, 26);
            this.mRB_LIght.Margin = new System.Windows.Forms.Padding(0);
            this.mRB_LIght.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mRB_LIght.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRB_LIght.Name = "mRB_LIght";
            this.mRB_LIght.Ripple = true;
            this.mRB_LIght.Size = new System.Drawing.Size(59, 30);
            this.mRB_LIght.TabIndex = 1;
            this.mRB_LIght.Text = "浅色";
            this.mRB_LIght.UseVisualStyleBackColor = true;
            // 
            // mRB_Dark
            // 
            this.mRB_Dark.AutoSize = true;
            this.mRB_Dark.Checked = true;
            this.mRB_Dark.Depth = 0;
            this.mRB_Dark.Font = new System.Drawing.Font("Roboto", 10F);
            this.mRB_Dark.Location = new System.Drawing.Point(21, 75);
            this.mRB_Dark.Margin = new System.Windows.Forms.Padding(0);
            this.mRB_Dark.MouseLocation = new System.Drawing.Point(-1, -1);
            this.mRB_Dark.MouseState = MaterialSkin.MouseState.HOVER;
            this.mRB_Dark.Name = "mRB_Dark";
            this.mRB_Dark.Ripple = true;
            this.mRB_Dark.Size = new System.Drawing.Size(59, 30);
            this.mRB_Dark.TabIndex = 0;
            this.mRB_Dark.TabStop = true;
            this.mRB_Dark.Text = "深色";
            this.mRB_Dark.UseVisualStyleBackColor = true;
            // 
            // tabPage5
            // 
            this.tabPage5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage5.Controls.Add(this.groupBox2);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage5.Size = new System.Drawing.Size(768, 346);
            this.tabPage5.TabIndex = 7;
            this.tabPage5.Text = "批处理";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.MCB_ChildIndex);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(22, 15);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 314);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "文件";
            // 
            // MCB_ChildIndex
            // 
            this.MCB_ChildIndex.AutoSize = true;
            this.MCB_ChildIndex.Cursor = System.Windows.Forms.Cursors.Default;
            this.MCB_ChildIndex.Depth = 0;
            this.MCB_ChildIndex.Font = new System.Drawing.Font("Roboto", 10F);
            this.MCB_ChildIndex.Location = new System.Drawing.Point(18, 30);
            this.MCB_ChildIndex.Margin = new System.Windows.Forms.Padding(0);
            this.MCB_ChildIndex.MouseLocation = new System.Drawing.Point(-1, -1);
            this.MCB_ChildIndex.MouseState = MaterialSkin.MouseState.HOVER;
            this.MCB_ChildIndex.Name = "MCB_ChildIndex";
            this.MCB_ChildIndex.Ripple = true;
            this.MCB_ChildIndex.Size = new System.Drawing.Size(105, 30);
            this.MCB_ChildIndex.TabIndex = 5;
            this.MCB_ChildIndex.Text = "遍历子目录";
            this.MCB_ChildIndex.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tabPage3.Controls.Add(this.groupBox4);
            this.tabPage3.Controls.Add(this.groupBox5);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(768, 346);
            this.tabPage3.TabIndex = 9;
            this.tabPage3.Text = "分类器/插件";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.materialFlatButton6);
            this.groupBox4.Controls.Add(this.materialFlatButton5);
            this.groupBox4.Controls.Add(this.lB_Plugin);
            this.groupBox4.ForeColor = System.Drawing.Color.White;
            this.groupBox4.Location = new System.Drawing.Point(397, 15);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(342, 314);
            this.groupBox4.TabIndex = 5;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "插件";
            // 
            // materialFlatButton6
            // 
            this.materialFlatButton6.BackColor = System.Drawing.Color.LightSeaGreen;
            this.materialFlatButton6.Depth = 0;
            this.materialFlatButton6.Icon = null;
            this.materialFlatButton6.Location = new System.Drawing.Point(19, 28);
            this.materialFlatButton6.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton6.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton6.Name = "materialFlatButton6";
            this.materialFlatButton6.Primary = false;
            this.materialFlatButton6.Size = new System.Drawing.Size(96, 36);
            this.materialFlatButton6.TabIndex = 6;
            this.materialFlatButton6.Text = "加载插件";
            this.materialFlatButton6.UseVisualStyleBackColor = false;
            // 
            // materialFlatButton5
            // 
            this.materialFlatButton5.Depth = 0;
            this.materialFlatButton5.Icon = null;
            this.materialFlatButton5.Location = new System.Drawing.Point(19, 76);
            this.materialFlatButton5.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton5.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton5.Name = "materialFlatButton5";
            this.materialFlatButton5.Primary = false;
            this.materialFlatButton5.Size = new System.Drawing.Size(96, 36);
            this.materialFlatButton5.TabIndex = 7;
            this.materialFlatButton5.Text = "卸载插件";
            this.materialFlatButton5.UseVisualStyleBackColor = true;
            // 
            // lB_Plugin
            // 
            this.lB_Plugin.Font = new System.Drawing.Font("宋体", 11F);
            this.lB_Plugin.ForeColor = System.Drawing.Color.White;
            this.lB_Plugin.FormattingEnabled = true;
            this.lB_Plugin.ItemHeight = 15;
            this.lB_Plugin.Location = new System.Drawing.Point(129, 28);
            this.lB_Plugin.Name = "lB_Plugin";
            this.lB_Plugin.Size = new System.Drawing.Size(200, 259);
            this.lB_Plugin.TabIndex = 1;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lB_Classifier);
            this.groupBox5.Controls.Add(this.materialFlatButton4);
            this.groupBox5.Controls.Add(this.materialFlatButton3);
            this.groupBox5.ForeColor = System.Drawing.Color.White;
            this.groupBox5.Location = new System.Drawing.Point(22, 15);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(342, 314);
            this.groupBox5.TabIndex = 2;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "级联分类器";
            // 
            // lB_Classifier
            // 
            this.lB_Classifier.Font = new System.Drawing.Font("宋体", 11F);
            this.lB_Classifier.ForeColor = System.Drawing.Color.White;
            this.lB_Classifier.FormattingEnabled = true;
            this.lB_Classifier.ItemHeight = 15;
            this.lB_Classifier.Location = new System.Drawing.Point(127, 28);
            this.lB_Classifier.Name = "lB_Classifier";
            this.lB_Classifier.Size = new System.Drawing.Size(200, 259);
            this.lB_Classifier.TabIndex = 0;
            // 
            // materialFlatButton4
            // 
            this.materialFlatButton4.AutoSize = true;
            this.materialFlatButton4.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton4.Depth = 0;
            this.materialFlatButton4.Icon = null;
            this.materialFlatButton4.Location = new System.Drawing.Point(17, 76);
            this.materialFlatButton4.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton4.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton4.Name = "materialFlatButton4";
            this.materialFlatButton4.Primary = false;
            this.materialFlatButton4.Size = new System.Drawing.Size(96, 36);
            this.materialFlatButton4.TabIndex = 4;
            this.materialFlatButton4.Text = "删除分类器";
            this.materialFlatButton4.UseVisualStyleBackColor = true;
            // 
            // materialFlatButton3
            // 
            this.materialFlatButton3.AutoSize = true;
            this.materialFlatButton3.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.materialFlatButton3.BackColor = System.Drawing.Color.LightSeaGreen;
            this.materialFlatButton3.Depth = 0;
            this.materialFlatButton3.Icon = null;
            this.materialFlatButton3.Location = new System.Drawing.Point(17, 28);
            this.materialFlatButton3.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton3.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton3.Name = "materialFlatButton3";
            this.materialFlatButton3.Primary = false;
            this.materialFlatButton3.Size = new System.Drawing.Size(96, 36);
            this.materialFlatButton3.TabIndex = 3;
            this.materialFlatButton3.Text = "添加分类器";
            this.materialFlatButton3.UseVisualStyleBackColor = false;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.materialTabControl1);
            this.panel1.ForeColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(12, 70);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 372);
            this.panel1.TabIndex = 2;
            // 
            // mFB_OK
            // 
            this.mFB_OK.Depth = 0;
            this.mFB_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.mFB_OK.Icon = null;
            this.mFB_OK.Location = new System.Drawing.Point(610, 454);
            this.mFB_OK.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.mFB_OK.MouseState = MaterialSkin.MouseState.HOVER;
            this.mFB_OK.Name = "mFB_OK";
            this.mFB_OK.Primary = false;
            this.mFB_OK.Size = new System.Drawing.Size(75, 23);
            this.mFB_OK.TabIndex = 3;
            this.mFB_OK.Text = "确定";
            this.mFB_OK.UseVisualStyleBackColor = true;
            this.mFB_OK.Click += new System.EventHandler(this.mFB_OK_Click);
            // 
            // materialFlatButton2
            // 
            this.materialFlatButton2.Depth = 0;
            this.materialFlatButton2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.materialFlatButton2.Icon = null;
            this.materialFlatButton2.Location = new System.Drawing.Point(709, 454);
            this.materialFlatButton2.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton2.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton2.Name = "materialFlatButton2";
            this.materialFlatButton2.Primary = false;
            this.materialFlatButton2.Size = new System.Drawing.Size(75, 23);
            this.materialFlatButton2.TabIndex = 4;
            this.materialFlatButton2.Text = "取消";
            this.materialFlatButton2.UseVisualStyleBackColor = true;
            // 
            // Preferences
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 492);
            this.Controls.Add(this.materialFlatButton2);
            this.Controls.Add(this.mFB_OK);
            this.Controls.Add(this.materialTabSelector1);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Preferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "首选项";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Preferences_FormClosing);
            this.Load += new System.EventHandler(this.Preferences_Load);
            this.materialTabControl1.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabPage5.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private MaterialSkin.Controls.MaterialTabSelector materialTabSelector1;
        private MaterialSkin.Controls.MaterialTabControl materialTabControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage5;
        private System.Windows.Forms.GroupBox groupBox2;
        private MaterialSkin.Controls.MaterialCheckBox MCB_ChildIndex;
        private System.Windows.Forms.ComboBox cB_FirstForm;
        private MaterialSkin.Controls.MaterialFlatButton mFB_OK;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.GroupBox groupBox1;
        private MaterialSkin.Controls.MaterialRadioButton mRB_LIght;
        private MaterialSkin.Controls.MaterialRadioButton mRB_Dark;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.GroupBox groupBox5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton4;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton3;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton5;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton6;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ListBox lB_Plugin;
        private System.Windows.Forms.ListBox lB_Classifier;
    }
}