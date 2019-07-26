using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.Document;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface ISelectedPhotoRepository
    {
        string CheckSelectedPhotosYearFolderIsCreatedReturnsPath(int year);
        string CreateSelectedPhotosYearFolder(int year);
        string CheckSelectedPhotosMonthFolderIsCreatedReturnsPath(int month);
        string CreateSelectedPhotosMonthFolder(int month, int year);
        //List<View_GetSelectedPhotosFoldersInfo> CheckOrderPrintFolderIsExitsReturnFullData(string orderPrintCode);
        string CreateOrderPrintDirectory(string orderCode, int month);
        CreateFileViewModel CreateFileTableFileReturnCreateFileViewModel(string name, string parent, byte level, string localFilePath);
        void DeleteSelectedPhotosFolderFiles(string pathLocator);
    }
}
