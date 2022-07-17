using System;
using System.Runtime.InteropServices;
using System.Threading.Tasks;

namespace UserManager.Views
{
    [Serializable]
    [ComVisible(true)]
    public delegate Task AsyncEventHandler(object sender, EventArgs e);
}
