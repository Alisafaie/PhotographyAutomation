using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Document;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects.DataClasses;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        public DocumentInfoViewModel GetDocumentByGuid(Guid documentGuid)
        {

            try
            {
                var returnResult = _db.DocumentViewByGUID(documentGuid).SingleOrDefault();
                if (returnResult == null) return null;
                var vm = new DocumentInfoViewModel
                {
                    FileName = returnResult.NAME,
                    FileStream = returnResult.file_stream,
                    IsDirectory = returnResult.is_directory,
                    StreamId = returnResult.stream_id,
                    UncPath = returnResult.unc_path
                };
                return vm;
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

        public List<DocumentInfoViewModel> GetDocuments()
        {
            throw new NotImplementedException();
        }
    }
}
