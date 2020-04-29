using BriqueArcWPF.API;
using BriqueArcWPF.API.Models;
using BriqueArcWPF.APIHandler;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.UserControls
{
    /// <summary>
    /// Logique d'interaction pour LoginControl.xaml
    /// </summary>
    public partial class LoginControl : UserControl
    {
        public LoginControl()
        {
            InitializeComponent();
        }

        private void Login()
        {
            if (API.APIHandler.ConnectUser(username.Text, password.Password))
            {
                MainWindow mainWindow = (MainWindow) Window.GetWindow(this);
                mainWindow.SetControl(MainWindow.Controls.Game);
                error.Visibility = Visibility.Hidden;
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }

        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SetControl(MainWindow.Controls.Register);
        }
    }
}
