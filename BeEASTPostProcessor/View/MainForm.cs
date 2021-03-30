using BeEASTPostProcessor.Manager;
using BeEASTPostProcessor.Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace BeEASTPostProcessor.View
{
    public partial class MainForm : Form
    {
        private FileExplorerForm frmFileExplorer;
        private StatusOutputForm frmStatus;
        private RefineDataManager refineDataManager;

        public MainForm()
        {
            InitializeComponent();

            this.frmFileExplorer = new FileExplorerForm(this);
            this.frmStatus = StatusOutputForm.GetFrmStatus;
            this.refineDataManager = RefineDataManager.GetDataManager;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.frmFileExplorer.Show(this.dockPnlMain, DockState.DockLeft);
            this.frmStatus.Show(this.dockPnlMain, DockState.DockBottom);

            this.dockPnlMain.UpdateDockWindowZOrder(DockStyle.Left, true);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
        }

        private void MsiOpen_Click(object sender, EventArgs e)
        {
            var ofd = new OpenFileDialog
            {
                Filter = "TXT File (*.txt)|*.txt",
                Multiselect = true,
            };
            if (ofd.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }

            var openService = TxtFileOpenService.GetOpenService;
            openService.OpenFiles(ofd.FileNames);

            this.frmFileExplorer.OpenFiles(openService.GetFiles());
        }

        private void MsiDeleteAllFiles_Click(object sender, EventArgs e)
        {
            var openService = TxtFileOpenService.GetOpenService;
            openService.DeleteFiles();

            this.frmFileExplorer.DeleteAllFiles();
        }

        private void MsiShowInputFileList_Click(object sender, EventArgs e)
        {
            this.frmFileExplorer.Show(this.dockPnlMain, DockState.DockLeft);
        }

        private void MsiShowStatus_Click(object sender, EventArgs e)
        {
            this.frmStatus.Show(this.dockPnlMain, DockState.DockBottom);
        }

        private void MsiShowResult_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.refineDataManager.GetRefineData() == null)
                {
                    return;
                }
                var frmResult = new ResultForm()
                {
                    TabText = "Result",
                };
                frmResult.Show(this.dockPnlMain, DockState.Document);
                frmResult.PrintResult();
            }
            catch (Exception ex)
            {
                var logWrite = new LogFileWriteService(ex);
                logWrite.MakeLogFile();
            }
        }

        private async void MsiRun_Click(object sender, EventArgs e)
        {
            try
            {
                var str = new StringBuilder();
                str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                str.AppendLine("Running is started");
                this.frmStatus.Msg = str.ToString();

                var manager = new ExtractManager();
                await manager.Run();

                str.Clear();
                str.Append(DateTime.Now.ToString("[yyyy-MM-dd-HH:mm:ss]   "));
                str.AppendLine("Running is completed");
                this.frmStatus.Msg = str.ToString();
            }
            catch (Exception ex)
            {
                var logWrite = new LogFileWriteService(ex);
                logWrite.MakeLogFile();
            }

            try
            {
                if (this.refineDataManager.GetRefineData() == null)
                {
                    return;
                }
                var frmResult = new ResultForm()
                {
                    TabText = "Result",
                };
                frmResult.Show(this.dockPnlMain, DockState.Document);
                frmResult.PrintResult();
            }
            catch (Exception ex)
            {
                var logWrite = new LogFileWriteService(ex);
                logWrite.MakeLogFile();
            }
        }

        public void ShowSelectedFile(string selectedFile)
        {
            var frmTextViewer = new TextViewerForm(selectedFile);
            frmTextViewer.Show(this.dockPnlMain, DockState.Document);
            frmTextViewer.Print();
        }
    }
}
