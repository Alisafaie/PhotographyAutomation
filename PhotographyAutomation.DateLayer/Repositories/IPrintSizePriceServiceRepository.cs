using System.Collections.Generic;
using PhotographyAutomation.ViewModels.Print;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPrintSizePriceServiceRepository
    {
        List<PrintServiceType_PrintSizePriceViewModel> GetAllPrintSizePriceServices();
    }
}
