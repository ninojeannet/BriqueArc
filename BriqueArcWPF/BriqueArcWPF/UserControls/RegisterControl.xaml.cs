using BriqueArcWPF.API.Models;
using BriqueArcWPF.APIHandler;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.UserControls
{
    /// <summary>
    /// Logique d'interaction pour RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public RegisterControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Créer un compte
        /// </summary>
        private void Register()
        {
            if (CheckPasswords() && CheckUsername())
            {
                User user = new User(username.Text,password.Password);
                API.APIHandler.StoreUser(user);
                SetLoginControl();
                error.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Vérifie que les mots de passes soient les mêmes et pas vide
        /// </summary>
        /// <returns>Le résultat</returns>
        private bool CheckPasswords()
        {

            if (password.Password != verification.Password)
            {
                error.Text = "Les mots de passes ne correspondent pas";
                error.Visibility = Visibility.Visible;
                return false;
            }

            if(password.Password == "")
            {
                error.Text = "Les mots de passes ne peuvent pas être vides !";
                error.Visibility = Visibility.Visible;
                return false;
            }
             
            return true;
        }

        /// <summary>
        /// Vérifie que le nom de compte n'existe pas déjà
        /// </summary>
        /// <returns>Le résultat</returns>
        private bool CheckUsername()
        {
            if (!API.APIHandler.UsernameAlreadyExists(username.Text))
                return true;

            error.Text = "Le nom de compte existe déjà !";
            error.Visibility = Visibility.Visible;
            return false;
        }

        /// <summary>
        /// Modifie le control actuel pour le control de login
        /// </summary>
        private void SetLoginControl()
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SetControl(MainWindow.Controls.Login);
        }

        /// <summary>
        /// Evenement Click du bouton de création de compte
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">Les arguments</param>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        /// <summary>
        /// Evenement Click du bouton retour
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">Les arguments</param>
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            SetLoginControl();
        }
    }
}
