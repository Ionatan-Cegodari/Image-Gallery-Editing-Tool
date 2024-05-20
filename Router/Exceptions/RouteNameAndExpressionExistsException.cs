using System;

/// Author: Matthew Bowman

namespace Router.Exceptions
{
    /// <summary>
    /// Exception
    /// Gets thrown when a route expression and name is already in use
    /// </summary>
    public class RouteNameAndExpressionExistsException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteNameAndExpressionExistsException() { }
    }
}
