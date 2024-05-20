using System;

/// Author: Matthew Bowman

namespace Router.Exceptions
{
    /// <summary>
    /// Exception
    /// Gets thrown when a route cannot be found
    /// </summary>
    public class RouteNotFoundException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteNotFoundException() { }
    }
}
