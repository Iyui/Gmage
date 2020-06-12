namespace Gmage
{
    partial class BatchModel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BatchModel));
            this.lB_Task = new System.Windows.Forms.ListBox();
            this.materialFlatButton1 = new MaterialSkin.Controls.MaterialFlatButton();
            this.SuspendLayout();
            // 
            // lB_Task
            // 
            this.lB_Task.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lB_Task.Font = new System.Drawing.Font("宋体", 12F);
            this.lB_Task.FormattingEnabled = true;
            this.lB_Task.ItemHeight = 16;
            this.lB_Task.Location = new System.Drawing.Point(1, 60);
            this.lB_Task.Name = "lB_Task";
            this.lB_Task.Size = new System.Drawing.Size(212, 176);
            this.lB_Task.TabIndex = 0;
            // 
            // materialFlatButton1
            // 
            this.materialFlatButton1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.materialFlatButton1.AutoSize = true;
            this.materialFlatButton1.BackColor = System.Drawing.Color.Transparent;
            this.materialFlatButton1.Depth = 0;
            this.materialFlatButton1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.materialFlatButton1.Font = new System.Drawing.Font("宋体", 15F);
            this.materialFlatButton1.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.materialFlatButton1.Icon = null;
            this.materialFlatButton1.Location = new System.Drawing.Point(1, 234);
            this.materialFlatButton1.Margin = new System.Windows.Forms.Padding(4, 6, 4, 6);
            this.materialFlatButton1.MouseState = MaterialSkin.MouseState.HOVER;
            this.materialFlatButton1.Name = "materialFlatButton1";
            this.materialFlatButton1.Primary = false;
            this.materialFlatButton1.Size = new System.Drawing.Size(233, 36);
            this.materialFlatButton1.TabIndex = 17;
            this.materialFlatButton1.Text = "                      确定                              .";
            this.materialFlatButton1.UseVisualStyleBackColor = false;
            this.materialFlatButton1.Click += new System.EventHandler(this.materialFlatButton1_Click);
            // 
            // BatchModel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(212, 271);
            this.Controls.Add(this.materialFlatButton1);
            this.Controls.Add(this.lB_Task);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BatchModel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "任务选择";
            this.Load += new System.EventHandler(this.BatchModel_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox lB_Task;
        private MaterialSkin.Controls.MaterialFlatButton materialFlatButton1;
    }
}