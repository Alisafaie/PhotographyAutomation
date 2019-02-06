using System;

namespace PhotographyAutomation.ViewModels.Document
{
    public class DocumentInfoViewModel
    {
        public Guid StreamId { get; set; }
        public byte[] FileStream { get; set; }
        public string FileName { get; set; }
        public bool IsDirectory { get; set; }
        public string UncPath { get; set; }
    }
}
