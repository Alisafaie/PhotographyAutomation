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
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
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
        public virtual DbSet<TblBooking> TblBooking { get; set; }
        public virtual DbSet<TblBookingStatus> TblBookingStatus { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblEmployeeType> TblEmployeeType { get; set; }
        public virtual DbSet<TblEmpRole> TblEmpRole { get; set; }
        public virtual DbSet<TblPhotographyType> TblPhotographyType { get; set; }
        public virtual DbSet<TblRoleType> TblRoleType { get; set; }
        public virtual DbSet<TblDocuments> TblDocuments { get; set; }
        public virtual DbSet<View_GetAllPhotos> View_GetAllPhotos { get; set; }
        public virtual DbSet<View_GetDocumentsFolders> View_GetDocumentsFolders { get; set; }
        public virtual DbSet<TblDocumentPhotos> TblDocumentPhotos { get; set; }
    
        public virtual ObjectResult<string> usp_CreateYearFolder(string name, string parent_name, Nullable<byte> parent_level, ObjectParameter returnValue)
        {
            var nameParameter = name != null ?
                new ObjectParameter("name", name) :
                new ObjectParameter("name", typeof(string));
    
            var parent_nameParameter = parent_name != null ?
                new ObjectParameter("parent_name", parent_name) :
                new ObjectParameter("parent_name", typeof(string));
    
            var parent_levelParameter = parent_level.HasValue ?
                new ObjectParameter("parent_level", parent_level) :
                new ObjectParameter("parent_level", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_CreateYearFolder", nameParameter, parent_nameParameter, parent_levelParameter, returnValue);
        }
    
        public virtual ObjectResult<string> usp_CreateCustomerFinancialDirectory(string customerFinancialNumber, string monthNumber, Nullable<byte> parent_level, ObjectParameter returnValue)
        {
            var customerFinancialNumberParameter = customerFinancialNumber != null ?
                new ObjectParameter("customerFinancialNumber", customerFinancialNumber) :
                new ObjectParameter("customerFinancialNumber", typeof(string));
    
            var monthNumberParameter = monthNumber != null ?
                new ObjectParameter("monthNumber", monthNumber) :
                new ObjectParameter("monthNumber", typeof(string));
    
            var parent_levelParameter = parent_level.HasValue ?
                new ObjectParameter("parent_level", parent_level) :
                new ObjectParameter("parent_level", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_CreateCustomerFinancialDirectory", customerFinancialNumberParameter, monthNumberParameter, parent_levelParameter, returnValue);
        }
    
        public virtual ObjectResult<string> usp_CreateMonthFolder(string monthName, string year, Nullable<byte> parent_level, ObjectParameter returnValue)
        {
            var monthNameParameter = monthName != null ?
                new ObjectParameter("monthName", monthName) :
                new ObjectParameter("monthName", typeof(string));
    
            var yearParameter = year != null ?
                new ObjectParameter("year", year) :
                new ObjectParameter("year", typeof(string));
    
            var parent_levelParameter = parent_level.HasValue ?
                new ObjectParameter("parent_level", parent_level) :
                new ObjectParameter("parent_level", typeof(byte));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_CreateMonthFolder", monthNameParameter, yearParameter, parent_levelParameter, returnValue);
        }
    }
}
