using System.Collections.Generic;

namespace PhotographyAutomation.ViewModels.Print
{
    public class PrintSizesViewModel
    {
        public int Id { get; set; }
        public string Width { get; set; }
        public string Heiight { get; set; }
        public string Name { get; set; }
        public bool HasFirstPrint { get; set; }
        public bool HasRePrint { get; set; }
        public bool HasMedicalPhoto { get; set; }
        public bool HasLitPrint { get; set; }
        public bool HasScanAndPrint { get; set; }
        public bool HasScanAndProcessing { get; set; }
        public bool HasAlbum { get; set; }
        public bool HasItalianAlbum { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public int MinimumOrder { get; set; }
        public string Descriptions { get; set; }

        public int FirstPrintPrice { get; set; }
        public int RePrintPrice { get; set; }
        public int MedicalPrice { get; set; }
        public int MedicalRePrintPrice { get; set; }
        public int LitPrintPrice { get; set; }
        public int LitPrintRePrintPrice { get; set; }
        public int ScanAndPrintPrice { get; set; }
        public int ScanAndProcessingPrice { get; set; }

        public List<PrintServicesViewModel> PrintServicesViewModels { get; set; }
    }
}
