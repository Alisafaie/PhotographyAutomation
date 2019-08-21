using PhotographyAutomation.ViewModels.Print;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPrintSizePriceRepository
    {
        List<PrintSizePricesViewModel> GetAllPrintSizePrices();
    }
}
