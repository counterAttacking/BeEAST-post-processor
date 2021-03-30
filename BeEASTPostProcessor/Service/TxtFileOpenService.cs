using BeEASTPostProcessor.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BeEASTPostProcessor.Service
{
    public class TxtFileOpenService
    {
        private List<TxtFile> files;

        private TxtFileOpenService()
        {
            this.files = new List<TxtFile>();
        }

        private static readonly Lazy<TxtFileOpenService> openService = new Lazy<TxtFileOpenService>(() => new TxtFileOpenService());

        public static TxtFileOpenService GetOpenService
        {
            get
            {
                return openService.Value;
            }
        }

        public object GetFiles()
        {
            if (this.files == null || this.files.Count == 0)
            {
                return null;
            }
            else
            {
                return this.files.ToArray().Clone();
            }
        }

        public void OpenFiles(string[] inputFiles)
        {
            try
            {
                for (var i = 0; i < inputFiles.Length; i++)
                {
                    var fileAttribute = File.GetAttributes(inputFiles[i]);
                    if ((fileAttribute & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        this.CheckDirectory(inputFiles[i]);
                    }
                    else
                    {
                        var file = this.DivideFilePath(inputFiles[i]);
                        this.files.Add(file);
                    }
                }
            }
            catch (Exception ex)
            {
                var logWrite = new LogFileWriteService(ex);
                logWrite.MakeLogFile();
            }
        }

        private TxtFile DivideFilePath(string filePath)
        {
            var file = new TxtFile
            {
                name = Path.GetFileName(filePath),
                path = Path.GetDirectoryName(filePath),
                fullPath = filePath,
            };
            return file;
        }

        public void DeleteFiles()
        {
            if (MessageBox.Show("Are you sure you want to delete?", "Notice", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            this.files = new List<TxtFile>();
        }

        private void CheckDirectory(string path)
        {
            var directories = Directory.GetDirectories(path);
            var files = Directory.GetFiles(path);
            foreach (var file in files)
            {
                var txtFile = this.DivideFilePath(file);
                this.files.Add(txtFile);
            }
            if (directories.Length > 0)
            {
                foreach (var directory in directories)
                {
                    this.CheckDirectory(directory);
                }
            }
        }
    }
}
