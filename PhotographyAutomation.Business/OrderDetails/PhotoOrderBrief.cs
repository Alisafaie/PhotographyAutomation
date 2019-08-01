namespace PhotographyAutomation.Business.OrderDetails
{
    public class PhotoOrderBrief
    {
        public int OrderId { get; set; }
        public int OrderPrintId { get; set; }
        public int TotalSelectedPhotos { get; set; }
        public int TotalServicePrints { get; set; }
        public string OrderPrintDescriptions { get; set; }
        public string OrderPrintServiceBrief { get; set; }
    }
}