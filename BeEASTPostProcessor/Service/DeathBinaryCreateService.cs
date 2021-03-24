using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeEASTPostProcessor.Service
{
    public class DeathBinaryCreateService
    {
        private string[] deathBinary;

        public DeathBinaryCreateService()
        {

        }

        public void Generate()
        {
            var str = new List<string>();
            for (var i = 1; i < 512; i++)
            {
                str.Add(Convert.ToString(i, 2));
            }
            for (var i = 0; i < str.Count(); i++)
            {
                var zeroCnt = 9 - str[i].Length;
                var tmp = new StringBuilder();
                tmp.Append("@@UX_0");
                for (var j = 0; j < zeroCnt; j++)
                {
                    tmp.Append("0");
                }
                tmp.Append(str[i]);
                str[i] = tmp.ToString();
            }

            this.deathBinary = str.ToArray();
        }

        public Object GetDeathBinary()
        {
            if (this.deathBinary == null || this.deathBinary.Length <= 0)
            {
                return null;
            }
            else
            {
                return this.deathBinary.Clone();
            }
        }
    }
}
