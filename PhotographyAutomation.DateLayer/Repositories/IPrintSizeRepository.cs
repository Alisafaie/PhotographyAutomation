using PhotographyAutomation.ViewModels.Print;
using System.Collections.Generic;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPrintSizeRepository
    {
        List<PrintSizesViewModel> GetAllPrintSizes();
        List<PrintServicesViewModel> GetAllPrintSizeServices(int printSizeId);
    }
}
