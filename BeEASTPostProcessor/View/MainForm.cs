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

        public MainForm()
        {
            InitializeComponent();

            this.frmFileExplorer = new FileExplorerForm();
            this.frmStatus = StatusOutputForm.GetFrmStatus;
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
                Filter = "TXT File (*.txt, *.TXT)|*.txt;*.TXT",
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

        private async void MsiRun_Click(object sender, EventArgs e)
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
    }
}
