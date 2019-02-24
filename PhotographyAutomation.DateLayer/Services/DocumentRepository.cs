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
    public class DocumentRepository : IDocumentRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public DocumentRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }

        //[EdmFunction("DbModel.Store","DocumentViewByGUID")]
        public DocumentInfoViewModel GetPhotoByGuid(Guid documentGuid)
        {
            //try
            //{
            //    var returnResult = _db.(documentGuid).SingleOrDefault();
            //    if (returnResult == null) return null;
            //    var vm = new DocumentInfoViewModel
            //    {
            //        FileName = returnResult.NAME,
            //        FileStream = returnResult.file_stream,
            //        IsDirectory = returnResult.is_directory,
            //        StreamId = returnResult.stream_id,
            //        UncPath = returnResult.unc_path
            //    };
            //    return vm;
            //}
            //catch (Exception exception)
            //{
            //    Debug.WriteLine(exception.Message);
            //    Debug.WriteLine(exception.Data);
            //    Debug.WriteLine(exception.InnerException);
            //    Debug.WriteLine(exception.Source);
            //    Debug.WriteLine(exception.StackTrace);
            //    return null;
            //}
            throw new NotImplementedException();
        }

        public List<DocumentInfoViewModel> GetDocuments()
        {
            throw new NotImplementedException();
        }

        public string CheckPhotoYearFolderIsCreatedReturnsPath(int year)
        {
            try
            {
                var result = _db.View_GetDocumentsFolders.FirstOrDefault(x => x.FolderName == year.ToString());
                if (result != null)
                    return result.FullUncPath;
                return null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public string CheckPhotoMonthFolderIsCreatedReturnsPath(int month)
        {
            try
            {
                var result = _db.View_GetDocumentsFolders.Where(x => x.FolderName == month.ToString()).ToList();
                return result.Count > 0 ? result[0].FullUncPath : null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public string CheckCustomerFinancialFolderIsCreatedReturnsPath(int financialNumber)
        {
            try
            {
                var result = _db.View_GetDocumentsFolders.Where(
                    x => x.FolderName == financialNumber.ToString()).ToList();
                return result.Count > 0 ? result[0].FullUncPath : null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public string CreateYearFolderOfPhotos(int year)
        {
            try
            {

                ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
                var result = _db.usp_CreateYearFolder(year.ToString("####"), "Root", 1, returnValue).ToList();

                if (result.Count > 0)
                {
                    return result[0];
                }

                return null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public string CreateMonthFolderOfPhotos(int month, int year)
        {
            try
            {
                string strMonth = month.ToString("##");
                string strYear = year.ToString("####");

                ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
                var result = _db.usp_CreateMonthFolder(strMonth, strYear, 2, returnValue).ToList();

                if (result.Count > 0)
                {
                    return result[0];
                }

                return null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public string CreateCustomerFinancialFolder(int finacialNumber, int month)
        {
            try
            {
                string strMonth = month.ToString("##");


                ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
                var result = _db
                    .usp_CreateCustomerFinancialDirectory(finacialNumber.ToString(), strMonth, 3, returnValue).ToList();

                if (result.Count > 0)
                {
                    return result[0];
                }

                return null;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public bool CreateFileTableFile(string name, string parent, byte level, string localFilePath)
        {
            using (DbContextTransaction dbTransaction = _db.Database.BeginTransaction())
            {
                try
                {
                    var result = _db.usp_CreateFileTableFile(name, parent, level).ToList();


                    var info = new CreateFileViewModel
                    {
                        name = result[0].name,
                        streamId = result[0].streamId,
                        path_locator_str = result[0].path_locator_str,
                        parent_locator = result[0].parent_locator,
                        path_name = result[0].path_name,
                        filestreamTxn = result[0].filestreamTxn
                    };

                    using (SqlFileStream fs = new SqlFileStream(info.path_name, info.filestreamTxn, FileAccess.Write, FileOptions.WriteThrough, 0L))
                    using (FileStream local = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                    {
                        local.CopyTo(fs);
                    }


                    dbTransaction.Commit();
                    return true;
                }
                catch (Exception exception)
                {
                    dbTransaction.Rollback();
                    Debug.WriteLine(exception.Message);
                    Debug.WriteLine(exception.Data);
                    Debug.WriteLine(exception.InnerException);
                    Debug.WriteLine(exception.Source);
                    Debug.WriteLine(exception.StackTrace);
                    return false;
                }
            }
        }
    }
}