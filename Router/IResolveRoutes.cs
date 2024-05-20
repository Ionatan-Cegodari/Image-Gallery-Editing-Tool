using System.Text.RegularExpressions;

/// Author: Matthew Bowman

namespace Router
{
    /// <summary>
    /// Interface
    /// Provides methods for adding and resolving routes
    /// </summary>
    public interface IResolveRoutes
    {
        void AddRoute(string pRouteName, Regex pRouteExpression);
        string ResolveRoute(string pRouteExpression);
    }
}
