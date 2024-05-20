using System;
using System.Collections.Generic;
using System.Drawing;

///
/// Author: Matthew Bowman
///

namespace Controller
{
    /// <summary>
    /// Interface
    /// A Common implementation of the controller classes
    /// </summary>
    public interface IControl
    {
        /// <summary>
        /// An event handler for when a route event needs to be fired
        /// </summary>
        event EventHandler<string> RouteSelected;

        /// <summary>
        /// Method
        /// Shows the view to the user
        /// </summary>
        void ShowView();

        /// <summary>
        /// A method for when the model linked to the controller is updated
        /// </summary>
        void OnModelUpdated(object pSender, Dictionary<string, Image> pImages);
    }
}
