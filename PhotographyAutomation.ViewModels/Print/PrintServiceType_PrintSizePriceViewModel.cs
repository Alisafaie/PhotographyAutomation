namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintServiceType_PrintSizePriceViewModel
    {
        public int? Id { get; set; }
        public int? PrintServiceId { get; set; }
        public int? PrintSizePriceId { get; set; }
        public string Code { get; set; }
        public int? Price { get; set; }
        public string Description { get; set; }
        public string PrintServiceName { get; set; }
        public string PrintSizeName { get; set; }
        public decimal PrintSizeWidth { get; set; }
        public decimal PrintSizeHeight { get; set; }
        public int OriginalPrintPrice { get; set; }
        public int SecondPrintPrice { get; set; }
    }
}
