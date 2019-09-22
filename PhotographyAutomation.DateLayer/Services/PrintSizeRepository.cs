using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace PhotographyAutomation.DateLayer.Services
{
    public class PrintSizeRepository : IPrintSizeRepository
    {
        private readonly PhotographyAutomationDBEntities _db;
        public PrintSizeRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }
        public List<PrintSizesViewModel> GetAllPrintSizes()
        {
            try
            {
                var result = _db.TblPrintSizes
                    //.Include(x=>x.TblPrintSizes)
                    .Select(x => new PrintSizesViewModel
                    {
                        Id = x.Id,
                        Width = x.Width,
                        Height = x.Height,
                        Name = x.Name,
                        MinimumOrder = x.MinimumOrder,
                        Descriptions = x.Descriptions,
                        HasAlbum = x.HasAlbum,
                        HasScanAndProcessing = x.HasScanAndProcessing,
                        HasLitPrint = x.HasLitPrint,
                        HasItalianAlbum = x.HasItalianAlbum,
                        HasMedicalPhoto = x.HasMedicalPhoto,
                        IsActive = x.IsActive,
                        IsDeleted = x.IsDeleted,
                        //FirstPrintPrice = x.FirstPrintPrice,
                        //RePrintPrice = x.RePrintPrice,
                        //LitPrintPrice = x.LitPrintPrice,
                        //LitPrintRePrintPrice = x.LitPrintRePrintPrice,
                        //MedicalPrice = x.MedicalPrice,
                        //MedicalRePrintPrice = x.MedicalRePrintPrice,
                        //ItalianAlbumPagePrice = x.ItalianAlbumPagePrice,
                        //ItalianAlbumBoundingPrice = x.ItalianAlbumBoundingPrice,
                        //ScanAndPrintPrice = x.ScanAndPrintPrice,
                        //ScanAndProcessingPrice = x.ScanAndProcessingPrice
                    })
                    .AsNoTracking()
                    .OrderBy(x => x.Width)
                    .ThenBy(x => x.Height)
                    .ToList();
                return result;

            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                throw;
            }
        }

        public List<PrintServicesViewModel> GetAllPrintSizeServicesByPrintSizeId(int printSizeId)
        {
            try
            {
                var result = _db.TblPrintServicePrices
                                .Include(x => x.TblPrintServices)
                                .Include(x=>x.TblPrintSizes)
                                .Where(x => x.PrintSizeId == printSizeId)
                                .Select(x =>
                                    new PrintServicesViewModel
                                    {
                                        Id = x.Id,
                                        PrintSizeId = x.PrintSizeId,
                                        PrintServiceId = x.PrintServiceId,
                                        PrintServicePrice = x.Price,
                                        PrintServiceCode = x.TblPrintServices.Code,
                                        PrintServiceName = x.TblPrintServices.PrintServiceName,
                                        PrintServiceDescription = x.TblPrintServices.PrintServiceDescription,
                                        SizeWidth = x.TblPrintSizes.Width,
                                        SizeHeight = x.TblPrintSizes.Height,
                                        SizeName = x.TblPrintSizes.Name,
                                        SizeDescription = x.TblPrintSizes.Descriptions
                                    })
                                .AsNoTracking()
                                .ToList();

                return result;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                throw;
            }
        }


        public void WriteDebugInfoToOutput(Exception exception)
        {
            Debug.WriteLine("Message: ");
            Debug.WriteLine(exception.Message);

            Debug.WriteLine("Inner Exception: ");
            Debug.WriteLine(exception.InnerException);

            Debug.WriteLine("Inner Exception Message:");
            Debug.WriteLine(exception.InnerException?.Message);

            Debug.WriteLine("Source: ");
            Debug.WriteLine(exception.Source);

            Debug.WriteLine("Data: ");
            Debug.WriteLine(exception.Data);

            Debug.WriteLine("Stack Trace: ");
            Debug.WriteLine(exception.StackTrace);
        }
    }
}
