using System;
using PhotographyAutomation.ViewModels.Order;
using System.Collections.Generic;
using PhotographyAutomation.ViewModels.User;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IOrderRepository
    {
        List<CustomerOrderViewModel> GetOrdersOfCustomer(string customerInfo);
        List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo);
        List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, string customerInfo);
    }
}
