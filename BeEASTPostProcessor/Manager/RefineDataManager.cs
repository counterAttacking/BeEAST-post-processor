using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Manager
{
    public class RefineDataManager
    {
        public RefineData[] refines;

        private RefineDataManager()
        {

        }

        private static readonly Lazy<RefineDataManager> dataManager = new Lazy<RefineDataManager>(() => new RefineDataManager());

        public static RefineDataManager GetDataManager
        {
            get
            {
                return dataManager.Value;
            }
        }

        public Object GetRefineData()
        {
            if (this.refines == null || this.refines.Length < 0)
            {
                return null;
            }
            else
            {
                return this.refines.Clone();
            }
        }
    }
}
