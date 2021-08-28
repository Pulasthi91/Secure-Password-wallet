using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PasswordGenerater.PasswordData;
using System.Windows;
using System.Windows.Input;

namespace PasswordGenerater
{
    class LoginViewModel : ViewModelBase
    {
        DataModelClass DataModel = new DataModelClass();
        Window LoginWindow;
        public LoginViewModel(Window LoginWindow)
        {
            this.LoginWindow = LoginWindow;
            LoginVisibility = Visibility.Visible;
            User = new usr_User();
        }

        private usr_User _User;

        public usr_User User
        {
            get { return _User; }
            set { _User = value; OnPropertyChanged("User"); }
        }

        private Visibility _LoginVisibility;

        public Visibility LoginVisibility
        {
            get { return _LoginVisibility; }
            set { _LoginVisibility = value; OnPropertyChanged("LoginVisibility"); }
        }


        private IEnumerable<usr_User> _Users;

        public IEnumerable<usr_User> Users
        {
            get { return _Users; }
            set { _Users = value; OnPropertyChanged("Users"); }
        }

        public ICommand LoginButton
        {
            get { return new RelayCommand(Login); }
        }
        public ICommand CancelButton
        {
            get { return new RelayCommand(Cancel); }
        }

        void Cancel()
        {
            User = new usr_User();
        }

        void Login()
        {

            try
            {
                if (DataModel.GetUser().Where(c => c.user_name == User.user_name && c.password == User.password).Count() == 1)
                {
                    LoginVisibility = Visibility.Hidden;
                    new MainWindow(LoginWindow).Show();

                }
                else
                    MessageBox.Show("Cannot Login Please Contact Pulasthi !!");
            }
            catch (Exception)
            {
                MessageBox.Show("Cannot Login Please Contact Pulasthi !!");
            }
        }

    }
}
