///
/// Author: Ionatan Cegodari
///

namespace Transformer
{
    /// <summary>
    /// Interface
    /// An interface to flip objects
    /// </summary>
    /// <typeparam name="T">The object type which will be rotated</typeparam>
    internal interface IFlip<T>
    {
        /// <summary>
        /// Method
        /// A method to flip an object
        /// </summary>
        /// <param name="pToFlip">The object to flip</param>
        /// <returns>The flipped object</returns>
        T Flip(T pToFlip);
    }
}
