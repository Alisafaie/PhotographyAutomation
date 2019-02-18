using System;
using System.Collections.Generic;
using PhotographyAutomation.ViewModels.Document;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IDocumentRepository
    {
        DocumentInfoViewModel GetPhotoByGuid(Guid documentGuid);
        List<DocumentInfoViewModel> GetDocuments();
        string CheckPhotoYearFolderIsCreatedReturnsPath(int year);
        string CheckPhotoMonthFolderIsCreatedReturnsPath(int month);
        string CheckCustomerFinancialFolderIsCreatedReturnsPath(int financialNumber);
        string CreateYearFolderOfPhotos(int year);
        string CreateMonthFolderOfPhotos(int month,int year);
        string CreateCustomerFinancialFolder(int finacialNumber,int month);
    }
}
