using BeEASTPostProcessor.Model;
using BeEASTPostProcessor.Service;
using BeEASTPostProcessor.View;
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
        private StatusOutputForm frmStatus;
        private DeathBinaryManager deathBinaryManager;

        public ExtractManager()
        {
            this.frmStatus = StatusOutputForm.GetFrmStatus;
            this.deathBinaryManager = DeathBinaryManager.GetDeathBinaryManager;
        }

        public async Task Run()
        {
            await Task.Run(() =>
            {
                try
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

                    var str = new StringBuilder();
                    for (var i = 0; i < txtFiles.Length; i++)
                    {
                        this.txtFileReadService = new TxtFileReadService(txtFiles[i], i);
                        this.txtFileReadService.Read();
                        str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                        str.Append("Completed Read ");
                        str.AppendLine(txtFiles[i].fullPath);
                        this.frmStatus.Msg = str.ToString();
                        str.Clear();
                    }

                    str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                    str.AppendLine("Data Process is started");
                    this.frmStatus.Msg = str.ToString();
                    str.Clear();

                    var deathBinaryCreateService = new DeathBinaryCreateService();
                    deathBinaryCreateService.Generate();
                    this.deathBinary = (string[])deathBinaryCreateService.GetDeathBinary();
                    if (this.deathBinary == null || this.deathBinary.Length <= 0)
                    {
                        return;
                    }

                    this.deathBinaryManager.SetDeathBinary(this.deathBinary.Clone());

                    var refineProcessService = new RefineDataProcessService(this.deathBinary);
                    refineProcessService.RefineProcess();

                    str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                    str.AppendLine("Data Process is completed");
                    this.frmStatus.Msg = str.ToString();
                    str.Clear();

                    var fileWriteService = new CsvFileWriteService(this.deathBinary);
                    var isFinished = fileWriteService.WriteFile();

                    if (isFinished)
                    {
                        str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                        str.AppendLine("Earthquake Result.csv is created");
                        this.frmStatus.Msg = str.ToString();
                    }
                }
                catch (Exception ex)
                {
                    var logWrite = new LogFileWriteService(ex);
                    logWrite.MakeLogFile();
                }
            });
        }
    }
}
