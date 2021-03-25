using BeEASTPostProcessor.Model;
using BeEASTPostProcessor.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeEASTPostProcessor.Manager
{
    public class ExtractManager
    {
        private TxtFileOpenService txtFileOpenService;
        private TxtFileReadService txtFileReadService;
        private SectionDataManager sectionManager;
        private string[] deathBinary;

        public ExtractManager()
        {

        }

        public async Task Run()
        {
            await Task.Run(() =>
            {
                this.txtFileOpenService = TxtFileOpenService.GetOpenService;
                var txtFiles = (TxtFile[])this.txtFileOpenService.GetFiles();
                if (txtFiles == null || txtFiles.Length <= 0)
                {
                    MessageBox.Show("There is no txt file", "Notice", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                this.sectionManager = SectionDataManager.GetSectionDataManager;
                this.sectionManager.sections = new SectionData[txtFiles.Length];

                for (var i = 0; i < txtFiles.Length; i++)
                {
                    this.txtFileReadService = new TxtFileReadService(txtFiles[i], i);
                    this.txtFileReadService.Read();
                }

                var deathBinaryCreateService = new DeathBinaryCreateService();
                deathBinaryCreateService.Generate();
                this.deathBinary = (string[])deathBinaryCreateService.GetDeathBinary();
                if (this.deathBinary == null || this.deathBinary.Length <= 0)
                {
                    return;
                }

                var refineProcessService = new RefineDataProcessService(this.deathBinary);
                refineProcessService.RefineProcess();

                var fileWriteService = new CsvFileWriteService(this.deathBinary);
                fileWriteService.WriteFile();
            });
        }
    }
}
