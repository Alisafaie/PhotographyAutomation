using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Print;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace PhotographyAutomation.DateLayer.Services
{
    public class PrintSizePriceServiceRepository : IPrintSizePriceServiceRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public PrintSizePriceServiceRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }

        public List<PrintServiceType_PrintSizePriceViewModel> GetAllPrintSizePriceServices()
        {
            var list = new List<PrintServiceType_PrintSizePriceViewModel>();
            try
            {
                List<View_PrintSizesPrices> listInDb = _db.View_PrintSizesPrices.ToList();
                foreach (var itemInDb in listInDb)
                {
                    var item = new PrintServiceType_PrintSizePriceViewModel()
                    {
                        Id = itemInDb.Id,
                        PrintServiceId = itemInDb.PrintServiceId,
                        PrintSizePriceId = itemInDb.PrintSizePriceId,
                        Price = itemInDb.Price,
                        PrintServiceName = itemInDb.PrintServiceName,
                        OriginalPrintPrice = itemInDb.OriginalPrintPrice,
                        SecondPrintPrice = itemInDb.SecondPrintPrice,
                        Code = itemInDb.Code,
                        PrintSizeName = itemInDb.SizeWidth.ToString("F1") + "x" + itemInDb.SizeHeight.ToString("F1"),
                        PrintSizeHeight = itemInDb.SizeHeight,
                        PrintSizeWidth = itemInDb.SizeWidth,
                        Description = itemInDb.Description
                    };
                    list.Add(item);
                }

                return list;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
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
