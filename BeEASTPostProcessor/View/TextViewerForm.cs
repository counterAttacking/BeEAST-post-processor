using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace BeEASTPostProcessor.View
{
    public partial class TextViewerForm : DockContent
    {
        private string filePath;

        public TextViewerForm(string filePath)
        {
            InitializeComponent();

            this.filePath = filePath;
        }

        public void Print()
        {
            var str = File.ReadAllText(this.filePath);
            this.txtFileContent.Text = str;
        }
    }
}
