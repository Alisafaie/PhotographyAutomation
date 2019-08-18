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
    
    public partial class TblPrintSizes
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblPrintSizes()
        {
            this.TblAlbums = new HashSet<TblAlbums>();
            this.TblPrintCustomerFiles = new HashSet<TblPrintCustomerFiles>();
            this.TblPrintItalianAlbums = new HashSet<TblPrintItalianAlbums>();
            this.TblPrintServicePrices = new HashSet<TblPrintServicePrices>();
            this.TblPrintSizePrices = new HashSet<TblPrintSizePrices>();
        }
    
        public int Id { get; set; }
        public string Width { get; set; }
        public string Height { get; set; }
        public string Name { get; set; }
        public bool HasFirstPrint { get; set; }
        public bool HasRePrint { get; set; }
        public bool HasMedicalPhoto { get; set; }
        public bool HasLitPrint { get; set; }
        public bool HasScanAndProcessing { get; set; }
        public bool HasAlbum { get; set; }
        public bool HasItalianAlbum { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public byte MinimumOrder { get; set; }
        public string Descriptions { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAlbums> TblAlbums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPrintCustomerFiles> TblPrintCustomerFiles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPrintItalianAlbums> TblPrintItalianAlbums { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPrintServicePrices> TblPrintServicePrices { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblPrintSizePrices> TblPrintSizePrices { get; set; }
    }
}