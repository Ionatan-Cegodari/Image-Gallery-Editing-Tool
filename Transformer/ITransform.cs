///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Interface
    /// An interface for all common transformation classes to implement
    /// </summary>
    /// <typeparam name="T">The object type which will be transformed</typeparam>
    public interface ITransform<T>
    {
        /// <summary>
        /// Method
        /// A method to transform something
        /// </summary>
        /// <param name="pTransformation">The transformation to apply</param>
        /// <param name="pToTransform">The object to transform</param>
        /// <returns>The transformed object</returns>
        T Transform(TransformationTypes pTransformation, T pToTransform);
    }
}
