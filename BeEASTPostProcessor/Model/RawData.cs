using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Model
{
    public class RawData
    {
        public string plusMinus
        {
            set;
            get;
        }

        public double ccdp
        {
            set;
            get;
        }

        public double cdf
        {
            set;
            get;
        }

        public int deathDecimal
        {
            set;
            get;
        }

        public string deathBinary
        {
            set;
            get;
        }
    }
}
