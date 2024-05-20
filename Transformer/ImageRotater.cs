using System.Drawing;

///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Class
    /// A class to rotate images implementing the IRotate interface
    /// </summary>
    internal class ImageRotater : IRotate<Image>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageRotater() { }

        /// <summary>
        /// Public Method
        /// Rotates an image and returns it
        /// </summary>
        /// <param name="pToRotate">The image to rotate</param>
        /// <returns>The rotated image</returns>
        public Image Rotate(Image pToRotate)
        {
            // ROTATE the image and return it:
            pToRotate.RotateFlip(RotateFlipType.Rotate270FlipNone);
            return pToRotate;
        }
    }
}
