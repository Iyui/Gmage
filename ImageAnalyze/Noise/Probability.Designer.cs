namespace ImageAnalyze
{
    partial class Probability
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
            this.tB_Pepper = new System.Windows.Forms.TrackBar();
            this.tB_Salt = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_MedianFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Pepper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Salt)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_Pepper
            // 
            this.tB_Pepper.Location = new System.Drawing.Point(49, 12);
            this.tB_Pepper.Maximum = 1000;
            this.tB_Pepper.Name = "tB_Pepper";
            this.tB_Pepper.Size = new System.Drawing.Size(155, 45);
            this.tB_Pepper.TabIndex = 0;
            this.tB_Pepper.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Pepper.Value = 1;
            this.tB_Pepper.Scroll += new System.EventHandler(this.tB_Pepper_Scroll);
            // 
            // tB_Salt
            // 
            this.tB_Salt.Location = new System.Drawing.Point(49, 52);
            this.tB_Salt.Maximum = 1000;
            this.tB_Salt.Name = "tB_Salt";
            this.tB_Salt.Size = new System.Drawing.Size(155, 45);
            this.tB_Salt.TabIndex = 1;
            this.tB_Salt.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Salt.Value = 1;
            this.tB_Salt.Scroll += new System.EventHandler(this.tB_Salt_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(2, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "椒概率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(2, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "盐概率";
            // 
            // btn_MedianFilter
            // 
            this.btn_MedianFilter.Location = new System.Drawing.Point(132, 92);
            this.btn_MedianFilter.Name = "btn_MedianFilter";
            this.btn_MedianFilter.Size = new System.Drawing.Size(82, 23);
            this.btn_MedianFilter.TabIndex = 21;
            this.btn_MedianFilter.Tag = "";
            this.btn_MedianFilter.Text = "中值滤波";
            this.btn_MedianFilter.UseVisualStyleBackColor = true;
            this.btn_MedianFilter.Click += new System.EventHandler(this.btn_MedianFilter_Click);
            // 
            // Probability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(226, 127);
            this.Controls.Add(this.btn_MedianFilter);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_Salt);
            this.Controls.Add(this.tB_Pepper);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Probability";
            this.ShowInTaskbar = false;
            this.Text = "椒盐噪声概率";
            ((System.ComponentModel.ISupportInitialize)(this.tB_Pepper)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Salt)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tB_Pepper;
        private System.Windows.Forms.TrackBar tB_Salt;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_MedianFilter;
    }
}