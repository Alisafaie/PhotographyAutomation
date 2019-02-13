using System;

namespace PhotographyAutomation.ViewModels.Document
{
    public class DocumentInfoViewModel
    {
        public Guid StreamId { get; set; }
        public byte[] FileStream { get; set; }
        public string FileName { get; set; }
        public string PathLocator { get; set; }
        public string ParentPathLocator { get; set; }
        public string UncPath { get; set; }
        public string RelativePath { get; set; }
        public string FullUncPath { get; set; }
        public int Level { get; set; }
        public string FileType { get; set; }
        public ulong FileSize { get; set; }
        public DateTime CreationTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime LastAccessTime { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsOffline { get; set; }
        public bool IsHidden { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsArchive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsTemporary { get; set; }
    }
}
