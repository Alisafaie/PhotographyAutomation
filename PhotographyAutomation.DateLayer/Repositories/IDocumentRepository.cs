using System;
using System.Collections.Generic;
using PhotographyAutomation.ViewModels.Document;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IDocumentRepository
    {
        DocumentInfoViewModel GetPhotoByGuid(Guid documentGuid);
        List<DocumentInfoViewModel> GetDocuments();
    }
}
