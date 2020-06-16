namespace Gmage.Process
{
    partial class RGB_Channnels
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
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.mT_CB = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mT_CG = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.mT_CR = new MaterialSkin.Controls.MaterialSingleLineTextField();
            this.tb_CG = new System.Windows.Forms.TrackBar();
            this.tb_CR = new System.Windows.Forms.TrackBar();
            this.tb_CB = new System.Windows.Forms.TrackBar();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.btn_OK = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tb_CG)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_CR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_CB)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 10F);
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(23, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(21, 14);
            this.label4.TabIndex = 40;
            this.label4.Text = "B%";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 10F);
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(23, 112);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(21, 14);
            this.label5.TabIndex = 39;
            this.label5.Text = "G%";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 10F);
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(23, 81);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(21, 14);
            this.label6.TabIndex = 38;
            this.label6.Text = "R%";
            // 
            // mT_CB
            // 
            this.mT_CB.Depth = 0;
            this.mT_CB.Hint = "";
            this.mT_CB.Location = new System.Drawing.Point(170, 139);
            this.mT_CB.MaxLength = 32767;
            this.mT_CB.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_CB.Name = "mT_CB";
            this.mT_CB.PasswordChar = '\0';
            this.mT_CB.SelectedText = "";
            this.mT_CB.SelectionLength = 0;
            this.mT_CB.SelectionStart = 0;
            this.mT_CB.Size = new System.Drawing.Size(36, 23);
            this.mT_CB.TabIndex = 36;
            this.mT_CB.TabStop = false;
            this.mT_CB.Text = "100";
            this.mT_CB.UseSystemPasswordChar = false;
            // 
            // mT_CG
            // 
            this.mT_CG.Depth = 0;
            this.mT_CG.Hint = "";
            this.mT_CG.Location = new System.Drawing.Point(170, 108);
            this.mT_CG.MaxLength = 32767;
            this.mT_CG.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_CG.Name = "mT_CG";
            this.mT_CG.PasswordChar = '\0';
            this.mT_CG.SelectedText = "";
            this.mT_CG.SelectionLength = 0;
            this.mT_CG.SelectionStart = 0;
            this.mT_CG.Size = new System.Drawing.Size(36, 23);
            this.mT_CG.TabIndex = 37;
            this.mT_CG.TabStop = false;
            this.mT_CG.Text = "100";
            this.mT_CG.UseSystemPasswordChar = false;
            // 
            // mT_CR
            // 
            this.mT_CR.Depth = 0;
            this.mT_CR.ForeColor = System.Drawing.Color.White;
            this.mT_CR.Hint = "";
            this.mT_CR.Location = new System.Drawing.Point(170, 77);
            this.mT_CR.MaxLength = 32767;
            this.mT_CR.MouseState = MaterialSkin.MouseState.HOVER;
            this.mT_CR.Name = "mT_CR";
            this.mT_CR.PasswordChar = '\0';
            this.mT_CR.SelectedText = "";
            this.mT_CR.SelectionLength = 0;
            this.mT_CR.SelectionStart = 0;
            this.mT_CR.Size = new System.Drawing.Size(36, 23);
            this.mT_CR.TabIndex = 35;
            this.mT_CR.TabStop = false;
            this.mT_CR.Text = "100";
            this.mT_CR.UseSystemPasswordChar = false;
            // 
            // tb_CG
            // 
            this.tb_CG.AutoSize = false;
            this.tb_CG.Location = new System.Drawing.Point(47, 109);
            this.tb_CG.Maximum = 1000;
            this.tb_CG.Name = "tb_CG";
            this.tb_CG.Size = new System.Drawing.Size(112, 25);
            this.tb_CG.TabIndex = 33;
            this.tb_CG.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_CG.Value = 100;
            // 
            // tb_CR
            // 
            this.tb_CR.AutoSize = false;
            this.tb_CR.Location = new System.Drawing.Point(47, 78);
            this.tb_CR.Maximum = 1000;
            this.tb_CR.Name = "tb_CR";
            this.tb_CR.Size = new System.Drawing.Size(112, 25);
            this.tb_CR.TabIndex = 32;
            this.tb_CR.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_CR.Value = 100;
            // 
            // tb_CB
            // 
            this.tb_CB.AutoSize = false;
            this.tb_CB.Location = new System.Drawing.Point(47, 140);
            this.tb_CB.Maximum = 1000;
            this.tb_CB.Name = "tb_CB";
            this.tb_CB.Size = new System.Drawing.Size(112, 25);
            this.tb_CB.TabIndex = 34;
            this.tb_CB.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tb_CB.Value = 100;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.ForeColor = System.Drawing.Color.White;
            this.btn_Cancel.Location = new System.Drawing.Point(224, 121);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(44, 25);
            this.btn_Cancel.TabIndex = 42;
            this.btn_Cancel.Text = "取消";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // btn_OK
            // 
            this.btn_OK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_OK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_OK.ForeColor = System.Drawing.Color.White;
            this.btn_OK.Location = new System.Drawing.Point(224, 90);
            this.btn_OK.Name = "btn_OK";
            this.btn_OK.Size = new System.Drawing.Size(44, 25);
            this.btn_OK.TabIndex = 41;
            this.btn_OK.Text = "确定";
            this.btn_OK.UseVisualStyleBackColor = true;
            this.btn_OK.Click += new System.EventHandler(this.btn_OK_Click);
            // 
            // RGB_Channnels
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(291, 178);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_OK);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.mT_CB);
            this.Controls.Add(this.mT_CG);
            this.Controls.Add(this.mT_CR);
            this.Controls.Add(this.tb_CG);
            this.Controls.Add(this.tb_CR);
            this.Controls.Add(this.tb_CB);
            this.Name = "RGB_Channnels";
            this.Text = "RGB_Channnels";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.RGB_Channnels_FormClosing);
            ((System.ComponentModel.ISupportInitialize)(this.tb_CG)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_CR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tb_CB)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_CB;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_CG;
        private MaterialSkin.Controls.MaterialSingleLineTextField mT_CR;
        private System.Windows.Forms.TrackBar tb_CG;
        private System.Windows.Forms.TrackBar tb_CR;
        private System.Windows.Forms.TrackBar tb_CB;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Button btn_OK;
    }
}