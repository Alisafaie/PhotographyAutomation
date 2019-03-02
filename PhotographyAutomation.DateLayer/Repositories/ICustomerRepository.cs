using PhotographyAutomation.DateLayer.Models;
using PhotographyAutomation.ViewModels.User;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface ICustomerRepository
    {
        TblCustomer FindCustomersByMobile(string mobileNumber);
        TblCustomer GetCustomerByMobile(string mobileNumber);
        UserInfoBookingViewModel GetCustomerInfoBooking(int userId);
    }
}
