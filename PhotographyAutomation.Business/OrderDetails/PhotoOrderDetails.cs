using System;

namespace PhotographyAutomation.Business.OrderDetails
{
    public class PhotoOrderDetails
    {
        public Guid StreamId { get; set; }
        public int PhotoCursor { get; set; }
        public int OriginalSizeId { get; set; }
        public int OriginalPrintSizePrice { get; set; }
        public bool HasOriginalPrintService { get; set; }
        public int OriginalServiceId { get; set; }
        public int OriginalPrintServicePrice { get; set; }
        public string RetouchDescriptions { get; set; }
        public bool IsAccepted { get; set; }


        public bool HasSecondPrint1 { get; set; }
        public int SecondPrint1SizeId { get; set; }
        public int SecondPrint1Count { get; set; }
        public int SecondPrint1SizePrice { get; set; }
        public bool HasSecondPrint1Service { get; set; }
        public int SecondPrint1ServiceCount { get; set; }
        public int SecondPrint1ServiceId { get; set; }
        public int SecondPrint1ServicePrice { get; set; }

        public bool HasSecondPrint2 { get; set; }
        public int SecondPrint2SizeId { get; set; }
        public int SecondPrint2Count { get; set; }
        public int SecondPrint2SizePrice { get; set; }
        public bool HasSecondPrint2Service { get; set; }
        public int SecondPrint2ServiceCount { get; set; }
        public int SecondPrint2ServiceId { get; set; }
        public int SecondPrint2ServicePrice { get; set; }

        public bool HasSecondPrint3 { get; set; }
        public int SecondPrint3SizeId { get; set; }
        public int SecondPrint3Count { get; set; }
        public int SecondPrint3SizePrice { get; set; }
        public bool HasSecondPrint3Service { get; set; }
        public int SecondPrint3ServiceCount { get; set; }
        public int SecondPrint3ServiceId { get; set; }
        public int SecondPrint3ServicePrice { get; set; }

        public bool HasSecondPrint4 { get; set; }
        public int SecondPrint4SizeId { get; set; }
        public int SecondPrint4Count { get; set; }
        public int SecondPrint4SizePrice { get; set; }
        public bool HasSecondPrint4Service { get; set; }
        public int SecondPrint4ServiceCount { get; set; }
        public int SecondPrint4ServiceId { get; set; }
        public int SecondPrint4ServicePrice { get; set; }
    }
}