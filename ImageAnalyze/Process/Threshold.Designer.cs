﻿namespace ImageAnalyze.Process
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
            this.label1 = new System.Windows.Forms.Label();
            this.tB_Threshold = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Threshold)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "阈值";
            // 
            // tB_Threshold
            // 
            this.tB_Threshold.Location = new System.Drawing.Point(59, 21);
            this.tB_Threshold.Maximum = 255;
            this.tB_Threshold.Name = "tB_Threshold";
            this.tB_Threshold.Size = new System.Drawing.Size(170, 45);
            this.tB_Threshold.TabIndex = 3;
            this.tB_Threshold.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Threshold.Value = 128;
            this.tB_Threshold.Scroll += new System.EventHandler(this.tB_Threshold_Scroll);
            // 
            // Threshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(236, 72);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_Threshold);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Threshold";
            this.ShowInTaskbar = false;
            this.Text = "阈值";
            this.Load += new System.EventHandler(this.Threshold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tB_Threshold)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar tB_Threshold;
    }
}