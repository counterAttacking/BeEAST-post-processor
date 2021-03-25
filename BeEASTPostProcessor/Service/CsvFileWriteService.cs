using BeEASTPostProcessor.Manager;
using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Service
{
    public class CsvFileWriteService
    {
        private RefineData[] refines;
        private string[] deathBinary;

        public CsvFileWriteService(string[] deathBinary)
        {
            this.refines = (RefineData[])RefineDataManager.GetDataManager.GetRefineData();
            this.deathBinary = deathBinary;
        }

        public void WriteFile()
        {
            var refineLength = this.refines.Length;
            var deathLength = this.deathBinary.Length;

            var str = new StringBuilder();
            // 지진 구간 입력 ex) ,S015, ,S025, ,
            str.Append(",");
            for (var i = 0; i < refineLength; i++)
            {
                str.Append(this.refines[i].name);
                str.Append(",");
                str.Append(",");
            }
            str.AppendLine();
            // 각 구간의 CCDP, CDF 입력 ex) ,CCDP,CDF,CCDP,CDF,
            str.Append(",");
            for (var i = 0; i < refineLength; i++)
            {
                str.Append("CCDP,");
                str.Append("CDF,");
            }
            str.AppendLine();

            /* 각 deathBinary 별로 모든 구간의 정보 출력
             * ex) @@UX_0000000001,1.93E-03,9.60E-07,7.25E-02,5.38E-06,
             */
            for (var i = 0; i < deathLength; i++)
            {
                var deathStr = this.deathBinary[i];
                str.Append(deathStr);
                str.Append(",");
                for (var j = 0; j < refineLength; j++)
                {
                    var ccdp = string.Format("{0:0.00E+00}", this.refines[j].ccdp[i]);
                    var cdf = string.Format("{0:0.00E+00}", this.refines[j].cdf[i]);
                    str.Append(ccdp);
                    str.Append(",");
                    str.Append(cdf);
                    str.Append(",");
                }
                str.AppendLine();
            }

            File.WriteAllText("Earthquake Result.csv", str.ToString());
        }
    }
}
