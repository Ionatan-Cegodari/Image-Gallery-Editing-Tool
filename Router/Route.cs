using System.Text.RegularExpressions;

///
/// Author: Matthew Bowman
///

namespace Router
{
    /// <summary>
    /// Struct
    /// Provides a struct for the routes aiding memory efficiency
    /// </summary>
    internal readonly struct Route
    {
        // DECLARE a field of type string to contain the route name, call it _name
        private readonly string _name;

        // Declare a field of type Regex to contain the route expression, call it _expression
        private readonly Regex _expression;


        /// <summary>
        /// Property
        /// Acts as a getter for the _name field
        /// </summary>
        public string Name
        {
            get { return _name; }
        }

        /// <summary>
        /// Property
        /// Acts as a getter for the _expression field
        /// </summary>
        public Regex Expression
        {
            get { return _expression; }
        }

        /// <summary>
        /// Constructor
        /// Assigns fields values when instantiated
        /// </summary>
        /// <param name="pName">Contains the route name</param>
        /// <param name="pExpression">Contains the route expression</param>
        public Route(string pName, Regex pExpression)
        {
            // ASSIGN the value of pName to the _name field
            _name = pName;

            // ASSIGN the value of pExpression to _expression
            _expression = pExpression;
        }
    }
}
