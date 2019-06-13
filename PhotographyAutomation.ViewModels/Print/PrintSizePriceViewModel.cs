using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintSizePriceViewModel
    {
        public int Id { get; set; }
        public string SizeName { get; set; }
        public decimal SizeWidth { get; set; }
        public decimal SizeHeight { get; set; }
        public int OriginalPrintPrice { get; set; }
        public int SecontPrintPrice { get; set; }
        public string SizeDescription { get; set; }
    }
}
