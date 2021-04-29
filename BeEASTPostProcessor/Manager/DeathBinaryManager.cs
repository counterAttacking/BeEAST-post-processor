using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Manager
{
    public class DeathBinaryManager
    {
        private string[] deathBinary;
        public List<string> tmpDeathBinary;

        private DeathBinaryManager()
        {
            this.tmpDeathBinary = new List<string>();
        }

        private static readonly Lazy<DeathBinaryManager> deathBinaryManager = new Lazy<DeathBinaryManager>(() => new DeathBinaryManager());

        public static DeathBinaryManager GetDeathBinaryManager
        {
            get
            {
                return deathBinaryManager.Value;
            }
        }

        public void SetDeathBinary(object deathBinary)
        {
            this.deathBinary = (string[])deathBinary;
        }

        public Object GetDeathBinary()
        {
            if (this.deathBinary == null || this.deathBinary.Length < 0)
            {
                return null;
            }
            else
            {
                this.deathBinary = this.tmpDeathBinary.ToArray();
                return this.deathBinary.Clone();
            }
        }

        public void CleanDeathBinary()
        {
            this.tmpDeathBinary = this.tmpDeathBinary.Distinct().ToList();
            this.tmpDeathBinary.Sort();
        }
    }
}
