using System;
using System.Collections.Generic;
using System.Drawing;

using Router;
using Model;
using Controller;
using System.Text.RegularExpressions;
using View;
using System.Linq;
using Main.Exceptions;
using System.Diagnostics;

///
/// Author: Ionatan Cegodari, Matthew Bowman
///

namespace Main
{
    internal class App : IApp
    {
        // DECLARE a field named _routeResolver of type IResolveRoutes:
        private IResolveRoutes _routeResolver;

        // DECLARE a field named _imagesModel of type IModel:
        private IModel<Dictionary<string, Image>> _imagesModel;

        // DECLARE a field named _activeControllers of type Dictionary<string, IControl>
        private Dictionary<string, IControl> _activeControllers;

        /// <summary>
        /// Class Constructor
        /// </summary>
        public App()
        {
            // INSTANTIATE classes:
            _routeResolver = new RouteResolver();
            _imagesModel = new ImagesModel();

            // SETUP required routes:
            _routeResolver.AddRoute("Main", new Regex("^/main/$"));
            _routeResolver.AddRoute("Image", new Regex("^/image/[0-9]*/$"));

            // SET initial route:
            OnRouteSelected(this, "/main/");
        }

        private void OnRouteSelected(object pSender, string pRoute)
        {
            string controllerName = _routeResolver.ResolveRoute(pRoute);

            CreateController(controllerName, pRoute);
        }

        private void CreateController(string pControllerName, string pRoute)
        {
            switch (pControllerName)
            {
                case "Main":
                    CreateMainController();
                    break;
                case "Image":
                    string imageID = pRoute.Split('/')[2];
                    CreateImageController(imageID);
                    break;
                default:
                    throw new ControllerDoesNotExistException();
            }
        }

        private void CreateMainController()
        {
            // INSTANTIATE View for MainController
            MainView concreteView = new MainView();

            IView<Dictionary<string, Image>> view = concreteView;
            IMainView mainView = concreteView;

            // INSTANTIATE Controller
            MainController concreteController = new MainController(_imagesModel, view);

            IControl controller = concreteController;
            IControlMain mainController = concreteController;

            // SUBSCRIBE Events
            mainView.ThumbnailClicked += mainController.OnThumbnailClicked;
            mainView.FileSelected += mainController.OnFileSelected;

            controller.RouteSelected += this.OnRouteSelected;
            _imagesModel.ModelUpdated += controller.OnModelUpdated;

            // DISPLAY the view to the user:
            controller.ShowView();
        }

        private void CreateImageController(string pImageID)
        {
            // INSTANTIATE View for MainController:
            ImageView concreteView = new ImageView(pImageID);

            IView<Dictionary<string, Image>> view = concreteView;
            IImageView imageView = concreteView;

            // INSTANTIATE Controller:
            ImageController concreteController = new ImageController(_imagesModel, view, pImageID);

            IControl controller = concreteController;
            IControlImage imageController = concreteController;

            // SUBSCRIBE Events
            imageView.ImageTransformButtonClicked += imageController.OnImageTransformButtonClicked;
            imageView.ImageViewLoaded += imageController.OnImageViewLoaded;
            imageView.SaveImageButtonClicked += imageController.OnSaveImageButtonClicked;

            _imagesModel.ModelUpdated += controller.OnModelUpdated;
            controller.RouteSelected += this.OnRouteSelected;

            // DISPLAY the view to the user:
            controller.ShowView();
        }
    }
}
