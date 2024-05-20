using System.Collections.Generic;
using System.Drawing;

/// 
/// Author: Matthew Bowman

///

namespace Controller
{
    /// <summary>
    /// Interface
    /// A Common implementation of the image controller classes
    /// </summary>
    public interface IControlImage
    {
        /// <summary>
        /// A method set to listen for a click event from the image view
        /// </summary>
        void OnImageTransformButtonClicked(object pSender, KeyValuePair<string, string> pTransformInfo);
        void OnImageViewLoaded(object pSender, string pImageID);
        void OnSaveImageButtonClicked(object pSender, KeyValuePair<string, string> pSaveInfo);
    }
}
