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
                            UserId = x.CustomerId,
                            Time = x.Time.Hours.ToString() + ":" + x.Time.Minutes.ToString(),
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
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }



        public List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.Date >= dtFrom && x.Date <= dtTo && x.TblBookingStatus.Code == statusCode)
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            UserId = x.CustomerId,
                            Time = x.Time.Hours.ToString() + ":" + x.Time.Minutes.ToString(),
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
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }

        public List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo)
        {
            try
            {
                var returnValue = _db.TblBooking
                    .Include(x => x.TblCustomer)
                    .Include(x => x.TblAtelierType)
                    .Include(x => x.TblBookingStatus)
                    .Include(x => x.TblPhotographyType)
                    .Where(x => x.Date >= dtFrom && x.Date <= dtTo)
                    .Select(
                        x => new BookingHistoryAddEditBookingViewModel
                        {
                            Id = x.Id,
                            Date = x.Date,
                            UserId = x.CustomerId,
                            Time = x.Time.Hours.ToString() + ":" + x.Time.Minutes.ToString(),
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
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
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
                            UserId = x.CustomerId,
                            Time = x.Time.Hours.ToString() + ":" + x.Time.Minutes.ToString(),
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
                Debug.WriteLine(exception.Message);
                Debug.WriteLine(exception.Data);
                Debug.WriteLine(exception.InnerException);
                Debug.WriteLine(exception.Source);
                Debug.WriteLine(exception.StackTrace);
                return null;
            }
        }
    }
}
