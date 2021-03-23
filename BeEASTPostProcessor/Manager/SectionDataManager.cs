using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Manager
{
    public class SectionDataManager
    {
        public SectionData[] sections;

        private SectionDataManager()
        {

        }

        private static readonly Lazy<SectionDataManager> sectionDataManager = new Lazy<SectionDataManager>(() => new SectionDataManager());

        public static SectionDataManager GetSectionDataManager
        {
            get
            {
                return sectionDataManager.Value;
            }
        }
    }
}
