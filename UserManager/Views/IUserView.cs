using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager.Views
{
    public interface IUserView
    {
        // Properties - Fields
        string Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }

        string SearchValue { get; set; }
        bool IsEdit { get; set; }
        bool IsSuccessful { get; set; }
        string Message { get; set; }

        // Events
        event EventHandler SearchEvent;
        event EventHandler AddNewEvent;
        event EventHandler EditEvent;
        event EventHandler DeleteEvent;
        event AsyncEventHandler SaveEvent;
        event EventHandler CancelEvent;

        // Methods
        void SetUserListBindingSource(BindingSource userList);
        void Show();
    }
}
