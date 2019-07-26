using System;
using System.IO;

namespace PhotographyAutomation.ViewModels.Document
{
    public class FileViewModel
    {
        //[byte] result[0].filestreamTxn;
        //result[0].name
        //result[0].parent_locator
        //result[0].path_locator_str
        //result[0].path_name
        //result[0].streamId

        public byte[] filestreamTxn { get; set; }
        public string name { get; set; }
        public string parent_locator { get; set; }
        public string path_locator_str { get; set; }
        public string path_name { get; set; }
        public string streamId { get; set; }
        public Int64? fileSize { get; set; }
        public MemoryStream fileStream { get; set; }
    }
}
