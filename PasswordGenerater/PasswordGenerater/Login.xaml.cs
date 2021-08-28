using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace PasswordGenerater
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        LoginViewModel ViewModel;
        public Login()
        {

            ViewModel = new LoginViewModel(this);
            InitializeComponent();
            Loaded += (s, e) => { DataContext = ViewModel; };
        }

        private void Rectangle_MouseLeftButtonDown_1(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }

        private void CloseBtn_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            ViewModel.User.password = pass.Password;
            pass.Password = "";

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            pass.Password = "";
        }
    }
}
