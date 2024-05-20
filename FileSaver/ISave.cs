///
/// Author: Ionatan Cegodari
///

namespace FileSaver
{
    /// <summary>
    /// Interface
    /// An interface for saving objects
    /// </summary>
    /// <typeparam name="T">The object type to save</typeparam>
    public interface ISave<T>
    {
        /// <summary>
        /// Method
        /// A method for saving an object
        /// </summary>
        /// <param name="pPath">Where to save the object</param>
        /// <param name="toSave">What to save</param>
        void Save(string pPath, T toSave);
    }
}
