using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PhotographyAutomation.DateLayer.Models;

namespace PhotographyAutomation.DateLayer.Repositories
{
    public interface IPrintServiceRepository
    {
        List<View_GetAllPrintSizeAndServicesInfo> GetAllPrintSizeAndServicesInfo();
    }
}
