using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
// ReSharper disable UnusedMember.Global
// ReSharper disable UnusedMember.Local

namespace PhotographyAutomation.Utilities.ExtentionMethods
{
    public static class ImageHelper
    {
        private static ImageOrientation GetOrientation(this Image image)
        {
            PropertyItem pi = SafeGetPropertyItem(image, 0x112);

            if (pi == null || pi.Type != 3)
            {
                return ImageOrientation.Original;
            }

            return (ImageOrientation)BitConverter.ToInt16(pi.Value, 0);
        }

        static PropertyItem SafeGetPropertyItem(Image image, int propid)
        {
            try
            {
                return image.GetPropertyItem(propid);
            }
            catch (ArgumentException)
            {
                return null;
            }
        }

        private enum ImageOrientation
        {
            /// <summary>
            /// Image is correctly oriented
            /// </summary>
            Original = 1,
            /// <summary>
            /// Image has been mirrored horizontally
            /// </summary>
            MirrorOriginal = 2,
            /// <summary>
            /// Image has been rotated 180 degrees
            /// </summary>
            Half = 3,
            /// <summary>
            /// Image has been mirrored horizontally and rotated 180 degrees
            /// </summary>
            MirrorHalf = 4,
            /// <summary>
            /// Image has been mirrored horizontally and rotated 270 degrees clockwise
            /// </summary>
            MirrorThreeQuarter = 5,
            /// <summary>
            /// Image has been rotated 270 degrees clockwise
            /// </summary>
            ThreeQuarter = 6,
            /// <summary>
            /// Image has been mirrored horizontally and rotated 90 degrees clockwise.
            /// </summary>
            MirrorOneQuarter = 7,
            /// <summary>
            /// Image has been rotated 90 degrees clockwise.
            /// </summary>
            OneQuarter = 8
        }

        private static RotateFlipType OrientationToFlipType(int orientation)
        {
            switch (orientation)
            {
                case 1:
                    return RotateFlipType.RotateNoneFlipNone;
                case 2:
                    return RotateFlipType.RotateNoneFlipX;
                case 3:
                    return RotateFlipType.Rotate180FlipNone;
                case 4:
                    return RotateFlipType.Rotate180FlipX;
                case 5:
                    return RotateFlipType.Rotate90FlipX;
                case 6:
                    return RotateFlipType.Rotate90FlipNone;
                case 7:
                    return RotateFlipType.Rotate270FlipX;
                case 8:
                    return RotateFlipType.Rotate270FlipNone;
                default:
                    return RotateFlipType.RotateNoneFlipNone;
            }
        }







        public static Image GetPhotoAndRotateIt(this byte[] originalPhoto)
        {
            using (var ms = new MemoryStream(originalPhoto))
            {
                Image img = Image.FromStream(ms);
                var orientation = img.GetOrientation();
                RotateFlipType rotationType = OrientationToFlipType((int)orientation);
                img.RotateFlip(rotationType);
                return img;
            }
        }
    }
}
