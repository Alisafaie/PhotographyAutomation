namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintServicesViewModel
    {
        public int Id { get; set; }
        public int PrintSizeId { get; set; }
        public int PrintServiceId { get; set; }
        public double SizeWidth { get; set; }
        public double SizeHeight { get; set; }
        public string SizeName { get; set; }
        public string SizeDescription { get; set; }

        public int PrintServicePrice { get; set; }
        public string PrintServiceCode { get; set; }
        public string PrintServiceName { get; set; }
        public string PrintServiceDescription { get; set; }
    }
}
