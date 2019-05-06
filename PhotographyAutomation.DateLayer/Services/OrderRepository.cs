using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.Order;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

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
                    x.TblCustomer.Mobile.Contains(customerInfo))
                    .Select(x => new CustomerOrderViewModel
                    {
                        Id = x.Id,
                        CreatedDateTime = x.CreatedDateTime,
                        BookingId = x.BookingId,
                        BookingDate = x.TblBooking.Date,
                        BookingTime = x.TblBooking.Time,
                        CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                        CustomerId = x.CustomerId,
                        CustomerGender = x.TblCustomer.Gender.Value,
                        OrderCode = x.OrderCode.ToString(),
                        ModifiedDateTime = x.ModifiedDateTime.Value,
                        TotalFiles = x.TotalFiles.Value,
                        PhotographyTypeId = x.PhotographyTypeId,
                        PhotographyTypeName = x.TblPhotographyType.TypeName,
                        OrderStatusId = x.OrderStatusId,
                        OrderStatusCode=x.TblOrderStatus.Code,
                        OrderStatusName = x.TblOrderStatus.Name,
                        IsActive = x.IsActive,
                        OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                        OrderFolderPathLocator = x.OrderFolderPathLocator,
                        OrderFolderStreamId = x.OrderFolderStreamId.Value,
                        PaymentIsOk = x.PaymentIsOk.Value,
                        PhotographerId = x.PhotographerId.Value,
                        PersonCount = x.TblBooking.PersonCount,
                        PhotographerGender = x.TblBooking.PhotographerGender,
                        Submitter = x.Submitter.Value
                    })
                    .OrderByDescending(x => x.Id).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }


        public List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            try
            {
                var returnValue = _db.TblOrder
                    .Include(x => x.TblOrderStatus)
                    .Include(x => x.TblBooking)
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAllOrderStatus)
                    .Include(x => x.TblOrderFiles)
                    .Include(x => x.TblOrderPrint)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.CreatedDateTime >= dtFrom && x.CreatedDateTime <= dtTo &&
                                x.TblOrderStatus.Code == statusCode &&
                                (x.TblCustomer.FirstName.Contains(customerInfo) ||
                                 x.TblCustomer.LastName.Contains(customerInfo) ||
                                 x.TblCustomer.Tell.Contains(customerInfo) ||
                                 x.TblCustomer.Mobile.Contains(customerInfo)))
                    .Select(x => new CustomerOrderViewModel
                    {
                        Id = x.Id,
                        CreatedDateTime = x.CreatedDateTime,
                        BookingId = x.BookingId,
                        BookingDate = x.TblBooking.Date,
                        BookingTime = x.TblBooking.Time,
                        CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                        CustomerId = x.CustomerId,
                        CustomerGender = x.TblCustomer.Gender.Value,
                        OrderCode = x.OrderCode.ToString(),
                        ModifiedDateTime = x.ModifiedDateTime.Value,
                        TotalFiles = x.TotalFiles.Value,
                        PhotographyTypeId = x.PhotographyTypeId,
                        PhotographyTypeName = x.TblPhotographyType.TypeName,
                        OrderStatusId = x.OrderStatusId,
                        OrderStatusCode=x.TblOrderStatus.Code,
                        OrderStatusName = x.TblOrderStatus.Name,
                        IsActive = x.IsActive,
                        OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                        OrderFolderPathLocator = x.OrderFolderPathLocator,
                        OrderFolderStreamId = x.OrderFolderStreamId.Value,
                        PaymentIsOk = x.PaymentIsOk.Value,
                        PhotographerId = x.PhotographerId.Value,
                        PersonCount = x.TblBooking.PersonCount,
                        PhotographerGender = x.TblBooking.PhotographerGender,
                        Submitter = x.Submitter.Value
                    })
                    .OrderBy(x => x.BookingDate)
                    .ThenBy(x => x.BookingTime)
                    .ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, string customerInfo)
        {
            try
            {
                var returnValue = _db.TblOrder
                    .Include(x => x.TblBooking)
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblOrderStatus)
                    .Include(x => x.TblAllOrderStatus)
                    .Include(x => x.TblOrderFiles)
                    .Include(x => x.TblOrderPrint)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.CreatedDateTime >= dtFrom && x.CreatedDateTime <= dtTo &&
                                (x.TblCustomer.FirstName.Contains(customerInfo) ||
                                 x.TblCustomer.LastName.Contains(customerInfo) ||
                                 x.TblCustomer.Tell.Contains(customerInfo) ||
                                 x.TblCustomer.Mobile.Contains(customerInfo)))
                    .Select(x => new CustomerOrderViewModel
                    {
                        Id = x.Id,
                        CreatedDateTime = x.CreatedDateTime,
                        BookingId = x.BookingId,
                        BookingDate = x.TblBooking.Date,
                        BookingTime = x.TblBooking.Time,
                        CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                        CustomerId = x.CustomerId,
                        CustomerGender = x.TblCustomer.Gender.Value,
                        OrderCode = x.OrderCode.ToString(),
                        ModifiedDateTime = x.ModifiedDateTime,
                        TotalFiles = x.TotalFiles.Value,
                        PhotographyTypeId = x.PhotographyTypeId,
                        PhotographyTypeName = x.TblPhotographyType.TypeName,
                        OrderStatusId = x.OrderStatusId,
                        OrderStatusCode=x.TblOrderStatus.Code,
                        OrderStatusName = x.TblOrderStatus.Name,
                        IsActive = x.IsActive,
                        OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                        OrderFolderPathLocator = x.OrderFolderPathLocator,
                        OrderFolderStreamId = x.OrderFolderStreamId,
                        PaymentIsOk = x.PaymentIsOk,
                        PhotographerId = x.PhotographerId,
                        PersonCount = x.TblBooking.PersonCount,
                        PhotographerGender = x.TblBooking.PhotographerGender,
                        Submitter = x.Submitter
                    })
                    .OrderBy(x => x.BookingDate)
                    .ThenBy(x => x.BookingTime)
                    .ToList();

                return returnValue;
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
