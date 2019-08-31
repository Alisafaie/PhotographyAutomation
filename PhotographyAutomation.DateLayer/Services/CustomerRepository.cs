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
        public TblCustomer FindCustomersByMobile(string mobileNumber)
        {
            try
            {
                return _db.TblCustomer.SingleOrDefault(x => x.Mobile.Contains(mobileNumber));
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
                return null;
            }
        }

        public TblCustomer GetCustomerByMobile(string mobileNumber)
        {
            try
            {
                return _db.TblCustomer.SingleOrDefault(x => x.Mobile.Equals(mobileNumber));
            }
            catch (Exception exception)
            {
                WriteDebugInfoToOutput(exception);
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
