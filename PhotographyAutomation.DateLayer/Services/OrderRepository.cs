using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.DateLayer.Services
{
    public class OrderRepository : IOrderRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public OrderRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }

        public List<CustomerOrderViewModel> GetOrdersOfCustomer(string customerInfo)
        {
            try
            {
                var returnValue = _db.TblOrder.Include(x => x.TblCustomer).Include(x => x.TblPhotographyType).Where(x =>
                    x.TblCustomer.FirstName.Contains(customerInfo) ||
                    x.TblCustomer.LastName.Contains(customerInfo) ||
                    x.TblCustomer.Tell.Contains(customerInfo) ||
                    x.TblCustomer.Mobile.Contains(customerInfo)).Select(x => new CustomerOrderViewModel
                    {
                        Id = x.Id,
                        CustomerId = x.CustomerId,
                        BookingId = x.BookingId,
                        PhotographyTypeId = x.PhotographyTypeId,
                        CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                        OrderCode = x.OrderCode.ToString(),
                        OrderStatusId = x.OrderStatusId,
                        CreatedDateTime = x.CreatedDateTime,
                        ModifiedDateTime = x.ModifiedDateTime,
                        PhotographerId = x.PhotographerId.Value,
                        PhotographyTypeName = x.TblPhotographyType.TypeName,
                        TotalFiles = x.TotalFiles.Value,
                        PaymentIsOk = x.PaymentIsOk.Value,
                        IsActive = x.IsActive,
                        OrderFolderStreamId = x.OrdefFolderStreamId.Value,
                        OrderFolderPathLocator = x.OrdefFolderPathLocator,
                        OrderFolderParentPathLocator = x.OrdefFolderParentPathLocator

                    }).OrderByDescending(x => x.Id).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                Debug.WriteLine("Message");
                Debug.WriteLine(exception.Message);

                Debug.WriteLine("Inner Exception");
                Debug.WriteLine(exception.InnerException);

                Debug.WriteLine("Inner Exception Message:");
                Debug.WriteLine(exception.InnerException?.Message);

                Debug.WriteLine("Source");
                Debug.WriteLine(exception.Source);

                Debug.WriteLine("Data");
                Debug.WriteLine(exception.Data);

                Debug.WriteLine("Stack Trace");
                Debug.WriteLine(exception.StackTrace);

                return null;
            }
        }
    }
}
