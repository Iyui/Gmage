namespace Gmage
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
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Pepper)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_Salt)).BeginInit();
            this.SuspendLayout();
            // 
            // tB_Pepper
            // 
            this.tB_Pepper.AutoSize = false;
            this.tB_Pepper.Location = new System.Drawing.Point(158, 28);
            this.tB_Pepper.Maximum = 1000;
            this.tB_Pepper.Name = "tB_Pepper";
            this.tB_Pepper.Size = new System.Drawing.Size(155, 27);
            this.tB_Pepper.TabIndex = 0;
            this.tB_Pepper.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Pepper.Value = 1;
            this.tB_Pepper.Scroll += new System.EventHandler(this.tB_Pepper_Scroll);
            // 
            // tB_Salt
            // 
            this.tB_Salt.AutoSize = false;
            this.tB_Salt.Location = new System.Drawing.Point(158, 71);
            this.tB_Salt.Maximum = 1000;
            this.tB_Salt.Name = "tB_Salt";
            this.tB_Salt.Size = new System.Drawing.Size(155, 27);
            this.tB_Salt.TabIndex = 1;
            this.tB_Salt.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_Salt.Value = 1;
            this.tB_Salt.Scroll += new System.EventHandler(this.tB_Salt_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(85, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 2;
            this.label1.Text = "椒概率";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 9F);
            this.label2.Location = new System.Drawing.Point(85, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "盐概率";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(12, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(62, 18);
            this.label3.TabIndex = 4;
            this.label3.Text = "盐噪声";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(1, 63);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(324, 46);
            this.panel1.TabIndex = 5;
            // 
            // Probability
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(325, 113);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tB_Salt);
            this.Controls.Add(this.tB_Pepper);
            this.Controls.Add(this.panel1);
            this.ForeColor = System.Drawing.Color.Black;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Probability";
            this.ShowInTaskbar = false;
            this.Text = "椒噪声";
            this.Load += new System.EventHandler(this.Probability_Load);
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
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
    }
}