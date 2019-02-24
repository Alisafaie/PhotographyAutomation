using System.IO;

namespace PhotographyAutomation.Utilities.Convertor
{
    public static class FileConvertor
    {
        public static byte[] FileToByteArray(this string fileName)
        {
            byte[] fileData;

            using (FileStream fs = File.OpenRead(fileName))
            {
                var binaryReader = new BinaryReader(fs);
                fileData = binaryReader.ReadBytes((int)fs.Length);
            }
            return fileData;
        }
    }
}
