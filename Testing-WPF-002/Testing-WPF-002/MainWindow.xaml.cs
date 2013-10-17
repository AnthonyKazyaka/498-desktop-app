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
        private NotifyIcon trayIcon;
        private System.Windows.Forms.ContextMenu trayMenu;

        private bool _isUserLoggedIn = false; 

        private FocusedWindowManager _focusedWindowManager = new FocusedWindowManager();

        public MainWindow()
        {
            InitializeComponent();
            
            trayIcon = new NotifyIcon();
            trayIcon.Icon = new System.Drawing.Icon("techSmith-01.ico");
            trayIcon.Visible = true;

            trayMenu = new System.Windows.Forms.ContextMenu();
            trayMenu.MenuItems.Add(0, new System.Windows.Forms.MenuItem("Show", new System.EventHandler(Show_Click)));
            trayMenu.MenuItems.Add(1, new System.Windows.Forms.MenuItem("Exit", new System.EventHandler(Exit_Click)));

            trayIcon.ContextMenu = trayMenu;

        }

        private void Login_Click_1(object sender, RoutedEventArgs e)
        {
            LogIntoTinCan();
            //TinCan.SendStatement(userLogin);            
        }

        protected void Show_Click(Object sender, System.EventArgs e)
        {
            ReviveWindow();
        }

        protected void Exit_Click(Object sender, System.EventArgs e)
        {
            Close();
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

        private void ReviveWindow()
        {
            this.Show();
            this.WindowState = System.Windows.WindowState.Normal;
        }

        private void MinimizeWindow()
        {
            this.WindowState = System.Windows.WindowState.Minimized;
            this.Hide();
        }

        private void Window_Closed(object sender, EventArgs e)
        {
            this.trayIcon.Visible = false;
        }
    }
}
