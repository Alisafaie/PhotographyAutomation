using System;
using System.IO;
using System.Net.Http.Headers;

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
        /// <param name="newFolderName">نام فولدر جدیدی که می خواهیم ایجاد شود.</param>
        /// <returns>NewFolder DirectoryInfo</returns>
        public DirectoryInfo CreateFolder(string path, string newFolderName)
        {
            try
            {
                if (Directory.Exists(path))
                {
                    string newFolderFullPath = Path.Combine(path, newFolderName);
                    if (Directory.Exists(newFolderFullPath) == false)
                    {
                        var info = Directory.CreateDirectory(newFolderFullPath);
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


        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public bool IsFolderExists(string folderPath)
        {
            try
            {
                return Directory.Exists(folderPath);
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public bool IsFolderHasFiles(string folderPath)
        {
            try
            {
                if (Directory.Exists(folderPath))
                {
                    string[] files = Directory.GetFiles(folderPath);
                    if (files.Length > 0)
                        return true;
                    return false;
                }
                throw new IOException();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }




        /// <summary>
        /// 
        /// </summary>
        /// <param name="folderPath"></param>
        /// <returns></returns>
        public bool DeleteFilesInFolder(string folderPath)
        {
            int counter = 0;
            try
            {
                if (Directory.Exists(folderPath))
                {
                    Retry:
                    string[] files = Directory.GetFiles(folderPath);
                    if (files.Length > 0)
                    {
                        foreach (var file in files)
                        {
                            File.Delete(file);
                        }
                    }

                    string[] filesAfterDelete = Directory.GetFiles(folderPath);
                    if (filesAfterDelete.Length == 0)
                    {
                        return true;
                    }

                    if(counter<10)
                    {
                        counter++;
                        goto Retry;
                    }
                    return false;
                }

                throw  new IOException();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception);
                throw;
            }
        }
    }
}
