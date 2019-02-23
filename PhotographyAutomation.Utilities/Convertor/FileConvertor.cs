using System.IO;

namespace PhotographyAutomation.Utilities.Convertor
{
    public class FileConvertor
    {
        public static byte[] FileToByteArray(string fileName)
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
