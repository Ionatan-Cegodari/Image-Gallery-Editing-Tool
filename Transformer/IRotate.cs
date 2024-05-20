///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Interface
    /// An interface to rotate objects
    /// </summary>
    /// <typeparam name="T">The object type which will be rotated</typeparam>
    internal interface IRotate<T>
    {
        /// <summary>
        /// Method
        /// A method to rotate an object
        /// </summary>
        /// <param name="pToRotate">The object to be rotated</param>
        /// <returns>The rotated object</returns>
        T Rotate(T pToRotate);
    }
}
