using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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
using System.Windows.Forms;
using System.Drawing;
using System.Windows.Threading;


namespace Testing_WPF_002
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        #region External Methods

        [DllImport("user32.dll")]
        private static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowText(int hWnd, StringBuilder text, int count);

        #endregion


        private string userLogin;
        private string userPassword;

        private bool _isUserLoggedIn = false; 

        private FocusedWindowManager _focusedWindowManager = new FocusedWindowManager();

        //private System.Windows.Forms.NotifyIcon trayIcon;

        public MainWindow()
        {
            InitializeComponent();

            /*this.trayIcon = new System.Windows.Forms.NotifyIcon();
            this.trayIcon.Icon = new System.Drawing.Icon("techSmith-01.ico");
            this.trayIcon.Visible = true;
            */

        }

        private void Login_Click_1(object sender, RoutedEventArgs e)
        {
            LogIntoTinCan();
            //TinCan.SendStatement(userLogin);            
        }

        private void LogIntoTinCan()
        {
            userLogin = UserField.Text;
            userPassword = passwordBox1.Password;
            TinCan.ConnectToTinCan(userLogin, userPassword);
            _isUserLoggedIn = true;
            _focusedWindowManager.StartWatching();
            UserField.Clear();
            passwordBox1.Clear();
            MinimizeWindow();
        }

        private void MinimizeWindow()
        {
            this.WindowState = System.Windows.WindowState.Minimized;
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            //this.trayIcon.Visible = false;
        }
    }
}
