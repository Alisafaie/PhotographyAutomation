using System;

namespace PhotographyAutomation.ViewModels.Order
{
    public class CustomerOrderViewModel
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public int OrderStatusId { get; set; }
        public int OrderStatusCode { get; set; }
        public string OrderStatusName { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan BookingTime { get; set; }
        public DateTime? OrderDate { get; set; }
        public TimeSpan? OrderTime { get; set; }
        public int PhotographyTypeId { get; set; }
        public string PhotographyTypeName { get; set; }
        public int CustomerId { get; set; }
        public string CustomerFullName { get; set; }
        public byte CustomerGender { get; set; }
        public int? Submitter { get; set; }
        public string SubmitterName { get; set; }
        public int? PhotographerId { get; set; }
        public byte PhotographerGender { get; set; }
        public int PersonCount { get; set; }
        public byte? PaymentIsOk { get; set; }
        public Guid? OrderFolderStreamId { get; set; }
        public string OrderFolderPathLocator { get; set; }
        public string OrderFolderParentPathLocator { get; set; }
        public int? TotalFiles { get; set; }
        public bool? IsActive { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
        public DateTime? UploadDate { get; set; }
    }
}
