using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UserManager.Views
{
    public partial class UserView : Form, IUserView
    {
        // Fields
        private string message;
        private bool isEdit;
        private bool isSuccessful;

        // Constructor
        public UserView()
        {
            InitializeComponent();
            AssociateAndRaiseViewEvents();
            tabControl1.TabPages.Remove(tabUserDetail);
        }

        private void AssociateAndRaiseViewEvents()
        {
            btnSearch.Click += delegate { SearchEvent?.Invoke(this, EventArgs.Empty); };
            txtSearch.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                    SearchEvent?.Invoke(this, EventArgs.Empty);
            };
            // Add new
            btnAddNew.Click += delegate { 
                AddNewEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabListUser);
                tabControl1.TabPages.Add(tabUserDetail);
                tabUserDetail.Text = "Add new user";
            };
            // Edit
            btnEdit.Click += delegate {
                EditEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabListUser);
                tabControl1.TabPages.Add(tabUserDetail);
                tabUserDetail.Text = "Edit user";
            };
            // Save Changes
            btnSave.Click += delegate {
                SaveEvent?.Invoke(this, EventArgs.Empty);
                if(isSuccessful)
                {
                    tabControl1.TabPages.Remove(tabUserDetail);
                    tabControl1.TabPages.Add(tabListUser);
                }
                MessageBox.Show(Message);
            };
            txtName.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveEvent?.Invoke(this, EventArgs.Empty);
                    if (isSuccessful)
                    {
                        tabControl1.TabPages.Remove(tabUserDetail);
                        tabControl1.TabPages.Add(tabListUser);
                    }
                    MessageBox.Show(Message);
                }
            };
            txtEmail.KeyDown += (s, e) =>
            {
                if (e.KeyCode == Keys.Enter)
                {
                    SaveEvent?.Invoke(this, EventArgs.Empty);
                    if (isSuccessful)
                    {
                        tabControl1.TabPages.Remove(tabUserDetail);
                        tabControl1.TabPages.Add(tabListUser);
                    }
                    MessageBox.Show(Message);
                }
            };
            // Cancel
            btnCancel.Click += delegate
            {
                CancelEvent?.Invoke(this, EventArgs.Empty);
                tabControl1.TabPages.Remove(tabUserDetail);
                tabControl1.TabPages.Add(tabListUser);
            };
            // Delete
            btnDelete.Click += delegate {
                var result = MessageBox.Show("Are you sure you want to delete the selected user", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                if (result == DialogResult.Yes)
                {
                    DeleteEvent?.Invoke(this, EventArgs.Empty);
                    MessageBox.Show(Message);
                }
            };
        }

        public string Id { get => txtId.Text; set => txtId.Text = value; }
        public string UserName { get => txtName.Text; set => txtName.Text = value; }
        public string Email { get => txtEmail.Text; set => txtEmail.Text = value; }
        public string SearchValue { get => txtSearch.Text; set => txtSearch.Text = value; }
        public bool IsEdit { get => isEdit; set => isEdit = value; }
        public bool IsSuccessful { get => isSuccessful; set => isSuccessful = value; }
        public string Message { get => message; set => message = value; }

        public event EventHandler SearchEvent;
        public event EventHandler AddNewEvent;
        public event EventHandler EditEvent;
        public event EventHandler DeleteEvent;
        public event EventHandler SaveEvent;
        public event EventHandler CancelEvent;

        public void SetUserListBindingSource(BindingSource userList)
        {
            dataGridUser.DataSource = userList;
        }
    }
}
