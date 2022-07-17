using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManager.Views;
using UserManager.Presenters;
using UserManager.Models;
using UserManager._Repositories;

namespace UserManager
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            IUserView view = new UserViewMaterial();
            IUserRepository repository = new UserRespository();
            new UserPresenter(view, repository);
            Application.Run((Form)view);
        }
    }
}
