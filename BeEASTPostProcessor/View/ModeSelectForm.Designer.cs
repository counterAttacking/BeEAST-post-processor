namespace BeEASTPostProcessor.View
{
    partial class ModeSelectForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ModeSelectForm));
            this.pnlMain = new MetroFramework.Controls.MetroPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdoLevel2 = new System.Windows.Forms.RadioButton();
            this.rdoLevel1 = new System.Windows.Forms.RadioButton();
            this.btnCancel = new MetroFramework.Controls.MetroButton();
            this.btnOk = new MetroFramework.Controls.MetroButton();
            this.pnlMain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.btnCancel);
            this.pnlMain.Controls.Add(this.btnOk);
            this.pnlMain.Controls.Add(this.groupBox1);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.HorizontalScrollbarBarColor = true;
            this.pnlMain.HorizontalScrollbarHighlightOnWheel = false;
            this.pnlMain.HorizontalScrollbarSize = 10;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(284, 156);
            this.pnlMain.TabIndex = 0;
            this.pnlMain.VerticalScrollbarBarColor = true;
            this.pnlMain.VerticalScrollbarHighlightOnWheel = false;
            this.pnlMain.VerticalScrollbarSize = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.White;
            this.groupBox1.Controls.Add(this.rdoLevel2);
            this.groupBox1.Controls.Add(this.rdoLevel1);
            this.groupBox1.ForeColor = System.Drawing.Color.Black;
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(260, 59);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // rdoLevel2
            // 
            this.rdoLevel2.AutoSize = true;
            this.rdoLevel2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLevel2.Location = new System.Drawing.Point(144, 20);
            this.rdoLevel2.Name = "rdoLevel2";
            this.rdoLevel2.Size = new System.Drawing.Size(77, 25);
            this.rdoLevel2.TabIndex = 2;
            this.rdoLevel2.TabStop = true;
            this.rdoLevel2.Text = "Level 2";
            this.rdoLevel2.UseVisualStyleBackColor = true;
            // 
            // rdoLevel1
            // 
            this.rdoLevel1.AutoSize = true;
            this.rdoLevel1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.rdoLevel1.Location = new System.Drawing.Point(6, 20);
            this.rdoLevel1.Name = "rdoLevel1";
            this.rdoLevel1.Size = new System.Drawing.Size(77, 25);
            this.rdoLevel1.TabIndex = 1;
            this.rdoLevel1.TabStop = true;
            this.rdoLevel1.Text = "Level 1";
            this.rdoLevel1.UseVisualStyleBackColor = true;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnCancel.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnCancel.Location = new System.Drawing.Point(159, 96);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(74, 43);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseSelectable = true;
            this.btnCancel.Click += new System.EventHandler(this.BtnCancel_Click);
            // 
            // btnOk
            // 
            this.btnOk.FontSize = MetroFramework.MetroButtonSize.Tall;
            this.btnOk.FontWeight = MetroFramework.MetroButtonWeight.Regular;
            this.btnOk.Location = new System.Drawing.Point(36, 96);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(74, 43);
            this.btnOk.TabIndex = 1;
            this.btnOk.Text = "OK";
            this.btnOk.UseSelectable = true;
            this.btnOk.Click += new System.EventHandler(this.BtnOK_Click);
            // 
            // ModeSelectForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(284, 156);
            this.Controls.Add(this.pnlMain);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ModeSelectForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Select Mode";
            this.pnlMain.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroPanel pnlMain;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdoLevel2;
        private System.Windows.Forms.RadioButton rdoLevel1;
        private MetroFramework.Controls.MetroButton btnCancel;
        private MetroFramework.Controls.MetroButton btnOk;
    }
}