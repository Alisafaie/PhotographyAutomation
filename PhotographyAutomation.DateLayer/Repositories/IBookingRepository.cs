using System.Collections.Generic;
using PhotographyAutomation.ViewModels.User;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IBookingRepository
    {
        List<BookingHistoryAddEditBookingViewModel> GetCustomerBookingHistory(int customerId);
    }
}
