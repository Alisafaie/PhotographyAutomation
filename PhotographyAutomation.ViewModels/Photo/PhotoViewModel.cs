using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.ViewModels.Photo
{
    public class PhotoViewModel
    {
        public Guid StreamId { get; set; }
        public byte[] FileStream { get; set; }
        public byte[] TransactionContext { get; set; }
        public string Name { get; set; }
        public string PathLocator { get; set; }
        public string ParentPathLocator { get; set; }
        public string FullUncPath { get; set; }
        public string Type { get; set; }
        public long? CachedFileSize { get; set; }
        public DateTime CreationDateTime { get; set; }
        public DateTime LastWriteTime { get; set; }
        public DateTime? LastAccessDateTime { get; set; }
        public bool IsDirectory { get; set; }
        public bool IsOffline { get; set; }
        public bool IsHidden { get; set; }
        public bool IsReadOnly { get; set; }
        public bool IsArchive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsTemporary { get; set; }

    }
}
