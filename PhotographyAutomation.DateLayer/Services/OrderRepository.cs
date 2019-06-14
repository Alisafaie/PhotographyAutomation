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

        public List<CustomerOrderViewModel> GetAllOrders()
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblPhotographyType)
                        .Include(x => x.TblOrderStatus)
                        .Select(x => new CustomerOrderViewModel
                        {
                            Id = x.Id,
                            BookingId = x.BookingId,
                            OrderDate = x.Date,
                            OrderTime = x.Time,
                            BookingTime = x.TblBooking.Time,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            CustomerId = x.CustomerId,
                            CustomerGender = x.TblCustomer.Gender.Value,
                            OrderCode = x.OrderCode.ToString(),
                            CreatedDateTime = x.CreatedDateTime,
                            ModifiedDateTime = x.ModifiedDateTime.Value,
                            TotalFiles = x.TotalFiles.Value,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            OrderStatusId = x.OrderStatusId,
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
                        })
                    .OrderByDescending(x => x.OrderDate).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        //Used in ShowUploaded Photos
        public List<CustomerOrderViewModel> GetOrdersOfCustomerByOrderCode(string orderCode)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblPhotographyType)
                        .Include(x => x.TblOrderStatus)
                        .Where(x =>
                            x.OrderCode.Equals(orderCode))
                        .Select(x => new CustomerOrderViewModel
                        {
                            Id = x.Id,
                            BookingId = x.BookingId,
                            OrderDate = x.Date,
                            OrderTime = x.Time,
                            BookingTime = x.TblBooking.Time,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            CustomerId = x.CustomerId,
                            CustomerGender = x.TblCustomer.Gender.Value,
                            OrderCode = x.OrderCode.ToString(),
                            CreatedDateTime = x.CreatedDateTime,
                            ModifiedDateTime = x.ModifiedDateTime.Value,
                            TotalFiles = x.TotalFiles.Value,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            OrderStatusId = x.OrderStatusId,
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
                        })
                    .OrderByDescending(x => x.OrderDate).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }
        public List<CustomerOrderViewModel> GetOrdersOfCustomer(string customerInfo)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblPhotographyType)
                        .Include(x => x.TblOrderStatus)
                        .Where(x =>
                            x.TblCustomer.FirstName.Contains(customerInfo) ||
                            x.TblCustomer.LastName.Contains(customerInfo) ||
                            x.TblCustomer.Tell.Contains(customerInfo) ||
                            x.TblCustomer.Mobile.Contains(customerInfo))
                        .Select(x => new CustomerOrderViewModel
                        {
                            Id = x.Id,
                            BookingId = x.BookingId,
                            OrderDate = x.Date.Value,
                            OrderTime = x.Time,
                            BookingDate = x.TblBooking.Date,
                            BookingTime = x.TblBooking.Time,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            CustomerId = x.CustomerId,
                            CustomerGender = x.TblCustomer.Gender.Value,
                            OrderCode = x.OrderCode.ToString(),
                            CreatedDateTime = x.CreatedDateTime,
                            ModifiedDateTime = x.ModifiedDateTime.Value,
                            TotalFiles = x.TotalFiles.Value,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            OrderStatusId = x.OrderStatusId,
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
                        })
                    .OrderByDescending(x => x.OrderDate).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }
        public List<CustomerOrderViewModel> GetOrdersByStatusCode(int orderStatusId)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblPhotographyType)
                        .Include(x => x.TblOrderStatus)
                        .Where(x => x.OrderStatusId == orderStatusId)
                        .Select(x => new CustomerOrderViewModel
                        {
                            Id = x.Id,
                            BookingId = x.BookingId,
                            OrderDate = x.Date.Value,
                            OrderTime = x.Time,
                            BookingDate = x.TblBooking.Date,
                            BookingTime = x.TblBooking.Time,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            CustomerId = x.CustomerId,
                            CustomerGender = x.TblCustomer.Gender.Value,
                            OrderCode = x.OrderCode.ToString(),
                            CreatedDateTime = x.CreatedDateTime,
                            ModifiedDateTime = x.ModifiedDateTime.Value,
                            TotalFiles = x.TotalFiles.Value,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            OrderStatusId = x.OrderStatusId,
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
                        })
                    .OrderByDescending(x => x.OrderDate).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }
        public List<CustomerOrderViewModel> GetOrdersByStatusCode(int orderStatusId, DateTime orderDate)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblPhotographyType)
                        .Include(x => x.TblOrderStatus)
                        .Where(x =>
                            x.OrderStatusId == orderStatusId &&
                            (x.CreatedDateTime == orderDate || x.ModifiedDateTime == orderDate))
                        .Select(x => new CustomerOrderViewModel
                        {
                            Id = x.Id,
                            BookingId = x.BookingId,
                            OrderDate = x.Date.Value,
                            OrderTime = x.Time,
                            BookingDate = x.TblBooking.Date,
                            BookingTime = x.TblBooking.Time,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            CustomerId = x.CustomerId,
                            CustomerGender = x.TblCustomer.Gender.Value,
                            OrderCode = x.OrderCode.ToString(),
                            CreatedDateTime = x.CreatedDateTime,
                            ModifiedDateTime = x.ModifiedDateTime.Value,
                            TotalFiles = x.TotalFiles.Value,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            OrderStatusId = x.OrderStatusId,
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
                        })
                    .OrderByDescending(x => x.OrderDate).ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public List<CustomerOrderViewModel> GetOrdersByOrderDate(DateTime dtOrderDate)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblOrderStatus)
                        .Include(x => x.TblBooking)
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblAllOrderStatus)
                        .Include(x => x.TblOrderFiles)
                        .Include(x => x.TblOrderPrint)
                        .Include(x => x.TblPhotographyType)
                        .Where(x =>
                            x.Date == dtOrderDate ||
                            x.Date == dtOrderDate)
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
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PhotographerId = x.PhotographerId.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            PhotographerGender = x.TblBooking.PhotographerGender,
                            Submitter = x.Submitter.Value,
                            OrderDate = x.Date.Value,
                            OrderTime = x.Time.Value,
                            UploadDate = x.UploadDate.Value
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


        public List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            try
            {
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblOrderStatus)
                        .Include(x => x.TblBooking)
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblAllOrderStatus)
                        .Include(x => x.TblOrderFiles)
                        .Include(x => x.TblOrderPrint)
                        .Include(x => x.TblPhotographyType)
                        .Where(x =>
                            x.CreatedDateTime >= dtFrom &&
                            x.CreatedDateTime <= dtTo &&
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
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId.Value,
                            PaymentIsOk = x.PaymentIsOk.Value,
                            PhotographerId = x.PhotographerId.Value,
                            PersonCount = x.TblBooking.PersonCount,
                            PhotographerGender = x.TblBooking.PhotographerGender,
                            Submitter = x.Submitter.Value,
                            UploadDate = x.UploadDate.Value
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
                var returnValue =
                    _db.TblOrder
                        .Include(x => x.TblBooking)
                        .Include(x => x.TblCustomer)
                        .Include(x => x.TblOrderStatus)
                        .Include(x => x.TblAllOrderStatus)
                        .Include(x => x.TblOrderFiles)
                        .Include(x => x.TblOrderPrint)
                        .Include(x => x.TblPhotographyType)
                        .Where(x =>
                            x.CreatedDateTime >= dtFrom &&
                            x.CreatedDateTime <= dtTo &&
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
                            OrderStatusCode = x.TblOrderStatus.Code,
                            OrderStatusName = x.TblOrderStatus.Name,
                            IsActive = x.IsActive,
                            OrderFolderParentPathLocator = x.OrderFolderParentPathLocator,
                            OrderFolderPathLocator = x.OrderFolderPathLocator,
                            OrderFolderStreamId = x.OrderFolderStreamId,
                            PaymentIsOk = x.PaymentIsOk,
                            PhotographerId = x.PhotographerId,
                            PersonCount = x.TblBooking.PersonCount,
                            PhotographerGender = x.TblBooking.PhotographerGender,
                            Submitter = x.Submitter,
                            UploadDate = x.UploadDate.Value
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