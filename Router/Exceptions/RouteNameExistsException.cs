using System;

/// Author: Matthew Bowman

namespace Router.Exceptions
{
    /// <summary>
    /// Exception
    /// Gets thrown when a route name is already in use
    /// </summary>
    public class RouteNameExistsException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteNameExistsException() { }
    }
}
