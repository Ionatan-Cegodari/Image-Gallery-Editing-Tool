///
/// Author: Ionatan Cegodari
///

namespace FileLoader
{
    /// <summary>
    /// Interface
    /// An interface for loading objects
    /// </summary>
    /// <typeparam name="T">The object type to load</typeparam>
    public interface ILoad<T>
    {
        /// <summary>
        /// Method
        /// A method for loading an object
        /// </summary>
        /// <param name="pPath">Where to load the object from</param>
        /// <returns>The loaded object</returns>
        T Load(string pPath);
    }
}