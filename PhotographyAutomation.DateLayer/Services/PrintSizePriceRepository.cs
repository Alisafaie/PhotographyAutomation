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
    public class PrintSizePriceRepository : IPrintSizePriceRepository
    {
        private readonly PhotographyAutomationDBEntities _db;
        public PrintSizePriceRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }
        
        public List<PrintSizePricesViewModel> GetAllPrintSizePrices()
        {
            try
            {
                var result = _db.TblPrintSizePrices
                    .Include(x => x.TblPrintSizes)
                    .Select(x =>
                                new PrintSizePricesViewModel
                                {
                                    Id = x.Id,
                                    PrintSizeId = x.PrintSizeId,
                                    FirstPrintPrice = x.FirstPrintPrice,
                                    RePrintPrice = x.RePrintPrice,
                                    LitPrintPrice = x.LitPrintPrice,
                                    LitPrintReprintPrice = x.LitPrintRePrintPrice,
                                    MedicalPrice = x.MedicalPrice,
                                    MedicalRePrintPrice = x.MedicalRePrintPrice,
                                    ScanAndPrintPrice = x.ScanAndPrintPrice,
                                    ScanAndProcessingPrice = x.ScanAndProcessingPrice,
                                    Width = x.TblPrintSizes.Width,
                                    Height = x.TblPrintSizes.Height,
                                    SizeName = x.TblPrintSizes.Name,
                                    SizeDescription = x.TblPrintSizes.Descriptions
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
