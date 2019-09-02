//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PhotographyAutomation.DateLayer.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class View_GetAllPrintSizeAndServicesInfo
    {
        public int PrintSizeId { get; set; }
        public Nullable<int> PrintServiceId { get; set; }
        public Nullable<int> PrintSizePriceId { get; set; }
        public Nullable<int> PrintServicePriceId { get; set; }
        public string PrintSizeName { get; set; }
        public string PrintServiceName { get; set; }
        public Nullable<int> PrintServicePrice { get; set; }
        public Nullable<int> FirstPrintPrice { get; set; }
        public Nullable<int> RePrintPrice { get; set; }
        public bool HasMedicalPhoto { get; set; }
        public Nullable<int> MedicalPrice { get; set; }
        public Nullable<int> MedicalRePrintPrice { get; set; }
        public bool HasLitPrint { get; set; }
        public Nullable<int> LitPrintPrice { get; set; }
        public Nullable<int> LitPrintRePrintPrice { get; set; }
        public bool HasScanAndProcessing { get; set; }
        public Nullable<int> ScanAndPrintPrice { get; set; }
        public Nullable<int> ScanAndProcessingPrice { get; set; }
        public bool HasItalianAlbum { get; set; }
        public Nullable<int> ItalianAlbumPagePrice { get; set; }
        public Nullable<int> ItalianAlbumBoundingPrice { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public byte MinimumOrder { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}
