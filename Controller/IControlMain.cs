using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

///
/// Author: Matthew Bowman
///

namespace Controller
{
    /// <summary>
    /// Interface
    /// A Common implementation of the main controller classes
    /// </summary>
    public interface IControlMain
    {
        /// <summary>
        /// A method set to listen for an event from the main view related to loading a file from the disk
        /// </summary>
        void OnFileSelected(object pSender, string pPath);

        /// <summary>
        /// A method set to listen for an event from the main view related to clicking thumbnails
        /// </summary>
        void OnThumbnailClicked(object pSender, string pImageID);

    }
}
