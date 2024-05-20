using Router.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

///
/// Author: Ionatan Cegodari, Matthew Bowman
///


namespace Router
{
    /// <summary>
    /// Class
    /// The role of the class is to add and resolve routes provided at runtime.
    /// </summary>
    public class RouteResolver : IResolveRoutes
    {
        // DECLARE a field of type List<Route> to contain added routes, call it _routes;
        private List<Route> _routes;

        /// <summary>
        /// Constructor
        /// Instantiate relevant fields
        /// </summary>
        public RouteResolver() {
            // ASSIGN an instantiation of List<Route> to the _routes field:
            _routes = new List<Route>();
        }

        /// <summary>
        /// Public Method
        /// Attempts to add a route to the _routes list
        /// </summary>
        /// <param name="pRouteName">The name of the route</param>
        /// <param name="pRouteExpression">The route expression</param>
        /// <exception cref="RouteNameAndExpressionExistsException">Thrown when both the route name and expression are already in use</exception>
        /// <exception cref="RouteNameExistsException">Thrown when the route name is already in use</exception>
        /// <exception cref="RouteExpressionExistsException">Thrown when the route expression is already in use</exception>

        public void AddRoute(string pRouteName, Regex pRouteExpression)
        {
            // EXPRESSIONS used for throwing exceptions
            bool duplicateRouteName = _routes.Any(route => route.Name == pRouteName);
            bool duplicateRouteExpression = _routes.Any(route => route.Expression.ToString() == pRouteExpression.ToString());

            // DECIDE if an exception should be thrown, otherwise add the route to the list:
            if (duplicateRouteName && duplicateRouteExpression) throw new RouteNameAndExpressionExistsException();
            else if (duplicateRouteName) throw new RouteNameExistsException();
            else if (duplicateRouteExpression) throw new RouteExpressionExistsException();
            else _routes.Add(new Route(pRouteName, pRouteExpression));
        }

        /// <summary>
        /// Public Method
        /// Takes a string and matches it to the first expression found in the _routes list
        /// </summary>
        /// <param name="pRouteAddress">The string to compare the expressions with</param>
        /// <returns>The name of the route</returns>
        /// <exception cref="RouteNotFoundException">Thrown when no expressions match the string</exception>
        public string ResolveRoute(string pRouteAddress)
        {
            // DECLARE a string which will hold the route name discovered:
            string routeName = null;

            // ITERATE over each existing route and check if the expression matches:
            foreach (Route route in _routes) {

                Regex expression = route.Expression;

                // IF the expression matches break the foreach:
                if(expression.IsMatch(pRouteAddress))
                {
                    // ASSIGN the current route's name to routeName
                    routeName = route.Name;
                    break;
                }
            
            }

            // IF no valid route was found throw an exception, otherwise return the discovery
            if (routeName == null) throw new RouteNotFoundException();
            else return routeName;
        }
    }
}
