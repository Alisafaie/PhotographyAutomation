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
    
    public partial class TblBooking
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public System.DateTime Date { get; set; }
        public System.TimeSpan Time { get; set; }
        public byte PhotographerGender { get; set; }
        public int PhotographyTypeId { get; set; }
        public Nullable<int> AtelierTypeId { get; set; }
        public Nullable<int> PersonCount { get; set; }
        public byte PrepaymentIsOk { get; set; }
        public int Submitter { get; set; }
        public int StatusId { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> ModifiedDate { get; set; }
    
        public virtual TblUser TblUser { get; set; }
    }
}
