using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.User;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface ICustomerRepository
    {
        TblCustomer FindUserByMobile(string mobileNumber);
        UserInfoBookingViewModel GetCustomerInfoBooking(int userId);
    }
}
