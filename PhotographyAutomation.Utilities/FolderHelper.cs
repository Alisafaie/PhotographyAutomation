using System;
using System.IO;

namespace PhotographyAutomation.Utilities
{
    /// <summary>
    /// کلاس حاوی متدهای لازم برای کار با فولدرها
    /// </summary>
    public class FolderHelper
    {
        /// <summary>
        /// متد دریافت فولدر تمپ کاربر جاری
        /// </summary>
        /// <returns>TempFolder DirectoryInfo</returns>
        public DirectoryInfo GetTempPathOfCurrentUser()
        {
            try
            {
                var dirInfo = new DirectoryInfo(Path.GetTempPath());
                return dirInfo;
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }

        /// <summary>
        /// متد ساخت دایرکتوری در مسیر داده شده
        /// </summary>
        /// <param name="path">مسیری است که می خواهیم فولدر مربوطه در آن ایجاد گردد.</param>
        /// <param name="folderName">نام فولدر جدیدی که می خواهیم ایجاد شود.</param>
        /// <returns>NewFolder DirectoryInfo</returns>
        public DirectoryInfo CreateFolder(string path, string folderName)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string folderFullPath = Path.Combine(path, folderName);
                    if (Directory.Exists(folderFullPath) == false)
                    {
                        var info = Directory.CreateDirectory(folderFullPath);
                        return info;
                    }
                }
                throw new IOException();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
