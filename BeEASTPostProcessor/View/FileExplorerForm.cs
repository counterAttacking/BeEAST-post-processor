using BeEASTPostProcessor.Model;
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
    public partial class FileExplorerForm : DockContent
    {
        private TxtFileOpenService openService;

        public FileExplorerForm()
        {
            InitializeComponent();

            this.openService = TxtFileOpenService.GetOpenService;
        }

        private void FileExplorerForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            e.Cancel = true;
        }

        public void OpenFiles(object inputFiles)
        {
            this.tvwFiles.Nodes.Clear();

            var files = (TxtFile[])inputFiles;
            var stringBuilder = new StringBuilder();
            stringBuilder.Append("txt files (");
            stringBuilder.Append(files.Length.ToString());
            stringBuilder.Append(")");

            var fileNode = new TreeNode(stringBuilder.ToString());
            for (var i = 0; i < files.Length; i++)
            {
                fileNode.Nodes.Add(files[i].path, files[i].name);
            }
            this.tvwFiles.Nodes.Add(fileNode);
        }

        public void DeleteAllFiles()
        {
            this.tvwFiles.Nodes.Clear();
        }

        private void TvwFiles_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void TvwFiles_DragDrop(object sender, DragEventArgs e)
        {
            var files = (string[])e.Data.GetData(DataFormats.FileDrop);
            Array.Sort(files);
            this.openService.OpenFiles(files);
            this.OpenFiles(this.openService.GetFiles());
        }
    }
}
