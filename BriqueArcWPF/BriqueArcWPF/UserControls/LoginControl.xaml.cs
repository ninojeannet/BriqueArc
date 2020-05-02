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
        /// <summary>
        /// Constructeur
        /// </summary>
        public LoginControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Connecte un utilisateur
        /// </summary>
        private void Login()
        {
            User user = API.APIHandler.ConnectUser(username.Text, password.Password);
            if (user != null)
            {
                AuthenticatedUser.GetInstance().SetUser(user);
                MainWindow mainWindow = (MainWindow) Window.GetWindow(this);
                mainWindow.SetControl(MainWindow.Controls.Game);
                error.Visibility = Visibility.Hidden;
            }
            else
            {
                error.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// Evenement Click du bouton de login
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">Les arguments</param>
        private void loginButton_Click(object sender, RoutedEventArgs e)
        {
            Login();
        }

        /// <summary>
        /// Evenement Click du bouton de création de compte
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">Les arguments</param>
        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SetControl(MainWindow.Controls.Register);
        }
    }
}
