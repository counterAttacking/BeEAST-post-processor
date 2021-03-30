namespace BeEASTPostProcessor.View
{
    partial class TextViewerForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TextViewerForm));
            this.txtFileContent = new MetroFramework.Controls.MetroTextBox();
            this.SuspendLayout();
            // 
            // txtFileContent
            // 
            this.txtFileContent.BackColor = System.Drawing.Color.White;
            // 
            // 
            // 
            this.txtFileContent.CustomButton.Image = null;
            this.txtFileContent.CustomButton.Location = new System.Drawing.Point(352, 2);
            this.txtFileContent.CustomButton.Name = "";
            this.txtFileContent.CustomButton.Size = new System.Drawing.Size(445, 445);
            this.txtFileContent.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.txtFileContent.CustomButton.TabIndex = 1;
            this.txtFileContent.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.txtFileContent.CustomButton.UseSelectable = true;
            this.txtFileContent.CustomButton.Visible = false;
            this.txtFileContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFileContent.FontSize = MetroFramework.MetroTextBoxSize.Medium;
            this.txtFileContent.ForeColor = System.Drawing.Color.Black;
            this.txtFileContent.Lines = new string[0];
            this.txtFileContent.Location = new System.Drawing.Point(0, 0);
            this.txtFileContent.MaxLength = 32767;
            this.txtFileContent.Multiline = true;
            this.txtFileContent.Name = "txtFileContent";
            this.txtFileContent.PasswordChar = '\0';
            this.txtFileContent.ReadOnly = true;
            this.txtFileContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFileContent.SelectedText = "";
            this.txtFileContent.SelectionLength = 0;
            this.txtFileContent.SelectionStart = 0;
            this.txtFileContent.ShortcutsEnabled = true;
            this.txtFileContent.Size = new System.Drawing.Size(800, 450);
            this.txtFileContent.TabIndex = 0;
            this.txtFileContent.UseSelectable = true;
            this.txtFileContent.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.txtFileContent.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // TextViewerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtFileContent);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TextViewerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroTextBox txtFileContent;
    }
}