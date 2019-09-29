using System;

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
        public int RePrintSequence { get; set; }
        public int PrintSizeId { get; set; }
        public int PrintSizePriceId { get; set; }
        public int PrintServiceId { get; set; }
        public int PrintServicePriceId { get; set; }
        public int PrintSpecialServiceId { get; set; }
        public bool HasRePrintPrintService { get; set; }
        public bool HasRePrintMultiPhoto { get; set; }
        public bool HasRePrintLitPrint { get; set; }
        public bool HasRePrintChangingElements { get; set; }
        public int RePrintPrintSizeId { get; set; }
        public int RePrintPrintSizePriceId { get; set; }
        public int RePrintPrintServiceId { get; set; }
        public int RePrintPrintServicePriceId { get; set; }
        public int RePrintPrintSpecialServiceId { get; set; }
        public int RePrintTotalPrints { get; set; }
        public int RePrintTotalPrintServices { get; set; }
        //public int TotalPricePrint { get; set; }
        //public int TotalPriceMultiPhoto { get; set; }
        //public int TotalPriceLitPrint { get; set; }
        //public int TotalPricePrintService { get; set; }
        //public int TotalPriceOriginalPrint { get; set; }
        //public int TotalPriceRePrint { get; set; }
        //public int TotalPriceRePrintMultiPhoto { get; set; }
        //public int TotalPriceRePrintLitPrint { get; set; }
        public int TotalPrice { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime ModifiedDateTime { get; set; }
        public string RetouchDescription { get; set; }

        public bool IsAccepted { get; set; }
    }
}
