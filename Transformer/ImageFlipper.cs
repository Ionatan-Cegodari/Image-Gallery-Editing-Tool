using System.Drawing;

///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Class
    /// A class to flip images implementing the IFlip interface
    /// </summary>
    internal class ImageFlipper : IFlip<Image>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageFlipper() { }

        /// <summary>
        /// Public Method
        /// Flips an image and returns it
        /// </summary>
        /// <param name="pToFlip">The image to flip</param>
        /// <returns>The flipped image</returns>
        public Image Flip(Image pToFlip)
        {
            // FLIP the image and return it:
            pToFlip.RotateFlip(RotateFlipType.RotateNoneFlipX);
            return pToFlip;
        }
    }
}
