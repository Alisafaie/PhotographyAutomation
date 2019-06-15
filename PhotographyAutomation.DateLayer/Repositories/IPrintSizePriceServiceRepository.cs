using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.ViewModels.Print;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPrintSizePriceServiceRepository
    {
        List<PrintServiceType_PrintSizePriceViewModel> GetAllPrintSizePriceServices();
    }
}
