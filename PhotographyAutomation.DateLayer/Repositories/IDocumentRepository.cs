using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.ViewModels.Document;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IDocumentRepository
    {
        DocumentInfoViewModel GetDocumentByGuid(Guid documentGuid);
        List<DocumentInfoViewModel> GetDocuments();
    }
}
