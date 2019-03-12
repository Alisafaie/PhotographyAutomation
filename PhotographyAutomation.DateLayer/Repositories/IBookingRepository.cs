using PhotographyAutomation.ViewModels.User;
using System;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IBookingRepository
    {
        List<BookingHistoryAddEditBookingViewModel> GetCustomerBookingHistory(int customerId);
        List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo);
        List<BookingHistoryAddEditBookingViewModel> GetBookingBetweenDates(DateTime dtFrom, DateTime dtTo, string customerInfo);
        List<BookingHistoryAddEditBookingViewModel> GetBookingOfCustomer(int customerId);
        List<BookingHistoryAddEditBookingViewModel> GetBookingOfCustomer(string customerInfo);
        //BindingList<TblBooking> LoadBindingList();
    }
}
