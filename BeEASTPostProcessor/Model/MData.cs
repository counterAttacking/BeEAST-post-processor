using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Model
{
    public class MData
    {
        public string name
        {
            set;
            get;
        }

        public RawData[] raws
        {
            set;
            get;
        }
    }
}
