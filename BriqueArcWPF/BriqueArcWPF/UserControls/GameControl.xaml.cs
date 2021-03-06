﻿using BriqueArcWPF.API;
using BriqueArcWPF.API.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Security;
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
        /// <summary>
        /// Constructeur
        /// </summary>
        public GameControl()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Evenement Loaded
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="e">Les arguments</param>
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            game.Model.PropertyChanged += new PropertyChangedEventHandler(Game_PropertyChanged);

            UpdateScoreboard();
        }

        /// <summary>
        /// Evenement PropertyChanged du modèle du jeu
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="args">Les arguments</param>
        private void Game_PropertyChanged(object sender, PropertyChangedEventArgs args)
        {
            score.Content = "Score : " + game.Model.Points + "pts";

            if(game.Model.Points == 0)
                UpdateScoreboard();
        }

        /// <summary>
        /// Met à jour le tableau des scores
        /// </summary>
        private void UpdateScoreboard()
        {
            scoreboard.Items.Clear();
            foreach (Ranking ranking in API.APIHandler.GetScoreboard())
                scoreboard.Items.Add(ranking.User.Username + " : " + ranking.Score + "pts");
        }
    }
}
