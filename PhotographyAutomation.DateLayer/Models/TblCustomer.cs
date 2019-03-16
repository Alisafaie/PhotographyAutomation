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
    
    public partial class TblCustomer
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public TblCustomer()
        {
            this.TblBooking = new HashSet<TblBooking>();
            this.TblOrderPrint = new HashSet<TblOrderPrint>();
            this.TblOrderPrintDetails = new HashSet<TblOrderPrintDetails>();
            this.TblDocuments = new HashSet<TblDocuments>();
            this.TblOrder = new HashSet<TblOrder>();
        }
    
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Nullable<byte> Gender { get; set; }
        public string Address { get; set; }
        public string Tell { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
        public string NationalId { get; set; }
        public Nullable<byte> CustomerType { get; set; }
        public Nullable<byte> IsMarried { get; set; }
        public Nullable<System.DateTime> BirthDate { get; set; }
        public Nullable<System.DateTime> WeddingDate { get; set; }
        public Nullable<byte> IsActive { get; set; }
        public Nullable<byte> IsDeleted { get; set; }
        public Nullable<int> Submitter { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblBooking> TblBooking { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrderPrint> TblOrderPrint { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrderPrintDetails> TblOrderPrintDetails { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblDocuments> TblDocuments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<TblOrder> TblOrder { get; set; }
    }
}
