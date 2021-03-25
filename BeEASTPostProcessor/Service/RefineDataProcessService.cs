using BeEASTPostProcessor.Manager;
using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Service
{
    public class RefineDataProcessService
    {
        private SectionData[] sections;
        private RefineData[] refines;
        private string[] deathBinary;

        public RefineDataProcessService(string[] deathBinary)
        {
            this.deathBinary = deathBinary;
            this.sections = SectionDataManager.GetSectionDataManager.sections;
            this.refines = new RefineData[this.sections.Length];
        }

        public void RefineProcess()
        {
            this.InitializeRefines();
            this.CombineRawData();
            var refineManager = RefineDataManager.GetDataManager;
            refineManager.refines = this.refines;
        }

        private void InitializeRefines()
        {
            var refineLength = this.refines.Length;
            var deathLength = this.deathBinary.Length;

            for (var i = 0; i < refineLength; i++)
            {
                this.refines[i] = new RefineData()
                {
                    name = this.sections[i].name,
                    deathBinary = this.deathBinary,
                    ccdp = new double[deathLength],
                    cdf = new double[deathLength],
                };
            }
        }

        private void CombineRawData()
        {
            var refineLength = this.refines.Length;
            var deathLength = this.deathBinary.Length;

            for (var i = 0; i < refineLength; i++)
            {
                for (var j = 0; j < deathLength; j++)
                {
                    var deathStr = this.refines[i].deathBinary[j];
                    var msLength = this.sections[i].ms.Length;
                    for (var k = 0; k < msLength; k++)
                    {
                        var rawLength = this.sections[i].ms[k].raws.Length;
                        for (var l = 0; l < rawLength; l++)
                        {
                            if (deathStr.Equals(this.sections[i].ms[k].raws[l].deathBinary))
                            {
                                this.refines[i].ccdp[j] += this.sections[i].ms[k].raws[l].ccdp;
                                this.refines[i].cdf[j] += this.sections[i].ms[k].raws[l].cdf;
                            }
                        }
                    }
                }
            }
        }
    }
}
