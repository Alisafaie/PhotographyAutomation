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
    
    public partial class TblAlbums
    {
        public int Id { get; set; }
        public int PrintSizeId { get; set; }
        public string AlbumName { get; set; }
        public int TotalPages { get; set; }
        public string CoverTypeName { get; set; }
        public string Color { get; set; }
        public int Price { get; set; }
        public string Code { get; set; }
        public Nullable<int> ManufacturerId { get; set; }
    
        public virtual TblPrintSizes TblPrintSizes { get; set; }
    }
}
