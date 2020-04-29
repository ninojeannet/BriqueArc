using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.UserControls
{
    /// <summary>
    /// Logique d'interaction pour RegisterControl.xaml
    /// </summary>
    public partial class RegisterControl : UserControl
    {
        public RegisterControl()
        {
            InitializeComponent();
        }

        private void Register()
        {
            if (CheckPasswords() && CheckUsername())
            {
                API.APIHandler.RegisterUser(username.Text, password.Password);
                SetLoginControl();
                error.Visibility = Visibility.Hidden;
            }
        }

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

        private bool CheckUsername()
        {
            if (!API.APIHandler.UsernameAlreadyExists(username.Text))
                return true;

            error.Text = "Le nom de compte existe déjà !";
            error.Visibility = Visibility.Visible;
            return false;
        }

        private void SetLoginControl()
        {
            MainWindow mainWindow = (MainWindow)Window.GetWindow(this);
            mainWindow.SetControl(MainWindow.Controls.Login);
        }

        private void registerButton_Click(object sender, RoutedEventArgs e)
        {
            Register();
        }

        private void backButton_Click(object sender, RoutedEventArgs e)
        {
            SetLoginControl();
        }
    }
}
