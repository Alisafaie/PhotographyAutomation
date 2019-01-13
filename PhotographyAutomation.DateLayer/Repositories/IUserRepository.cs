using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.User;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IUserRepository
    {
        TblUser FindUserByMobile(string mobileNumber);
        UserInfoBookingViewModel GetCustomerInfoBooking(int userId);
    }
}
