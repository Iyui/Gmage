namespace Gmage.Process
{
    partial class TwoThreshold
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
            this.label3 = new System.Windows.Forms.Label();
            this.tB_bar2 = new System.Windows.Forms.TrackBar();
            this.tB_bar1 = new System.Windows.Forms.TrackBar();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            this.mT_mt2 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mT_mt1 = new MaterialSkin.Controls.MaterialSingleLineTextField();
            ((System.ComponentModel.ISupportInitialize)(this.tB_bar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_bar1)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 13F);
            this.label3.Location = new System.Drawing.Point(12, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 18);
            this.label3.TabIndex = 9;
            this.label3.Text = "阈值";
            // 
            // tB_bar2
            // 
            this.tB_bar2.AutoSize = false;
            this.tB_bar2.Location = new System.Drawing.Point(83, 75);
            this.tB_bar2.Maximum = 1000;
            this.tB_bar2.Name = "tB_bar2";
            this.tB_bar2.Size = new System.Drawing.Size(155, 27);
            this.tB_bar2.TabIndex = 6;
            this.tB_bar2.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_bar2.Value = 1;
            // 
            // tB_bar1
            // 
            this.tB_bar1.AutoSize = false;
            this.tB_bar1.Location = new System.Drawing.Point(83, 32);
            this.tB_bar1.Maximum = 1000;
            this.tB_bar1.Name = "tB_bar1";
            this.tB_bar1.Size = new System.Drawing.Size(155, 27);
            this.tB_bar1.TabIndex = 5;
            this.tB_bar1.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tB_bar1.Value = 1;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(305, 73);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(44, 25);
            this.btn_Cancel.TabIndex = 46;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(305, 31);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(44, 25);
            this.btn_OK.TabIndex = 45;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // mT_mt2
            // 
            this.mT_mt2.Depth = 0;
            this.mT_mt2.Hint = "";
            this.mT_mt2.Location = new System.Drawing.Point(251, 75);
            this.mT_mt2.MaxLength = 32767;
            this.mT_mt2.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_mt2.Name = "mT_mt2";
            this.mT_mt2.PasswordChar = '\0';
            this.mT_mt2.SelectedText = "";
            this.mT_mt2.SelectionLength = 0;
            this.mT_mt2.SelectionStart = 0;
            this.mT_mt2.Size = new System.Drawing.Size(36, 23);
            this.mT_mt2.TabIndex = 44;
            this.mT_mt2.TabStop = false;
            this.mT_mt2.Text = "1";
            this.mT_mt2.UseSystemPasswordChar = false;
            // 
            // mT_mt1
            // 
            this.mT_mt1.Depth = 0;
            this.mT_mt1.ForeColor = System.Drawing.Color.White;
            this.mT_mt1.Hint = "";
            this.mT_mt1.Location = new System.Drawing.Point(251, 33);
            this.mT_mt1.MaxLength = 32767;
            this.mT_mt1.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_mt1.Name = "mT_mt1";
            this.mT_mt1.PasswordChar = '\0';
            this.mT_mt1.SelectedText = "";
            this.mT_mt1.SelectionLength = 0;
            this.mT_mt1.SelectionStart = 0;
            this.mT_mt1.Size = new System.Drawing.Size(36, 23);
            this.mT_mt1.TabIndex = 43;
            this.mT_mt1.TabStop = false;
            this.mT_mt1.Text = "1";
            this.mT_mt1.UseSystemPasswordChar = false;
            // 
            // TwoThreshold
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 114);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.mT_mt2);
            this.Controls.Add(this.mT_mt1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tB_bar2);
            this.Controls.Add(this.tB_bar1);
            this.Name = "TwoThreshold";
            this.Text = "半径";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TwoThreshold_FormClosing);
            this.Load += new System.EventHandler(this.TwoThreshold_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tB_bar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tB_bar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TrackBar tB_bar2;
        private System.Windows.Forms.TrackBar tB_bar1;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_mt2;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_mt1;
    }
}