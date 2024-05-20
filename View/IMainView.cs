using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    public interface IMainView
    {
        event EventHandler<string> FileSelected;
        event EventHandler<string> ThumbnailClicked;
    }
}
