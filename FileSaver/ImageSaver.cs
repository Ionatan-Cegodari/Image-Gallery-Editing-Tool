using System;
using System.Drawing;

///
/// Author: Ionatan Cegodari
///

namespace FileSaver
{
    /// <summary>
    /// Class
    /// A class for saving images to the disk
    /// </summary>
    public class ImageSaver : ISave<Image>
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public ImageSaver() { }

        /// <summary>
        /// Public Method
        /// A method for saving images to the disk
        /// </summary>
        /// <param name="pPath">Where to save the image</param>
        /// <param name="pFile">The image to save</param>
        public void Save(string pPath, Image pFile)
        {
            // TRY to save the image to disk:
            try
            {
                pFile.Save(pPath);
            } catch (Exception e)
            {
                Console.WriteLine("Could Not Save Image");
            }
        }
    }
}
