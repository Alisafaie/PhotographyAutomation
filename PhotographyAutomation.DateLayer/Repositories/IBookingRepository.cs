using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IBookingRepository
    {
        List<BookingHistoryAddEditBookingViewModel> GetCustomerBookingHistory(int customerId);
        List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode);
        List<BookingHistoryAddEditBookingViewModel> GetBookingOfCustomer(int customerId);
    }
}
