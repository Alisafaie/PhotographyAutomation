using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;

namespace PhotographyAutomation.DateLayer.Services
{
    public class PrintServiceRepository:IPrintServiceRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public PrintServiceRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }
        public List<View_GetAllPrintSizeAndServicesInfo> GetAllPrintSizeAndServicesInfo()
        {
            try
            {
                var result = _db.View_GetAllPrintSizeAndServicesInfo.ToList();
                return result;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                throw;
            }
        }

        private static void WriteDebugInfoToOutput(Exception exception)
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
