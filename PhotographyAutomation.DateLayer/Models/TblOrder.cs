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
    
    public partial class TblOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblOrder()
        {
            this.TblAllOrderStatus = new HashSet<TblAllOrderStatus>();
            this.TblFilesError = new HashSet<TblFilesError>();
            this.TblOrderPrint = new HashSet<TblOrderPrint>();
            this.TblOrderFiles = new HashSet<TblOrderFiles>();
        }
    
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int OrderStatusId { get; set; }
        public int BookingId { get; set; }
        public int PhotographyTypeId { get; set; }
        public int CustomerId { get; set; }
        public Nullable<int> PhotographerId { get; set; }
        public Nullable<byte> PaymentIsOk { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public Nullable<System.TimeSpan> Time { get; set; }
        public Nullable<System.Guid> OrderFolderStreamId { get; set; }
        public string OrderFolderPathLocator { get; set; }
        public string OrderFolderParentPathLocator { get; set; }
        public Nullable<int> TotalFiles { get; set; }
        public bool IsActive { get; set; }
        public System.DateTime CreatedDateTime { get; set; }
        public Nullable<System.DateTime> ModifiedDateTime { get; set; }
        public Nullable<int> Submitter { get; set; }
        public Nullable<System.DateTime> UploadDate { get; set; }
        public Nullable<bool> OrderPrintIssued { get; set; }
        public Nullable<int> LastOrderPrintCustomerId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblAllOrderStatus> TblAllOrderStatus { get; set; }
        public virtual TblBooking TblBooking { get; set; }
        public virtual TblCustomer TblCustomer { get; set; }
        public virtual TblCustomer TblCustomer1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblFilesError> TblFilesError { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrderPrint> TblOrderPrint { get; set; }
        public virtual TblOrderStatus TblOrderStatus { get; set; }
        public virtual TblPhotographyType TblPhotographyType { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrderFiles> TblOrderFiles { get; set; }
    }
}
