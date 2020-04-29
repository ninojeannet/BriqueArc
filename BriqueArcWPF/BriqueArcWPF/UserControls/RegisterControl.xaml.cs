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
using System.Windows.Navigation;
using System.Windows.Shapes;

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
                
            }
        }

        private bool CheckPasswords()
        {
            if (password.Password == verification.Password)
                return true;

            error.Text = "Les mots de passes ne correspondent pas";
            error.Visibility = Visibility.Visible;
            return false;
        }

        private bool CheckUsername()
        {
            User currentUser = API.APIHandler.GetUser(username.Text, Tools.Encrypt(password.Password));
            return true;
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
