using PhotographyAutomation.ViewModels.Order;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IOrderRepository
    {
        List<CustomerOrderViewModel> GetOrdersOfCustomer(string customerInfo);
    }
}
