using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace PhotographyAutomation.DateLayer.Services
{
    public class SelectedPhotoRepository : ISelectedPhotoRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public SelectedPhotoRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }

        private static void WriteDebugInfoToDebugWindows(Exception exception)
        {
            Debug.WriteLine(exception.Message);
            Debug.WriteLine(exception.Data);
            Debug.WriteLine(exception.InnerException);
            Debug.WriteLine(exception.Source);
            Debug.WriteLine(exception.StackTrace);
        }

        //public string CheckSelectedPhotosYearFolderIsCreatedReturnsPath(int year)
        //{
        //    try
        //    {
        //        var result = _db.View_GetSelectedPhotosFoldersInfo.FirstOrDefault(x => x.FolderName == year.ToString());
        //        return result?.FullUncPath;
        //    }
        //    catch (Exception exception)
        //    {
        //        WriteDebugInfoToDebugWindows(exception);
        //        throw;
        //    }
        //}

        public string CreateSelectedPhotosYearFolder(int year)
        {
            var returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                var result = _db.usp_CreateSelectedPhotosYearFolder(year.ToString("####"), "Root", 1, returnValue).ToList();
                return result[0];
            }
            catch (Exception exception)
            {
                WriteDebugInfoToDebugWindows(exception);
                throw;
            }
        }

        //public string CheckSelectedPhotosMonthFolderIsCreatedReturnsPath(int month)
        //{
        //    try
        //    {
        //        var result = _db.View_GetSelectedPhotosFoldersInfo.Where(x => x.FolderName == month.ToString()).ToList();
        //        return result.Any() ? result[0].FullUncPath : null;
        //    }
        //    catch (Exception exception)
        //    {
        //        WriteDebugInfoToDebugWindows(exception);
        //        throw;
        //    }
        //}

        public string CreateSelectedPhotosMonthFolder(int month, int year)
        {
            var returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                var strMonth = month.ToString("##");
                var strYear = year.ToString("####");
                var result = _db.usp_CreateSelectedPhotosMonthFolder(strMonth, strYear, 2, returnValue).ToList();

                return result[0];
            }
            catch (Exception exception)
            {
                WriteDebugInfoToDebugWindows(exception);
                throw;
            }
        }

        //public List<View_GetSelectedPhotosFoldersInfo> CheckOrderPrintFolderIsExitsReturnFullData(string orderPrintCode)
        //{
        //    try
        //    {
        //        var result = _db.View_GetSelectedPhotosFoldersInfo.Where(
        //            x => x.FolderName == orderPrintCode).ToList();
        //        return result.Any() ? result : null;
        //    }
        //    catch (Exception exception)
        //    {
        //        WriteDebugInfoToDebugWindows(exception);
        //        throw;
        //    }
        //}

        public string CreateOrderPrintDirectory(string orderPrintCode, int month)
        {
            var returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                var strMonth = month.ToString();
                var result = _db.usp_CreateOrderPrintDirectory(orderPrintCode, strMonth, 3, returnValue).ToList();

                return result[0];
            }
            catch (Exception exception)
            {
                WriteDebugInfoToDebugWindows(exception);
                throw;
            }
        }

        public CreateFileViewModel CreateFileTableFileReturnCreateFileViewModel(string name, string parent, byte level, string localFilePath)
        {
            using (DbContextTransaction dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var result = _db.usp_CreateSelectedPhotosFileTableFile(name, parent, level).ToList();

                    var info = new CreateFileViewModel
                    {
                        name = result[0].name,
                        streamId = result[0].streamId,
                        path_locator_str = result[0].path_locator_str,
                        parent_locator = result[0].parent_locator,
                        path_name = result[0].path_name,
                        filestreamTxn = result[0].filestreamTxn
                    };

                    using (var fs = new SqlFileStream(info.path_name, info.filestreamTxn, FileAccess.Write, FileOptions.WriteThrough, 0L))
                    {
                        using (var local = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                        {
                            local.CopyTo(fs);
                        }
                    }
                    dbTransaction.Commit();
                    return info;
                }
                catch (Exception exception)
                {
                    dbTransaction.Rollback();
                    WriteDebugInfoToDebugWindows(exception);
                    throw;
                }
            }
        }

        public void DeleteSelectedPhotosFolderFiles(string pathLocator)
        {
            try
            {
                _db.usp_DeleteSelectedPhotosFolderFiles(pathLocator);
            }
            catch (Exception exception)
            {
                WriteDebugInfoToDebugWindows(exception);
                throw;
            }
        }
    }
}