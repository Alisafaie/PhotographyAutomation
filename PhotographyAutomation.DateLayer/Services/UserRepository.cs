using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.DateLayer.Repositories;
using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.DateLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private PhotographyAutomationDBEntities db;

        public UserRepository(PhotographyAutomationDBEntities context)
        {
            db = context;
        }
        public TblUser FindUserByMobile(string mobileNumber)
        {
            try
            {
                return db.TblUser.SingleOrDefault(x => x.Mobile.Contains(mobileNumber));
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
                return null;
            }
        }

        public UserInfoBookingViewModel GetCustomerInfoBooking(int userId)
        {
            try
            {
                var userInfo = db.TblUser.Where(x => x.Id == userId).Select(x => new UserInfoBookingViewModel
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
                Console.WriteLine(exception);
                return null;
            }
        }
    }
}
