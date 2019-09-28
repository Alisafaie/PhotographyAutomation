using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.Business.OrderDetails
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public int OrderPrintId { get; set; }
        public Guid StreamId { get; set; }
        public int CustomerId { get; set; }
        public string FileName { get; set; }
        public bool IsFirstprint { get; set; }
        public bool HasPrintService { get; set; }
        public bool HasMultiPhoto { get; set; }
        public bool HasLitPrint { get; set; }
        public bool HasChangingElemts { get; set; }
        public int PrintSizeId { get; set; }
        public int PrintSizePriceId { get; set; }
        public int PrintServiceId { get; set; }
        public int PrintServicePriceId { get; set; }
        public int PrintSpecialServiceId { get; set; }

    }
}
