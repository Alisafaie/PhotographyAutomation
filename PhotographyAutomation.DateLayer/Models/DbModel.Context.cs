﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class PhotographyAutomationDBEntities : DbContext
    {
        public PhotographyAutomationDBEntities()
            : base("name=PhotographyAutomationDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<TblAtelierType> TblAtelierType { get; set; }
        public virtual DbSet<TblBookingStatus> TblBookingStatus { get; set; }
        public virtual DbSet<TblEmployeeType> TblEmployeeType { get; set; }
        public virtual DbSet<TblEmpRole> TblEmpRole { get; set; }
        public virtual DbSet<TblPhotographyType> TblPhotographyType { get; set; }
        public virtual DbSet<TblRoleType> TblRoleType { get; set; }
        public virtual DbSet<TblUser> TblUser { get; set; }
        public virtual DbSet<TblBooking> TblBooking { get; set; }
    }
}
