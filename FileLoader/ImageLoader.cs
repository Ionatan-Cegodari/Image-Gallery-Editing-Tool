using System;
using System.Drawing;

///
/// Author: Ionatan Cegodari
///

namespace FileLoader
{
    public class ImageLoader : ILoad<Image>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageLoader() { }

        /// <summary>
        /// Public Method
        /// A method for loading an image from the disk
        /// </summary>
        /// <param name="pPath">Where to load the image from</param>
        /// <returns>The loaded image</returns>
        public Image Load(string pPath)
        {
            // TRY to load the image from disk and return it or return null:
            try
            {
                Image image = Image.FromFile(pPath);
                return image;
            }
            catch (Exception e)
            {
                Console.WriteLine("Image Not Found");
                return null;
            }
        }
    }
}
