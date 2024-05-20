using FileLoader;
using FileSaver;
using System;
using System.Collections.Generic;
using System.Drawing;
using Transformer;
using Transformer.Exceptions;

///
/// Author: Ionatan Cegodari
///

namespace Model
{
    /// <summary>
    /// Class
    /// A class to store the collection of images and apply any manipulations as well as interacting with the disk loading/saving
    /// </summary>
    public class ImagesModel : IModel<Dictionary<string, Image>>
    {
        /// <summary>
        /// An event handler which should be invoked whenever the model is updated
        /// </summary>
        public event EventHandler<Dictionary<string, Image>> ModelUpdated;


        // DECLARE a field of type Dictionary<string, Image> to store a collection of images in memory, call it _imagesDict:
        private Dictionary<string, Image> _imagesDict;

        // DECLARE a field of type ISave<Image> to handle saving an image to the disk, call it _imageSaver:
        private ISave<Image> _imageSaver;

        // DECLARE a field of type ILoad<Image> to handle loading an image from the disk, call it _imageLoader:
        private ILoad<Image> _imageLoader;

        // DECLARE a field of type ITransform<Image> to handle image transformations, call it _imageTransformer:
        private ITransform<Image> _imageTransformer;

        // DECLARE a field of type int to store a unique identifier for each image stored in the dictionary, call it _dictionaryKey:
        private int _dictionaryKey;

        /// <summary>
        /// Property
        /// Acts as a getter for the _imagesDict field
        /// </summary>
        public Dictionary<string, Image> ImagesDict { get { return _imagesDict; } }

        /// <summary>
        /// Default Constructor
        /// A constructor used for setting up the class
        /// </summary>
        public ImagesModel()
        {
            // INSTANTIATE field objects and assign them:
            _imagesDict = new Dictionary<string, Image>();
            _imageSaver = new ImageSaver();
            _imageLoader = new ImageLoader();
            _imageTransformer = new ImageTransformer();
        }

        /// <summary>
        /// Public Method
        /// A method to load an image and add it to the dictionary
        /// </summary>
        /// <param name="pPath">Where to load the image from</param>
        public void LoadImage(string pPath)
        {
            // LOAD an image and add it to the dictionary:
            Image loadedImage = _imageLoader.Load(pPath);

            if (loadedImage != null)
            {
                _imagesDict.Add(_dictionaryKey.ToString(), loadedImage);
                // INCREMENT the dictionary key for the next image being added:
                _dictionaryKey++;

                // TRIGGER Event:
                OnModelUpdated(_imagesDict);
            }
        }

        /// <summary>
        /// Public Method
        /// A method to save an image to the disk
        /// </summary>
        /// <param name="pPath">Where to save the image to</param>
        /// <param name="pImageID">What image to save</param>
        public void SaveImage(string pPath, string pImageID)
        {
            // SAVE the image:
            _imageSaver.Save(pPath, _imagesDict[pImageID]);
        }

        /// <summary>
        /// Public Method
        /// A method to transform an image in the dictionary
        /// </summary>
        /// <param name="pTransform">The transformation to occur</param>
        /// <param name="pImageID">The image to transform</param>
        public void TransformImage(string pTransform, string pImageID)
        {
            // DECIDE the transformation to apply to the image:
            switch (pTransform)
            {
                case "Rotate":
                    _imagesDict[pImageID] = _imageTransformer.Transform(TransformationTypes.ROTATE, _imagesDict[pImageID]);
                    break;
                case "Flip":
                    _imagesDict[pImageID] = _imageTransformer.Transform(TransformationTypes.FLIP, _imagesDict[pImageID]);
                    break;
                default:
                    throw new TransformationNotAllowedException();
            }

            // INVOKE ModelUpdated event:
            OnModelUpdated(_imagesDict);
        }

        /// <summary>
        /// Protected Virtual Method
        /// A method to handle invoking the ModelUpdated event
        /// </summary>
        /// <param name="pImagesDict">The updated dictionary</param>
        protected virtual void OnModelUpdated(Dictionary<string, Image> pImagesDict)
        {
            if (ModelUpdated != null) ModelUpdated.Invoke(this, pImagesDict);
        }


    }
}
