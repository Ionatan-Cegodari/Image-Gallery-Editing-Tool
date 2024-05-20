using System.Drawing;
using Transformer.Exceptions;

///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Class
    /// An implementation of the ITransform interface for transforming images specifically
    /// </summary>
    public class ImageTransformer : ITransform<Image>
    {
        // DECLARE a field of type IRotate<Image> to store the class for rotating images, call it _rotater:
        private IRotate<Image> _rotater;
        // DECLARE a field of type IFlip<Image> to store the class for flipping images, call it _flipper:
        private IFlip<Image> _flipper;

        /// <summary>
        /// Default Constructor
        /// Used for setting up the fields
        /// </summary>
        public ImageTransformer()
        {
            // INSTANTIATE and assign required classes to fields:
            _rotater = new ImageRotater();
            _flipper = new ImageFlipper();
        }

        /// <summary>
        /// Public Method
        /// Used to transform an image
        /// </summary>
        /// <param name="pTransformation">The transformation to apply</param>
        /// <param name="pToTransform">The image to transform</param>
        /// <returns>The transformed image</returns>
        /// <exception cref="TransformationNotAllowedException">Thrown when an illegal transformation is attempted</exception>
        public Image Transform(TransformationTypes pTransformation, Image pToTransform)
        {
            // DECIDE which transformation to apply and return it:
            switch (pTransformation)
            {
                case TransformationTypes.ROTATE:
                    return _rotater.Rotate(pToTransform);
                case TransformationTypes.FLIP:
                    return _flipper.Flip(pToTransform);
                default:
                    throw new TransformationNotAllowedException();
            }
        }
    }
}
