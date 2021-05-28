using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeEASTPostProcessor.View
{
    public partial class ModeSelectForm : Form
    {
        public bool isCheckedLevel1;
        public bool isCheckedLevel2;
        public bool isClicked;

        public ModeSelectForm()
        {
            InitializeComponent();

            this.isCheckedLevel1 = true;
            this.isCheckedLevel2 = false;
            this.isClicked = false;
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            this.ExtractValues();
            this.isClicked = true;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.isClicked = false;
            this.Close();
        }

        private void ExtractValues()
        {
            this.isCheckedLevel1 = this.rdoLevel1.Checked;
            this.isCheckedLevel2 = this.rdoLevel2.Checked;
        }
    }
}
