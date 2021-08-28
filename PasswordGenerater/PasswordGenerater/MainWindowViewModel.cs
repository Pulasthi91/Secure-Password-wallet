using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using PasswordGenerater.PasswordData;
using System.Windows;

namespace PasswordGenerater
{
    class MainWindowViewModel : ViewModelBase
    {
        DataModelClass DataModel = new DataModelClass();

        #region Constructor
        public MainWindowViewModel()
        {
            New();
        }
        #endregion

        #region Properties
        private IEnumerable<z_AccountPassword> _AccountPassword;
        public IEnumerable<z_AccountPassword> AccountPassword
        {
            get { return _AccountPassword; }
            set { _AccountPassword = value; OnPropertyChanged("AccountPassword"); }
        }

        private z_AccountPassword _CurrentAccountPassword;
        public z_AccountPassword CurrentAccountPassword
        {
            get { return _CurrentAccountPassword; }
            set { _CurrentAccountPassword = value; OnPropertyChanged("CurrentAccountPassword"); }
        }

        private usr_User _User;

        public usr_User User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged("User"); }
        }

        private string _OldPassword;

        public string OldPassword
        {
            get { return _OldPassword; }
            set { _OldPassword = value; OnPropertyChanged("OldPassword"); }
        }

        private string _NewPassword;

        public string NewPassword
        {
            get { return _NewPassword; }
            set { _NewPassword = value; OnPropertyChanged("NewPassword"); }
        }

        private string _ConfirmPassword;

        public string ConfirmPassword
        {
            get { return _ConfirmPassword; }
            set { _ConfirmPassword = value; OnPropertyChanged("ConfirmPassword"); }
        }
        #endregion

        #region Buttons
        public ICommand ChangePasswordButton
        {
            get { return new RelayCommand(ChangePassword); }
        }

        public ICommand SaveButton
        {
            get { return new RelayCommand(Save); }
        }

        public ICommand DeleteButton
        {
            get { return new RelayCommand(Delete); }
        }

        public ICommand NewButton
        {
            get { return new RelayCommand(New); }
        }
        #endregion

        #region Methods
        void ChangePassword()
        {

            if (NewPassword == ConfirmPassword && OldPassword == User.password)
            {
                User.password = NewPassword;
                if (DataModel.UpdateUser(User))
                    MessageBox.Show("Changed Successfully");
                else
                    MessageBox.Show("Changed Fail");
            }
            else
            {
                if (DataModel.UpdateUser(User))
                    MessageBox.Show("Only User Name Changed");
            }
        }

        void New()
        {
            CurrentAccountPassword = new z_AccountPassword();
            RefreshAccountPassword();
            User = DataModel.GetUser().FirstOrDefault();
        }

        void Save()
        {
            if (AccountPassword.Where(c => c.password_id == CurrentAccountPassword.password_id).Count() == 1)
            {
                if (DataModel.UpdateAccountPassword(CurrentAccountPassword))
                    MessageBox.Show("Updated Successfully");
                else
                    MessageBox.Show("Updated Fail");
            }
            else
            {
                CurrentAccountPassword.is_delete = false;
                if (DataModel.SaveAccountPassword(CurrentAccountPassword))
                    MessageBox.Show("Saved Successfully");
                else
                    MessageBox.Show("Updated Fail");
            }

            New();
        }

        void Delete()
        {
            if (DataModel.DeleteAccountPassword(CurrentAccountPassword))
            {
                MessageBox.Show("Deleted Successfully");
                New();
            }
        }

        void RefreshAccountPassword()
        {
            AccountPassword = DataModel.GetAccountPassword().Where(c => c.is_delete == false);
        }
        #endregion
    }
}
