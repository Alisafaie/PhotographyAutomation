using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Diagnostics;
using System.Linq;

namespace PhotographyAutomation.DateLayer.Services
{
    public class BookingRepository : IBookingRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public BookingRepository(PhotographyAutomationDBEntities contex)
        {
            _db = contex;
        }

        public List<BookingHistoryAddEditBookingViewModel> GetCustomerBookingHistory(int customerId)
        {
            try
            {
                return
                    _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.CustomerId == customerId)
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            CustomerId = x.CustomerId,
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerGender = x.TblCustomer.Gender,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            PaymentIsOk = x.PrepaymentIsOk,
                            PersonCount = x.PersonCount,
                            PhotographerGender = x.PhotographerGender,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            StatusId = x.StatusId,
                            StatusName = x.TblBookingStatus.StatusName,
                            //Submitter = 
                            //SubmitterName = 
                            //PhotographerGenderName = 
                            ModifiedDateTime = x.ModifiedDate
                        })
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Time)
                    .ToList();
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.Date >= dtFrom && x.Date <= dtTo && x.TblBookingStatus.Code == statusCode &&
                                (x.TblCustomer.FirstName.Contains(customerInfo) ||
                                 x.TblCustomer.LastName.Contains(customerInfo) ||
                                 x.TblCustomer.Tell.Contains(customerInfo) ||
                                 x.TblCustomer.Mobile.Contains(customerInfo)))
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            CustomerId = x.CustomerId,
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerGender = x.TblCustomer.Gender,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            PaymentIsOk = x.PrepaymentIsOk,
                            PersonCount = x.PersonCount,
                            PhotographerGender = x.PhotographerGender,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            StatusId = x.StatusId,
                            StatusName = x.TblBookingStatus.StatusName,
                            //Submitter = 
                            //SubmitterName = 
                            //PhotographerGenderName = 
                            ModifiedDateTime = x.ModifiedDate
                        })
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Time)
                    .ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        //public BindingList<TblBooking> LoadBindingList()
        //{
        //    _db.TblBooking.Load();
        //    return _db.TblBooking.Local.ToBindingList();
        //}

        public List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, string customerInfo)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.Date >= dtFrom && x.Date <= dtTo &&
                                (x.TblCustomer.FirstName.Contains(customerInfo) ||
                                 x.TblCustomer.LastName.Contains(customerInfo) ||
                                 x.TblCustomer.Tell.Contains(customerInfo) ||
                                 x.TblCustomer.Mobile.Contains(customerInfo)))
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            CustomerId = x.CustomerId,
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerGender = x.TblCustomer.Gender,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            PaymentIsOk = x.PrepaymentIsOk,
                            PersonCount = x.PersonCount,
                            PhotographerGender = x.PhotographerGender,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            StatusId = x.StatusId,
                            StatusName = x.TblBookingStatus.StatusName,
                            //Submitter = 
                            //SubmitterName = 
                            //PhotographerGenderName = 
                            ModifiedDateTime = x.ModifiedDate
                        })
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Time)
                    .ToList();


                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public List<BookingHistoryAddEditBookingViewModel> GetBookingOfCustomer(int customerId)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.CustomerId == customerId)
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            CustomerId = x.CustomerId,
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerGender = x.TblCustomer.Gender,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            PaymentIsOk = x.PrepaymentIsOk,
                            PersonCount = x.PersonCount,
                            PhotographerGender = x.PhotographerGender,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            StatusId = x.StatusId,
                            StatusName = x.TblBookingStatus.StatusName,
                            //Submitter = 
                            //SubmitterName = 
                            //PhotographerGenderName = 
                            ModifiedDateTime = x.ModifiedDate
                        })
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Time)
                    .ToList();

                return returnValue;
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public List<BookingHistoryAddEditBookingViewModel> GetBookingOfCustomer(string customerInfo)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.TblCustomer.FirstName.Contains(customerInfo) ||
                                x.TblCustomer.LastName.Contains(customerInfo) ||
                                x.TblCustomer.Tell.Contains(customerInfo) ||
                                x.TblCustomer.Mobile.Contains(customerInfo))
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            CustomerId = x.CustomerId,
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerGender = x.TblCustomer.Gender,
                            CustomerFullName = x.TblCustomer.FirstName + " " + x.TblCustomer.LastName,
                            PaymentIsOk = x.PrepaymentIsOk,
                            PersonCount = x.PersonCount,
                            PhotographerGender = x.PhotographerGender,
                            PhotographyTypeId = x.PhotographyTypeId,
                            PhotographyTypeName = x.TblPhotographyType.TypeName,
                            StatusId = x.StatusId,
                            StatusName = x.TblBookingStatus.StatusName,
                            //Submitter = 
                            //SubmitterName = 
                            //PhotographerGenderName = 
                            ModifiedDateTime = x.ModifiedDate
                        })
                    .OrderByDescending(x => x.Date)
                    .ThenByDescending(x => x.Time)
                    .ToList();


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
