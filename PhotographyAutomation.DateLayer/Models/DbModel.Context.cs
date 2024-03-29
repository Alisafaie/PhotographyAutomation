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
    
        public virtual DbSet<TblAlbums> TblAlbums { get; set; }
        public virtual DbSet<TblAllOrderStatus> TblAllOrderStatus { get; set; }
        public virtual DbSet<TblAtelierType> TblAtelierType { get; set; }
        public virtual DbSet<TblBooking> TblBooking { get; set; }
        public virtual DbSet<TblBookingStatus> TblBookingStatus { get; set; }
        public virtual DbSet<TblCustomer> TblCustomer { get; set; }
        public virtual DbSet<TblFilesError> TblFilesError { get; set; }
        public virtual DbSet<TblOrder> TblOrder { get; set; }
        public virtual DbSet<TblOrderFiles> TblOrderFiles { get; set; }
        public virtual DbSet<TblOrderPrint> TblOrderPrint { get; set; }
        public virtual DbSet<TblOrderPrintChangingElements> TblOrderPrintChangingElements { get; set; }
        public virtual DbSet<TblOrderPrintDetails> TblOrderPrintDetails { get; set; }
        public virtual DbSet<TblOrderPrintFiles> TblOrderPrintFiles { get; set; }
        public virtual DbSet<TblOrderPrintLitPrint> TblOrderPrintLitPrint { get; set; }
        public virtual DbSet<TblOrderPrintMultiPhotoOrder> TblOrderPrintMultiPhotoOrder { get; set; }
        public virtual DbSet<TblOrderPrintStatus> TblOrderPrintStatus { get; set; }
        public virtual DbSet<TblOrderStatus> TblOrderStatus { get; set; }
        public virtual DbSet<TblPhotographyType> TblPhotographyType { get; set; }
        public virtual DbSet<TblPrintCustomerFiles> TblPrintCustomerFiles { get; set; }
        public virtual DbSet<TblPrintServicePrices> TblPrintServicePrices { get; set; }
        public virtual DbSet<TblPrintServices> TblPrintServices { get; set; }
        public virtual DbSet<TblPrintSizePrices> TblPrintSizePrices { get; set; }
        public virtual DbSet<TblPrintSizes> TblPrintSizes { get; set; }
        public virtual DbSet<TblPrintSpecialServices> TblPrintSpecialServices { get; set; }
        public virtual DbSet<View_GetAllPhotos> View_GetAllPhotos { get; set; }
        public virtual DbSet<View_GetAllPrintSizeAndServicesInfo> View_GetAllPrintSizeAndServicesInfo { get; set; }
        public virtual DbSet<View_GetDocumentsFolders> View_GetDocumentsFolders { get; set; }
    
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
    
        public virtual ObjectResult<usp_CreateFileTableFile_Result2> usp_CreateFileTableFile(string name, string parent_name, Nullable<byte> parent_level)
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
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_CreateFileTableFile_Result2>("usp_CreateFileTableFile", nameParameter, parent_nameParameter, parent_levelParameter);
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
    
        public virtual int usp_DeleteOrderFolderFiles(string pathLocator)
        {
            var pathLocatorParameter = pathLocator != null ?
                new ObjectParameter("pathLocator", pathLocator) :
                new ObjectParameter("pathLocator", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_DeleteOrderFolderFiles", pathLocatorParameter);
        }
    
        public virtual ObjectResult<usp_GetImageInfo_Result2> usp_GetImageInfo(Nullable<System.Guid> photoStreamId)
        {
            var photoStreamIdParameter = photoStreamId.HasValue ?
                new ObjectParameter("photoStreamId", photoStreamId) :
                new ObjectParameter("photoStreamId", typeof(System.Guid));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetImageInfo_Result2>("usp_GetImageInfo", photoStreamIdParameter);
        }
    
        public virtual ObjectResult<usp_GetListOfFilesInFolder_Result2> usp_GetListOfFilesInFolder(string path_locator)
        {
            var path_locatorParameter = path_locator != null ?
                new ObjectParameter("path_locator", path_locator) :
                new ObjectParameter("path_locator", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<usp_GetListOfFilesInFolder_Result2>("usp_GetListOfFilesInFolder", path_locatorParameter);
        }
    
        public virtual ObjectResult<Nullable<System.Guid>> usp_GetListOfFilesOfOrder(string path_locator)
        {
            var path_locatorParameter = path_locator != null ?
                new ObjectParameter("path_locator", path_locator) :
                new ObjectParameter("path_locator", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<Nullable<System.Guid>>("usp_GetListOfFilesOfOrder", path_locatorParameter);
        }
    
        public virtual ObjectResult<string> usp_GetOrderFolderStreamId(string customerFinancialNumber, ObjectParameter returnValue)
        {
            var customerFinancialNumberParameter = customerFinancialNumber != null ?
                new ObjectParameter("customerFinancialNumber", customerFinancialNumber) :
                new ObjectParameter("customerFinancialNumber", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<string>("usp_GetOrderFolderStreamId", customerFinancialNumberParameter, returnValue);
        }
    
        public virtual int usp_GetPrintSizePriceServices()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_GetPrintSizePriceServices");
        }
    
        public virtual int usp_GetTotalFilesOfFolder(string parent_path_locator, ObjectParameter returnValue)
        {
            var parent_path_locatorParameter = parent_path_locator != null ?
                new ObjectParameter("parent_path_locator", parent_path_locator) :
                new ObjectParameter("parent_path_locator", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("usp_GetTotalFilesOfFolder", parent_path_locatorParameter, returnValue);
        }
    }
}
