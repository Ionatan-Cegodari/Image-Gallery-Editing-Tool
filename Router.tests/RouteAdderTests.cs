using Router.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Xunit;

namespace Router.tests
{
    public class RouteAdderTests
    {
        [Fact]
        public void AddRouteTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();

            // Act
            Exception exception = Record.Exception(() => resolver.AddRoute("Main", new Regex("^/main/$")));

            // Assert
            Assert.Null(exception);
        }

        [Fact]
        public void RouteNameExistsExceptionTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();

            // Act
            resolver.AddRoute("Main", new Regex("^/main/$"));

            // Assert
            Assert.Throws<RouteNameExistsException>(() => resolver.AddRoute("Main", new Regex("^/main_two/$")));
        }

        [Fact]
        public void RouteExpressionExistsExceptionTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();

            // Act
            resolver.AddRoute("Main", new Regex("^/main/$"));

            // Assert
            Assert.Throws<RouteExpressionExistsException>(() => resolver.AddRoute("Main_Two", new Regex("^/main/$")));
        }

        [Fact]
        public void RouteNameAndExpressionExistsExceptionTest()
        {
            // Arrange
            IResolveRoutes resolver = new RouteResolver();

            // Act
            resolver.AddRoute("Main", new Regex("^/main/$"));

            // Assert
            Assert.Throws<RouteNameAndExpressionExistsException>(() => resolver.AddRoute("Main", new Regex("^/main/$")));
        }
    }
}
