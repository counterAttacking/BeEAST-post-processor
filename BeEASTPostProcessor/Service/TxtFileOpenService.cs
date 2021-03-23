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
        private TxtFile[] files;

        private TxtFileOpenService()
        {

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
            if (this.files == null || this.files.Length == 0)
            {
                return null;
            }
            else
            {
                return this.files.Clone();
            }
        }

        public void OpenFiles(string[] inputFiles)
        {
            var files = new List<TxtFile>();
            try
            {
                /*
                 * 기존에 불러온 파일이 존재한다면
                 * 기존에 존재하던 파일에
                 * 추가적으로 불러올 파일도 같이 저장하기 위하여
                 */
                if (this.files != null && this.files.Length > 0)
                {
                    files = this.files.ToList();
                }

                for (var i = 0; i < inputFiles.Length; i++)
                {
                    var file = this.DivideFilePath(inputFiles[i]);
                    files.Add(file);
                }
            }
            catch (Exception ex)
            {
                var logWrite = new LogFileWriteService(ex);
                logWrite.MakeLogFile();
            }
            finally
            {
                this.files = files.ToArray();
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

            this.files = null;
        }
    }
}
