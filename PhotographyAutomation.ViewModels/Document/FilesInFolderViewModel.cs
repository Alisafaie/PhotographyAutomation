using System;

namespace PhotographyAutomation.ViewModels.Document
{
    public class FilesInFolderViewModel
    {
        public Guid StreamId { get; set; }
        public string FileName { get; set; }
        public long? FileSize { get; set; }
    }
}
