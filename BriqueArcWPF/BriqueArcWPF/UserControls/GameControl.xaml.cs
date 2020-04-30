using BriqueArcWPF.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Logique d'interaction pour GameControl.xaml
    /// </summary>
    public partial class GameControl : UserControl
    {
        public GameControl()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            game.Model.PropertyChanged += new PropertyChangedEventHandler(Game_PropertyChanged);

            foreach (Ranking ranking in API.APIHandler.GetScoreboard())
                scoreboard.Items.Add(ranking.User.getUsername() + " : " + ranking.Score + "pts");
        }

        private void Game_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            score.Content = "Score : " + game.Model.Points + "pts";
        }
    }
}
