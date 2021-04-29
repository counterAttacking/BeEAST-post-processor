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
    public class TxtFileReadService
    {
        private TxtFile file;
        private static readonly string fileOutStr = "FILE OUT";
        private static readonly string truthStr = "TRUTH TABLE CCDP CDF";
        private static readonly string equalStr = "=";
        private int idx;
        private string[] earthquakeSection;

        public TxtFileReadService(TxtFile file, int idx)
        {
            this.file = file;
            this.idx = idx;
            this.SetEarthquakeSection();
        }

        public void Read()
        {
            var isFoundFileOut = false;
            var isFoundTruth = false;
            string sectionName = null;
            string mName = null;
            var raws = new List<RawData>();
            var ms = new List<MData>();
            var section = new SectionData();

            using (var fileStream = new FileStream(this.file.fullPath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, false))
                {
                    while (!streamReader.EndOfStream)
                    {
                        var readLine = streamReader.ReadLine();
                        if (readLine.Contains(fileOutStr))
                        {
                            isFoundFileOut = true;
                            sectionName = this.SetSectionName(readLine);
                            mName = readLine;
                        }
                        if (readLine.Equals(truthStr))
                        {
                            isFoundTruth = true;
                            continue;
                        }
                        if (isFoundFileOut == true && isFoundTruth == true)
                        {
                            var str = readLine.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);

                            if (!str[0].Equals(equalStr))
                            {
                                var rawData = new RawData
                                {
                                    plusMinus = str[0],
                                    ccdp = Convert.ToDouble(str[1]),
                                    cdf = Convert.ToDouble(str[2]),
                                    deathDecimal = Convert.ToInt32(str[3]),
                                    deathBinary = str[4],
                                };
                                raws.Add(rawData);
                                DeathBinaryManager.GetDeathBinaryManager.tmpDeathBinary.Add(str[4]);
                            }
                            else
                            {
                                var mData = new MData
                                {
                                    name = mName,
                                    raws = raws.ToArray(),
                                };
                                ms.Add(mData);

                                isFoundFileOut = false;
                                isFoundTruth = false;
                                raws.Clear();
                            }
                        }
                    }
                }
            }

            section.name = sectionName;
            section.ms = ms.ToArray();

            var sectionManager = SectionDataManager.GetSectionDataManager;
            sectionManager.sections[this.idx] = section;
        }

        private string SetSectionName(string input)
        {
            string name = null;
            for (var i = 0; i < this.earthquakeSection.Length; i++)
            {
                if (input.Contains(this.earthquakeSection[i]))
                {
                    name = this.earthquakeSection[i];
                }
            }

            return name;
        }

        private void SetEarthquakeSection()
        {
            var sections = new List<string>
            {
                "S015",
                "S025",
                "S035",
                "S045",
                "S055",
                "S065",
                "S075",
                "S085",
                "S095"
            };

            this.earthquakeSection = sections.ToArray();
        }
    }
}
