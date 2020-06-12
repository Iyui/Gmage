namespace Gmage.Process
{
    partial class Threshold
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
            this.tB_Threshold = new System.Windows.Forms.TrackBar();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.mT_T = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_Threshold
            // 
            this.tB_Threshold.AutoSize = false;
            this.tB_Threshold.Location = new System.Drawing.Point(98, 30);
            this.tB_Threshold.Maximum = 255;
            this.tB_Threshold.Name = "tB_Threshold";
            this.tB_Threshold.Size = new System.Drawing.Size(199, 25);
            this.tB_Threshold.TabIndex = 3;
            this.tB_Threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Threshold.Value = 128;
            this.tB_Threshold.Scroll += new System.EventHandler(this.tB_Threshold_Scroll);
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(303, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(44, 25);
            this.button1.TabIndex = 26;
            this.button1.Text = "确定";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.mFB_Select_Click);
            // 
            // button2
            // 
            this.button2.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(353, 30);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(44, 25);
            this.button2.TabIndex = 27;
            this.button2.Text = "取消";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // mT_T
            // 
            this.mT_T.Depth = 0;
            this.mT_T.ForeColor = System.Drawing.Color.White;
            this.mT_T.Hint = "";
            this.mT_T.Location = new System.Drawing.Point(56, 32);
            this.mT_T.MaxLength = 32767;
            this.mT_T.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_T.Name = "mT_T";
            this.mT_T.PasswordChar = '\0';
            this.mT_T.SelectedText = "";
            this.mT_T.SelectionLength = 0;
            this.mT_T.SelectionStart = 0;
            this.mT_T.Size = new System.Drawing.Size(36, 23);
            this.mT_T.TabIndex = 28;
            this.mT_T.TabStop = false;
            this.mT_T.Text = "51";
            this.mT_T.UseSystemPasswordChar = false;
            // 
            // Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 64);
            this.Controls.Add(this.mT_T);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.tB_Threshold);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Threshold";
            this.ShowInTaskbar = false;
            this.Text = "阈值";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Threshold_FormClosing);
            this.Load += new System.EventHandler(this.Threshold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tB_Threshold)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TrackBar tB_Threshold;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_T;
    }
}