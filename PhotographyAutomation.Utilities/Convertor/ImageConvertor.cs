using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyAutomation.Utilities.Convertor
{
    public static class ImageConvertor
    {
        public static byte[] ImageToByteArray(Image imageIn)
        {
            using (var ms = new MemoryStream())
            {
                imageIn.Save(ms, imageIn.RawFormat);
                return ms.ToArray();
            }
        }

        public static byte[] ConvertImageToByteArray(Image x)
        {
            var imageConverter = new ImageConverter();
            var xByte = (byte[])imageConverter.ConvertTo(x, typeof(byte[]));
            return xByte;
        }

        public static Image ByteArrayToImage(byte[] byteArrayIn)
        {
            MemoryStream ms = new MemoryStream(byteArrayIn);
            Image returnImage = Image.FromStream(ms);
            return returnImage;
        }
    }
}
