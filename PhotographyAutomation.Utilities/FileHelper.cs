using System;
using System.IO;

namespace PhotographyAutomation.Utilities
{
    /// <summary>
    /// کلاس حاوی متدهایی برای کار با فایل ها
    /// </summary>
    public class FileHelper
    {
        public string GetFileNameWithExtension(string fileNameAndPath)
        {
            try
            {
                if (File.Exists(fileNameAndPath))
                {
                    return Path.GetFileName(fileNameAndPath);
                }
                else
                {
                    throw new IOException();
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        public bool DeleteFiles(string[] files)
        {
            if (files.Length > 0)
            {
                FileInfo fileInfo = new FileInfo(files[0]);
                string parentFolderPath = string.Empty;
                if (fileInfo.Directory != null)
                {
                    parentFolderPath = fileInfo.Directory.FullName;
                }

                foreach (var file in files)
                {
                    if (File.Exists(file))
                    {
                        File.Delete(file);
                    }
                }

                if (Directory.Exists(parentFolderPath))
                {
                    string[] filesAfterDelete = Directory.GetFiles(parentFolderPath);
                    if (filesAfterDelete.Length == 0)
                        return true;
                    return false;
                }
            }
            throw new IOException("فولدر مورد نظر وجود ندارد.");
        }
    }
}
