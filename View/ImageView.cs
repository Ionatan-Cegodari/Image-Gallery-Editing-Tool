using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

///
/// Author: Chunhe Qiao
///

namespace View
{
    /// <summary>
    /// Form Class
    /// A form for  viewing and manipulating the image
    /// </summary>
    public partial class ImageView : Form, IView<Dictionary<string, Image>>, IImageView
    {
        // DECLARE a field of type EventHandler for when the user transforms an image, call it ImageTransformButtonClicked
        public event EventHandler<KeyValuePair<string, string>> ImageTransformButtonClicked;
        // DECLARE a field of type EventHandler for when the user loads the view, call it ImageViewLoaded
        public event EventHandler<string> ImageViewLoaded;
        // DECLARE a field of type EventHandler for when the user saves an image, call it SaveImageButtonClicked
        public event EventHandler<KeyValuePair<string, string>> SaveImageButtonClicked;

        // DECLARE a field of type string to hold the image identifier that the view is presenting, call it _imageID
        private string _imageID;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pImageID">The selected image's identifier</param>
        public ImageView(string pImageID)
        {
            _imageID = pImageID;
            InitializeComponent();
        }

        /// <summary>
        /// Public Method
        /// Updated the view with new images, primarily called by the controller
        /// </summary>
        /// <param name="pData"></param>
        public void UpdateModelRepresentation(Dictionary<string, Image> pData)
        {
            // CREATE a new PictureBox and show it to the user:
            panel1.Controls.Clear();

            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = pData[_imageID];
            pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;

            panel1.Controls.Add(pictureBox);
        }

        void IView<Dictionary<string, Image>>.ShowDialog()
        {
            OnImageViewLoaded(this._imageID);
            base.ShowDialog(null);
        }

        /// <summary>
        /// Method
        /// Called to invoke the ImageViewLoaded event
        /// </summary>
        /// <param name="pImageID">The image identifier</param>

        protected virtual void OnImageViewLoaded(string pImageID)
        {
            if (this.ImageViewLoaded != null)
            {
                this.ImageViewLoaded.Invoke(this, pImageID);
            }
        }

        /// <summary>
        /// Method
        /// Called to invoke the ImageTransformButtonClicked event
        /// </summary>
        /// <param name="pTransformData">The transformation data including the transform to do and the image id respectively</param>
        protected virtual void OnImageTransformButtonClicked(KeyValuePair<string, string> pTransformData)
        {
            if (this.ImageTransformButtonClicked != null)
            {
                this.ImageTransformButtonClicked.Invoke(this, pTransformData);
            }
        }

        /// <summary>
        /// Method
        /// Called to invoke the SaveImageButtonClicked event
        /// </summary>
        /// <param name="pSaveInfo">Where to save the file</param>
        protected virtual void OnSaveImageButtonClicked(KeyValuePair<string, string> pSaveInfo)
        {
            if (this.SaveImageButtonClicked != null)
            {
                this.SaveImageButtonClicked.Invoke(this, pSaveInfo);
            }
        }

        /// <summary>
        /// Private Method
        /// Called when the rotate button is clicked
        /// </summary>
        /// <param name="sender">Where the event originiated</param>
        /// <param name="e">Not used</param>
        private void button1_Click(object sender, EventArgs e)
        {
            OnImageTransformButtonClicked(new KeyValuePair<string, string>("Rotate", this._imageID));
        }

        /// <summary>
        /// Private Method
        /// Called when the flip button is clicked
        /// </summary>
        /// <param name="sender">Where the event originated</param>
        /// <param name="e">Not used</param>
        private void button2_Click(object sender, EventArgs e)
        {
            OnImageTransformButtonClicked(new KeyValuePair<string, string>("Flip", this._imageID));
        }

        /// <summary>
        /// Private Method
        /// Called when the save image button is clicked
        /// </summary>
        /// <param name="sender">Where the event originated</param>
        /// <param name="e">Not used</param>
        private void button3_Click(object sender, EventArgs e)
        {
            if (this.saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OnSaveImageButtonClicked(new KeyValuePair<string, string>(this.saveFileDialog1.FileName, this._imageID));
            }
        }
    }
}
