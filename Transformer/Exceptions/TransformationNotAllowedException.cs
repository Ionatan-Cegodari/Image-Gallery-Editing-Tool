using System;

///
/// Author: Ionatan Cegodari
///

namespace Transformer.Exceptions
{
    /// <summary>
    /// Exception
    /// An exception which is thrown whenever an illegal transformation is attempted
    /// </summary>
    public class TransformationNotAllowedException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public TransformationNotAllowedException() { }
    }
}
