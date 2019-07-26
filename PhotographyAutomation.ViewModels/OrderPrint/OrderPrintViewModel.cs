using System;

namespace PhotographyAutomation.ViewModels.OrderPrint
{
    public class OrderPrintViewModel
    {
        public int OrderPrintId { get; set; }
        public string OrderPrintCode { get; set; }
        public int OrderId { get; set; }
        public string OrderCode { get; set; }
        public DateTime? PhotographyDate { get; set; }
        public int PhotographyTypeId { get; set; }
        public string PhotographyTypeName { get; set; }
        public string PhotographyDateShamsi { get; set; }
        public int OrderPrintStatusId { get; set; }
        public string OrderPrintStatusName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string RetouchDescriptions { get; set; }
        public int? TotalPhotos { get; set; }
        public long? TotalPrice { get; set; }
        public long? Payment { get; set; }
        public long? Deposit { get; set; }
        public long? Remaining { get; set; }
        public bool IsActiveOrderPrint { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
