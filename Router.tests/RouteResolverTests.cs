using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

using Router.Exceptions;

namespace Router.tests
{
    public class RouteResolverTests
    {
        [Fact]
        public void BasicRouteExistsTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();
            resolver.AddRoute("Main", new Regex("^/main/$"));

            // Act
            string route = resolver.ResolveRoute("/main/");

            // Assert
            Assert.Equal("Main", route);
        }

        [Fact]
        public void AdvancedRouteExistsTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();
            resolver.AddRoute("Main", new Regex("^/image/[0-9]*/$"));

            // Act
            string route = resolver.ResolveRoute("/image/17/");

            // Assert
            Assert.Equal("Main", route);
        }

        [Fact]
        public void RouteNotFoundExceptionTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();
            resolver.AddRoute("Main", new Regex("^/main/$"));

            // Act & Assert
            Assert.Throws<RouteNotFoundException>(() => resolver.ResolveRoute("/NonExistingRoute/"));
        }
    }
}
