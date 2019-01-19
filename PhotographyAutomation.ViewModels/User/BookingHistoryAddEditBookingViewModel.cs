using System;

namespace PhotographyAutomation.ViewModels.User
{
    public class BookingHistoryAddEditBookingViewModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public byte? CustomerGender { get; set; }
        public string CustomerFullName { get; set; }
        public DateTime Date { get; set; }
        public string Time { get; set; }
        public int PhotographerGender { get; set; }
        public int PhotographyTypeId { get; set; }
        public string PhotographyTypeName { get; set; }
        public int AtelierTypeId { get; set; }
        public string AtelierTypeName { get; set; }
        public int PersonCount { get; set; }
        public int PaymentIsOk { get; set; }
        public int Submitter { get; set; }
        public string SubmitterName { get; set; }
        public int StatusId { get; set; }
        public string StatusName { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public DateTime? ModifiedDateTime { get; set; }
    }
}
