using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

///
/// Chunhe Qiao
///

namespace View
{
    /// <summary>
    /// Form Class
    /// A form for the main view where the user loads and selects images
    /// </summary>
    public partial class MainView : Form, IView<Dictionary<string, Image>>, IMainView
    {
        /// <summary>
        /// Class Constructor
        /// </summary>
        public MainView()
        {
            InitializeComponent();
        }

        /// DECLARE a field of type EventHandler for when the user wants to load a new file from disk, call it FileSelected
        public event EventHandler<string> FileSelected;
        /// DECLARE a field of type EventHandler for when the user selects an image from the thumbnails, call it ThumbnailClicked
        public event EventHandler<string> ThumbnailClicked;

        /// <summary>
        /// Public Method
        /// Shows the form
        /// </summary>
        public new void ShowDialog()
        {
            base.ShowDialog(null);
        }

        /// <summary>
        /// Public Method
        /// Tells the view that the model has been updated
        /// </summary>
        /// <param name="pData">The new model data</param>
        public void UpdateModelRepresentation(Dictionary<string, Image> pData)
        {
            // REMOVE existing controls:
            this.flowLayoutPanel1.Controls.Clear();

            // POPULATE layout with images:
            foreach (KeyValuePair<string, Image> image in pData)
            {

                PictureBox pictureBox = new PictureBox();
                pictureBox.Image = image.Value;
                pictureBox.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox.Tag = image.Key;
                pictureBox.Click += OnThumbnailClicked;

                this.flowLayoutPanel1.Controls.Add(pictureBox);

            }
        }

        /// <summary>
        /// Private Method
        /// When the load image from disk button is clicked
        /// </summary>
        /// <param name="sender">The originating object</param>
        /// <param name="e">Not Used</param>
        private void button1_Click(object sender, EventArgs e)
        {
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                OnFileSelected(this.openFileDialog1.FileName);
            }
        }

        /// <summary>
        /// Method
        /// Called to invoke the FileSelected event
        /// </summary>
        /// <param name="pPath">Where to load the file from</param>
        protected virtual void OnFileSelected(string pPath)
        {
            if (FileSelected != null)
                FileSelected.Invoke(this, pPath);
        }

        /// <summary>
        /// Method
        /// Called to invoke the ThumbnailClicked method
        /// </summary>
        /// <param name="pSender">The originating object</param>
        /// <param name="args">Not Used</param>
        protected virtual void OnThumbnailClicked(object pSender, EventArgs args)
        {
            if (pSender is PictureBox)
            {
                PictureBox pBox = (PictureBox)pSender;
                if (ThumbnailClicked != null)
                {
                    ThumbnailClicked.Invoke(this, pBox.Tag.ToString());
                }

            }
        }

        /// <summary>
        /// NOT USED
        /// </summary>
        /// <param name="sender">NOT USED</param>
        /// <param name="e">NOT USED</param>
        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {

        }
    }
}
