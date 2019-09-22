using System.Collections.Generic;

namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintSizesViewModel
    {
        public int Id { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public string Name { get; set; }

        public bool HasMedicalPhoto { get; set; }
        public bool HasLitPrint { get; set; }
        public bool HasScanAndProcessing { get; set; }
        public bool HasAlbum { get; set; }
        public bool HasItalianAlbum { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int MinimumOrder { get; set; }
        public string Descriptions { get; set; }

        public int? FirstPrintPrice { get; set; }
        public int? RePrintPrice { get; set; }
        public int? MedicalPrice { get; set; }
        public int? MedicalRePrintPrice { get; set; }
        public int? LitPrintPrice { get; set; }
        public int? LitPrintRePrintPrice { get; set; }
        public int? ScanAndPrintPrice { get; set; }
        public int? ScanAndProcessingPrice { get; set; }

        public int? ItalianAlbumPagePrice { get; set; }
        public int? ItalianAlbumBoundingPrice { get; set; }

        public int PrintServiceId { get; set; }
        public string PrintServiceName { get; set; }
        public string PrintServiceCode { get; set; }
        public int PrintServicePrice { get; set; }
        public string PrintServicePriceCode { get; set; }


        public List<PrintServicesViewModel> PrintServicesViewModels { get; set; }
    }
}
