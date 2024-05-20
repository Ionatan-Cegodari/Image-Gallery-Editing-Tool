using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IImageView
    {
        event EventHandler<KeyValuePair<string, string>> ImageTransformButtonClicked;
        event EventHandler<string> ImageViewLoaded;
        event EventHandler<KeyValuePair<string, string>> SaveImageButtonClicked;
    }
}
