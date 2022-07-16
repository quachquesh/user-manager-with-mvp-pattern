using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UserManager.Models;
using UserManager.Views;

namespace UserManager.Presenters
{
    internal class UserPresenter
    {
        // Fields
        private IUserView view;
        private IUserRepository userRepository;
        private BindingSource usersBindingSource;
        private IEnumerable<UserModel> userList;

        // Constructor
        public UserPresenter(IUserView view, IUserRepository userRepository)
        {
            this.usersBindingSource = new BindingSource();
            this.view = view;
            this.userRepository = userRepository;
            // Subscribe event handler methods to view events
            this.view.SearchEvent += SearchUser;
            this.view.AddNewEvent += AddNewUser;
            this.view.EditEvent += LoadSelectedUserToEdit;
            this.view.DeleteEvent += DeleteSelectedUser;
            this.view.SaveEvent += SaveUser;
            this.view.CancelEvent += CancelAction;
            // Set users bindind source
            this.view.SetUserListBindingSource(usersBindingSource);
            // Load user list view
            LoadAllUserList();
            // Show view
            this.view.Show();
        }

        // Methods
        private async void LoadAllUserList()
        {
            userList = await userRepository.GetAll();
            usersBindingSource.DataSource = userList; // Set data source
        }

        private async void SearchUser(object sender, EventArgs e)
        {
            bool emptyValue = string.IsNullOrWhiteSpace(this.view.SearchValue);
            if (emptyValue == false)
            {
                userList = await userRepository.GetByName(this.view.SearchValue);
            } else
            {
                userList = await userRepository.GetAll();
            }
            usersBindingSource.DataSource = userList; // Set data source
        }

        private void AddNewUser(object sender, EventArgs e)
        {
            view.IsEdit = false;
        }

        private void LoadSelectedUserToEdit(object sender, EventArgs e)
        {
            var user = (UserModel)usersBindingSource.Current;
            view.Id = user.Id;
            view.UserName = user.Name;
            view.Email = user.Email;
            view.IsEdit = true;
        }

        private void SaveUser(object sender, EventArgs e)
        {
            var model = new UserModel();
            model.Id = view.Id;
            model.Name = view.UserName;
            model.Email = view.Email;
            try
            {
                new Common.ModelDataValidation().Validate(model);
                if (view.IsEdit)
                {
                    userRepository.Edit(model);
                    view.Message = "User edited successfully";
                }
                else
                {
                    userRepository.Add(model);
                    view.Message = "User added successfully";
                }
                view.IsSuccessful = true;
                LoadAllUserList();
                CleanViewFields();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = ex.Message;
            }
        }

        private void CleanViewFields()
        {
            view.Id = "";
            view.UserName = "";
            view.Email = "";
        }

        private void CancelAction(object sender, EventArgs e)
        {
            CleanViewFields();
        }

        private void DeleteSelectedUser(object sender, EventArgs e)
        {
            try
            {
                var user = (UserModel)usersBindingSource.Current;
                userRepository.Delete(user.Id);
                view.IsSuccessful = true;
                view.Message = "User deleted successfully";
                LoadAllUserList();
            }
            catch (Exception ex)
            {
                view.IsSuccessful = false;
                view.Message = "An error ocurred, could not delete user";
            }
        }
    }
}
