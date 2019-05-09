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
    public class PhotoRepository : IPhotoRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public PhotoRepository(PhotographyAutomationDBEntities context)
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
                return result?.FullUncPath;
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

        public string CheckCustomerOrderFolderIsCreatedReturnsFullUncPath(string orderCode)
        {
            try
            {
                var result = _db.View_GetDocumentsFolders.Where(
                    x => x.FolderName == orderCode).ToList();
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

        public List<View_GetDocumentsFolders> CheckCustomerOrderFolderIsCreatedReturnsFullData(string orderCode)
        {
            try
            {
                List<View_GetDocumentsFolders> result = _db.View_GetDocumentsFolders.Where(
                    x => x.FolderName == orderCode).ToList();
                return result.Count > 0 ? result : null;
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


        public string CheckCustomerOrderFolderIsCreatedReturnsPathStreamId(string orderCode)
        {
            try
            {
                var result = _db.View_GetDocumentsFolders.Where(
                    x => x.FolderName == orderCode).ToList();
                return result.Count > 0 ? result[0].StreamId.ToString() : null;
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
            ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
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
            ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                string strMonth = month.ToString("##");
                string strYear = year.ToString("####");

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

        public string CreateCustomerFinancialFolder(string orderCode, int month)
        {
            ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                string strMonth = month.ToString();

                var result = _db.usp_CreateCustomerFinancialDirectory(orderCode, strMonth, 3, returnValue)
                                .ToList();

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

                    using (var fs = new SqlFileStream(info.path_name, info.filestreamTxn, FileAccess.Write, FileOptions.WriteThrough, 0L))
                    {
                        using (var local = new FileStream(localFilePath, FileMode.Open, FileAccess.Read))
                        {
                            local.CopyTo(fs);
                        }
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

        public CreateFileViewModel CreateFileTableFileReturnCreateFileViewModel(string name, string parent, byte level, string localFilePath)
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
                    Debug.WriteLine(exception.Message);
                    Debug.WriteLine(exception.Data);
                    Debug.WriteLine(exception.InnerException);
                    Debug.WriteLine(exception.Source);
                    Debug.WriteLine(exception.StackTrace);
                    return null;
                }
            }
        }

        public Guid GetOrderFolderStreamId(string orderCode)
        {
            ObjectParameter returnValue = new ObjectParameter("returnValue", typeof(string));
            try
            {
                var result = _db.usp_GetOrderFolderStreamId(orderCode, returnValue).ToList();

                if (result.Count > 0)
                {
                    return new Guid(result[0]);
                }
                return Guid.Empty;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return Guid.Empty;
            }
        }

        public void DeleteFilesOfOrder(string pathLocator)
        {
            try
            {
                _db.usp_DeleteOrderFolderFiles(pathLocator);
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
            }
        }

        public int GetTotalFilesOfFolder(string pathLocator)
        {
            var returnValue = new ObjectParameter("returnValue", typeof(int));
            try
            {
                int result = _db.usp_GetTotalFilesOfFolder(pathLocator, returnValue);
                if (result > 0)
                    return result;
                return -1;
            }
            catch (Exception exception)
            {
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return -1;
            }
        }

        public List<FilesInFolderViewModel> GetListOfFilesInFolder(string pathLocator)
        {
            List<FilesInFolderViewModel> listOfFiles = null;
            
            try
            {
                var result = _db.usp_GetListOfFilesInFolder(pathLocator).ToList();
                if (result.Any())
                {
                   listOfFiles = new List<FilesInFolderViewModel>(result.Count);
                    foreach (var item in result)
                    {
                        var file = new FilesInFolderViewModel
                        {
                            FileName = item.FileName, StreamId = item.StreamId, FileSize = item.FileSize
                        };
                        listOfFiles.Add(file);
                    }
                }

                return listOfFiles;
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
    }
}