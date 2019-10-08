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
    }
}
