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
                        IsDeleted = x.IsDeleted
                    })
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
                                .Where(x => x.PrintSizeId == printSizeId)
                                .Select(x =>
                                    new PrintServicesViewModel
                                    {
                                        Id = x.Id,
                                        PrintSizeId = x.PrintSizeId,
                                        PrintServicePrice = x.Price,
                                        PrintServiceCode = x.TblPrintServices.Code,
                                        PrintServiceName = x.TblPrintServices.PrintServiceName,
                                        PrintServiceDescription = x.TblPrintServices.PrintServiceDescription,
                                    })
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
