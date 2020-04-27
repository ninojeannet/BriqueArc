
using BriqueArcWPF.API.Models;
using BriqueArcWPF.API;

using System;
using System.Windows;
using BriqueArcWPF.APIHandler;

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
           
            User currentUser = API.APIHandler.GetUser(username.Text, Tools.Encrypt(password.Text));

            if (currentUser != null)
            {
                Console.WriteLine("login valid");
            }
            else
            {
                Console.WriteLine("login failed");
            }
            API.APIHandler.FetchRankings();

            //User tmp = new User("test", "test");
            //API.APIHandler.StoreUser(tmp);

            //king tmp = new Ranking(10, 44, null);
            //API.APIHandler.StoreRanking(tmp);

        }

        private void Register(object sender, RoutedEventArgs e)
        {
        }


    }
}
