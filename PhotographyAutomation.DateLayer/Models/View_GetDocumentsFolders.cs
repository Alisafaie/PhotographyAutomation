//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class View_GetDocumentsFolders
    {
        public System.Guid StreamId { get; set; }
        public byte[] FileStream { get; set; }
        public string FolderName { get; set; }
        public string PathLocator { get; set; }
        public string ParentPathLocator { get; set; }
        public string UncPath { get; set; }
        public string RelativePath { get; set; }
        public string FullUncPath { get; set; }
        public Nullable<short> Level { get; set; }
        public string FileType { get; set; }
        public Nullable<long> FileSize { get; set; }
        public System.DateTimeOffset CreationTime { get; set; }
        public System.DateTimeOffset LastWriteTime { get; set; }
        public Nullable<System.DateTimeOffset> LastAccessTime { get; set; }
        public bool IsOffline { get; set; }
        public bool IsHidden { get; set; }
        public bool IsReadonly { get; set; }
        public bool IsArchive { get; set; }
        public bool IsSystem { get; set; }
        public bool IsTemporary { get; set; }
        public bool IsDirectory { get; set; }
    }
}
