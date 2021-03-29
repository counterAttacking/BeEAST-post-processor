using BeEASTPostProcessor.Manager;
using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace BeEASTPostProcessor.View
{
    public partial class ResultForm : DockContent
    {
        private RefineData[] refines;
        private string[] deathBinary;

        public ResultForm()
        {
            InitializeComponent();

            this.refines = (RefineData[])RefineDataManager.GetDataManager.GetRefineData();
            this.deathBinary = (string[])DeathBinaryManager.GetDeathBinaryManager.GetDeathBinary();
        }

        private void ResultForm_Load(object sender, EventArgs e)
        {
            this.SetColumn();
        }

        private void SetColumn()
        {
            this.dgvResults.Columns.Add("No", "No");
            this.dgvResults.Columns.Add("Combination", "Combination");
            for (var i = 0; i < this.refines.Length; i++)
            {
                this.dgvResults.Columns.Add(this.refines[i].name, this.refines[i].name + "\nCCDP");
                this.dgvResults.Columns.Add(this.refines[i].name, this.refines[i].name + "\nCDF");
            }
            this.dgvResults.Columns.Add("Total", "Total\nCCDP");
            this.dgvResults.Columns.Add("Total", "Total\nCDF");
        }

        public void PrintResult()
        {
            var rowSize = this.deathBinary.Length;
            for (var i = 0; i < rowSize; i++)
            {
                this.dgvResults.Rows.Add();
                var values = new List<string>();
                double ccdpSum = 0.0;
                double cdfSum = 0.0;
                values.Add((i + 1).ToString());
                values.Add(this.deathBinary[i]);
                for (var j = 0; j < this.refines.Length; j++)
                {
                    ccdpSum += this.refines[j].ccdp[i];
                    cdfSum += this.refines[j].cdf[i];
                    values.Add(this.refines[j].ccdp[i].ToString());
                    values.Add(this.refines[j].cdf[i].ToString());
                }
                values.Add(ccdpSum.ToString());
                values.Add(cdfSum.ToString());

                for (var j = 0; j < values.Count; j++)
                {
                    this.dgvResults[j, i].Value = values[j];
                }
            }
        }
    }
}
