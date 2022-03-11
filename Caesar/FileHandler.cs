using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Caesar
{
    public class FileHandler
    {
        private string _workingDirectory;

        public FileHandler(string workingDirectory)
        {
            _workingDirectory = workingDirectory;
        }

        public List<FileInfo> ReadAllTextFiles()
        {
            List<FileInfo> files = new List<FileInfo>();
            try
            {
                if (Directory.Exists(_workingDirectory))
                {
                    string[] filePaths = Directory.GetFiles(_workingDirectory, "*.txt");
                    for (int i = 0; i < filePaths.Length; i++)
                    {
                        files.Add(
                            new FileInfo(filePaths[i]));
                    }
                }
                return files;
            }
            catch (Exception)
            {
                return files;
            }
        }
    
        public bool WriteContentToFile(string path, string content)
        {
            try
            {
                File.WriteAllText(path, content);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
