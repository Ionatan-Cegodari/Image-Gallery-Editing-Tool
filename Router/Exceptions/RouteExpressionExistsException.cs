using System;

/// Author: Matthew Bowman

namespace Router.Exceptions
{
    /// <summary>
    /// Exception
    /// Gets thrown when a route expression is already in use
    /// </summary>
    public class RouteExpressionExistsException : Exception
    {
        /// <summary>
        /// Default Constructor
        /// </summary>
        public RouteExpressionExistsException() { }
    }
}
