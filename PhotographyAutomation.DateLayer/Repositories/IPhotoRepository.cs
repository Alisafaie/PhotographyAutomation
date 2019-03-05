using PhotographyAutomation.ViewModels.Document;
using System;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPhotoRepository
    {
        DocumentInfoViewModel GetPhotoByGuid(Guid documentGuid);
        List<DocumentInfoViewModel> GetDocuments();
        string CheckPhotoYearFolderIsCreatedReturnsPath(int year);
        string CheckPhotoMonthFolderIsCreatedReturnsPath(int month);
        string CheckCustomerFinancialFolderIsCreatedReturnsPath(int financialNumber);
        string CreateYearFolderOfPhotos(int year);
        string CreateMonthFolderOfPhotos(int month, int year);
        string CreateCustomerFinancialFolder(int finacialNumber, int month);
        bool CreateFileTableFile(string name, string parent, byte level,string localFilePath);
    }
}
