namespace Gmage
{
    partial class LoadForm
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
            this.mPB_Progress = new MaterialSkin.Controls.MaterialProgressBar();
            this.mL_load = new MaterialSkin.Controls.MaterialLabel();
            this.SuspendLayout();
            // 
            // mPB_Progress
            // 
            this.mPB_Progress.Depth = 0;
            this.mPB_Progress.Location = new System.Drawing.Point(0, 122);
            this.mPB_Progress.MouseState = MaterialSkin.MouseState.HOVER;
            this.mPB_Progress.Name = "mPB_Progress";
            this.mPB_Progress.Size = new System.Drawing.Size(303, 5);
            this.mPB_Progress.TabIndex = 0;
            this.mPB_Progress.Visible = false;
            // 
            // mL_load
            // 
            this.mL_load.AutoSize = true;
            this.mL_load.Depth = 0;
            this.mL_load.Font = new System.Drawing.Font("Roboto", 11F);
            this.mL_load.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(222)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.mL_load.Location = new System.Drawing.Point(89, 84);
            this.mL_load.MouseState = MaterialSkin.MouseState.HOVER;
            this.mL_load.Name = "mL_load";
            this.mL_load.Size = new System.Drawing.Size(108, 19);
            this.mL_load.TabIndex = 2;
            this.mL_load.Text = "materialLabel1";
            // 
            // LoadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(303, 127);
            this.Controls.Add(this.mL_load);
            this.Controls.Add(this.mPB_Progress);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "LoadForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "LoadForm";
            this.Load += new System.EventHandler(this.LoadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MaterialSkin.Controls.MaterialProgressBar mPB_Progress;
        private MaterialSkin.Controls.MaterialLabel mL_load;
    }
}