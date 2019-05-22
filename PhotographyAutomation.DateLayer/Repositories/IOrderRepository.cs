using PhotographyAutomation.ViewModels.Order;
using System;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IOrderRepository
    {
        List<CustomerOrderViewModel> GetAllOrders();
        List<CustomerOrderViewModel> GetOrdersOfCustomerByOrderCode(string orderCode);
        List<CustomerOrderViewModel> GetOrdersOfCustomer(string customerInfo);
        List<CustomerOrderViewModel> GetOrdersByStatusCode(int statusCode);
        List<CustomerOrderViewModel> GetOrdersByStatusCode(int statusCode, DateTime statusDate);
        List<CustomerOrderViewModel> GetOrdersByOrderDate(DateTime dtOrderDate);
        List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, int statusCode, string customerInfo);
        List<CustomerOrderViewModel> GetOrdersBetweenDates(DateTime dtFrom, DateTime dtTo, string customerInfo);
    }
}
