using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Diagnostics;
using System.Linq;

namespace PhotographyAutomation.DateLayer.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly PhotographyAutomationDBEntities _db;

        public CustomerRepository(PhotographyAutomationDBEntities context)
        {
            _db = context;
        }
        public TblCustomer FindUserByMobile(string mobileNumber)
        {
            try
            {
                return _db.TblCustomer.SingleOrDefault(x => x.Mobile.Contains(mobileNumber));
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

        public UserInfoBookingViewModel GetCustomerInfoBooking(int userId)
        {
            try
            {
                var userInfo = _db.TblCustomer.Where(x => x.Id == userId).Select(x => new UserInfoBookingViewModel
                {
                    UserId = userId,
                    FirstName = x.FirstName,
                    LastName = x.LastName,
                    Mobile = x.Mobile,
                    Tell = x.Tell
                }).SingleOrDefault();
                return userInfo;
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
