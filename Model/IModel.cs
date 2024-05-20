using System;
using System.Collections.Generic;

///
/// Author: Ionatan Cegodari
///

namespace Model
{
    /// <summary>
    /// Interface
    /// An interface for the common model classes
    /// </summary>
    public interface IModel<T>
    {
        /// <summary>
        /// An event handler to be invoked when the model is updated
        /// </summary>
        event EventHandler<T> ModelUpdated;

        /// <summary>
        /// Method
        /// A method to load images based on a path into the collection
        /// </summary>
        /// <param name="pPath">Where to load the image from</param>
        void LoadImage(string pPath);

        /// <summary>
        /// A method to save an image from the collection to the disk
        /// </summary>
        /// <param name="pPath">Where to save the image</param>
        /// <param name="pImageID">Which image to save</param>
        void SaveImage(string pPath, string pImageID);

        /// <summary>
        /// A method to transform an image stored in a collection
        /// </summary>
        /// <param name="pTransform">What transformation to apply</param>
        /// <param name="pImageID">Which image to apply the transformation to</param>
        void TransformImage(string pTransform, string pImageID);

        /// <summary>
        /// Property
        /// A getter for the model data
        /// </summary>
        T ImagesDict { get; }
    }
}
