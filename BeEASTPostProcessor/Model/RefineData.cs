using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Model
{
    public class RefineData
    {
        public string name
        {
            set;
            get;
        }

        public string[] deathBinary
        {
            set;
            get;
        }

        public double[] ccdp
        {
            set;
            get;
        }

        public double[] cdf
        {
            set;
            get;
        }
    }
}
