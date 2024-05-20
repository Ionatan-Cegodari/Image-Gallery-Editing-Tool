using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using View;

///
/// Author: Matthew Bowman
/// 

namespace Controller
{
    /// <summary>
    /// Class
    /// A class which controls the user's main view and image model
    /// </summary>
    public class MainController : IControl, IControlMain
    {
        // DECLARE an EventHandler to invoke whenever a route event needs to be invoked, call it RouteSelected:
        public event EventHandler<string> RouteSelected;

        // DECLARE an IModel to store the ImageModel instantiated later, call it _model
        IModel<Dictionary<string, Image>> _model;

        // DECLARE an IView to store the MainView instantiated later, call it _view
        IView<Dictionary<string, Image>> _view;

        /// <summary>
        /// Constructor
        /// Contains class setup
        /// </summary>
        /// <param name="pModel">The model to be utilised</param>
        /// <param name="pView">The view to be utilised</param>
        public MainController(IModel<Dictionary<string, Image>> pModel, IView<Dictionary<string, Image>> pView)
        {
            // ASSIGN the value of pModel to the _model field
            _model = pModel;

            // ASSIGN the value of pView to the _view field
            _view = pView;
        }

        public void OnFileSelected(object pSender, string pPath)
        {
            // CALL the method to load the image from disk
            _model.LoadImage(pPath);
        }

        public void OnModelUpdated(object pSender, Dictionary<string, Image> pImages)
        {
            // CALL the view to update its display
            _view.UpdateModelRepresentation(pImages);
        }

        public void OnThumbnailClicked(object pSender, string pImageID)
        {
            OnRouteSelected($"/image/{pImageID}/");
        }

        public void ShowView()
        {
            // Show the view to the user:
            _view.ShowDialog();
        }

        protected virtual void OnRouteSelected(string pRoute)
        {
            if (RouteSelected != null) {
                RouteSelected.Invoke(this, pRoute);
            }
        }
    }
}
