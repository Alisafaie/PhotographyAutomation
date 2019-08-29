namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintSizePricesViewModel
    {
        public int Id { get; set; }
        public int PrintSizeId { get; set; }
        public string SizeName { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public int? FirstPrintPrice { get; set; }
        public int? RePrintPrice { get; set; }
        public int? MedicalPrice { get; set; }
        public int? MedicalRePrintPrice { get; set; }
        public int? LitPrintPrice { get; set; }
        public int? LitPrintReprintPrice { get; set; }
        public int? ScanAndPrintPrice { get; set; }
        public int? ScanAndProcessingPrice { get; set; }

        public int? ItalianAlbumPagePrice { get; set; }
        public int? ItalianAlbumPageBoundingPrice { get; set; }
        public string SizeDescription { get; set; }
    }
}
