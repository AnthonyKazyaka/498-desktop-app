using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Testing_WPF_002
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string userLogin;
        private string userPassword;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Login_Click_1(object sender, RoutedEventArgs e)
        {
            userLogin = UserField.Text;
            userPassword = passwordBox1.Password;
            TinCan.ConnectToTinCan(userLogin, userPassword);
            TinCan.SendStatement(userLogin);
        }
    }
}
