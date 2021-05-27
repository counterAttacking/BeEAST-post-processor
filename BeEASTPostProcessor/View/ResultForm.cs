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
            var colSize = this.refines.Length;
            var values = new List<string>();

            for (var i = 0; i < rowSize; i++)
            {
                this.dgvResults.Rows.Add();
                values = new List<string>();
                var ccdpSum = 0.0;
                var cdfSum = 0.0;
                values.Add((i + 1).ToString());
                values.Add(this.deathBinary[i]);
                for (var j = 0; j < colSize; j++)
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

            // 마지막 줄에 각 열들의 총 합을 계산하여 화면에 출력
            values = new List<string>();
            var totCCDP = 0.0;
            var totCDF = 0.0;

            values.Add((rowSize + 1).ToString());
            values.Add("=");
            for (var i = 0; i < colSize; i++)
            {
                var ccdpSum = 0.0;
                var cdfSum = 0.0;
                for (var j = 0; j < rowSize; j++)
                {
                    ccdpSum += this.refines[i].ccdp[j];
                    cdfSum += this.refines[i].cdf[j];
                }
                totCCDP += ccdpSum;
                totCDF += cdfSum;
                values.Add(ccdpSum.ToString());
                values.Add(cdfSum.ToString());
            }
            values.Add(totCCDP.ToString());
            values.Add(totCDF.ToString());

            this.dgvResults.Rows.Add();
            for (var i = 0; i < values.Count; i++)
            {
                this.dgvResults[i, rowSize].Value = values[i];
            }
        }
    }
}
