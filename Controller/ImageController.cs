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
    public class ImageController : IControl, IControlImage
    {
        // DECLARE an EventHandler to invoke whenever a route event needs to be invoked, call it RouteSelected:
        public event EventHandler<string> RouteSelected;

        // DECLARE an IModel to store the ImageModel instantiated later, call it _model:
        private IModel<Dictionary<string, Image>> _model;

        // DECLARE an IView to store the ImageView instantiated later, call it _view:
        private IView<Dictionary<string, Image>> _view;

        // DECLARE a string to store the selected image identifier, call it _imageID:
        private string _imageID;

        /// <summary>
        /// Constructor
        /// Contains class setup
        /// </summary>
        /// <param name="pModel">The model to be utilised</param>
        /// <param name="pView">The view to be utilised</param>
        /// <param name="pImageID">The selected image's ID number</param>
        public ImageController(IModel<Dictionary<string, Image>> pModel, IView<Dictionary<string, Image>> pView, string pImageID)
        {
            // ASSIGN the value of pModel to the _model field:
            _model = pModel;

            // ASSIGN the value of pView to the _view field:
            _view = pView;

            // ASSIGN the value of pImageID to _imageID;
            _imageID = pImageID;
        }

        public void OnImageTransformButtonClicked(object pSender, KeyValuePair<string, string> pTransformInfo)
        {
            // CALL the transform method in the model:
            _model.TransformImage(pTransformInfo.Key, pTransformInfo.Value);
        }

        public void OnModelUpdated(object pSender, Dictionary<string, Image> pImages)
        {
            // CALL the view to update its display
            _view.UpdateModelRepresentation(pImages);
        }

        public void OnImageViewLoaded(object pSender, string pImageID)
        {
            OnModelUpdated(this, _model.ImagesDict);
        }

        public void OnSaveImageButtonClicked(object pSender, KeyValuePair<string, string> pSaveInfo)
        {
            _model.SaveImage(pSaveInfo.Key, pSaveInfo.Value);
        }

        public void ShowView()
        {
            // SHOW the view to the user:
            _view.ShowDialog();
        }
    }
}
