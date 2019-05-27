using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.Document;
using PhotographyAutomation.ViewModels.Photo;
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
        string CheckCustomerOrderFolderIsCreatedReturnsFullUncPath(string orderCode);
        string CheckCustomerOrderFolderIsCreatedReturnsPathStreamId(string orderCode);
        List<View_GetDocumentsFolders> CheckCustomerOrderFolderIsCreatedReturnsFullData(string orderCode);
        string CreateYearFolderOfPhotos(int year);
        string CreateMonthFolderOfPhotos(int month, int year);
        string CreateCustomerFinancialFolder(string orderCode, int month);
        bool CreateFileTableFile(string name, string parent, byte level, string localFilePath);
        CreateFileViewModel CreateFileTableFileReturnCreateFileViewModel(string name, string parent, byte level, string localFilePath);
        Guid GetOrderFolderStreamId(string orderCode);
        void DeleteFilesOfOrder(string pathLocator);
        int GetTotalFilesOfFolder(string pathLocator);
        List<PhotoViewModel> GetListOfFilesInFolder(string pathLocator);
    }
}
