
using BriqueArcWPF.API.Models;
using BriqueArcWPF.API;

using System;
using System.Windows;

namespace BriqueArcWPF
{
    /// <summary>
    /// Logique d'interaction pour login_window.xaml
    /// </summary>
    public partial class login_window : Window
    {
        public login_window()
        {
            InitializeComponent();
        }

        

        private void Login(object sender, RoutedEventArgs e)
        {
           
            User currentUser = new User(username.Text, password.Text);
            if (API.APIHandler.UserExists(currentUser))
            {
                Console.WriteLine("login valid");
            }
            else
            {
                Console.WriteLine("login failed");
            }
        }

        private void Register(object sender, RoutedEventArgs e)
        {
        }


    }
}
