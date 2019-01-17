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
                            Time = x.Time,
                            CreatedDateTime = x.CreatedDate,
                            ModifiedDateTime = x.ModifiedDate.Value,
                            AtelierTypeId = x.AtelierTypeId,
                            AtelierTypeName = x.TblAtelierType.AtelierName,
                            CustomerFirstName = x.TblCustomer.FirstName,
                            CustomerLastName = x.TblCustomer.LastName,
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
    }
}
