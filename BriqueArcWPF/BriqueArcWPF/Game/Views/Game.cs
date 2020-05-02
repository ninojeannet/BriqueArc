using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace BriqueArcWPF.Game.Views
{
    /// <summary>
    /// Vue du jeu
    /// </summary>
    class Game : Canvas
    {
        private Models.Game model;
        private DispatcherTimer timer;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Game()
        {
            model = new Models.Game();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            RegisterEvents();

            timer.Start();
        }

        /// <summary>
        /// Enregistre les envents de l'objet
        /// </summary>
        private void RegisterEvents()
        {
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            this.KeyUp += new KeyEventHandler(Game_KeyUp);
            this.SizeChanged += new SizeChangedEventHandler(Game_SizeChanged);
            this.timer.Tick += new EventHandler(Game_Update);
        }

        /// <summary>
        /// Evenement tick du timer
        /// </summary>
        /// <param name="sender">L'envoyeur</param>
        /// <param name="args">Les arguments</param>
        private void Game_Update(object sender, EventArgs args)
        {
            model.Update();

            Children.Clear();
            Children.Add(model.Ball);
            Children.Add(model.Bar);

            foreach(Brick brick in model.Bricks)
            {
                Children.Add(brick);
            }
        }

        /// <summary>
        /// Le modèle du jeu
        /// </summary>
        public Models.Game Model
        {
            get { return model; }
        }

        /// <summary>
        /// Evénement KeyDown
        /// </summary>
        /// <param name="sender">l'envoyeur</param>
        /// <param name="args">Les arguments</param>
        private void Game_KeyDown(object sender, KeyEventArgs args)
        {
            model.KeyDown(args.Key);
        }

        /// <summary>
        /// Evénement KeyUp
        /// </summary>
        /// <param name="sender">l'envoyeur</param>
        /// <param name="args">Les arguments</param>
        private void Game_KeyUp(object sender, KeyEventArgs args)
        {
            model.KeyUp(args.Key);
        }

        /// <summary>
        /// Evénement ChangeSize
        /// </summary>
        /// <param name="sender">l'envoyeur</param>
        /// <param name="args">Les arguments</param>
        private void Game_SizeChanged(object sender, SizeChangedEventArgs args)
        {
            model.ChangeSize(args.NewSize.Width, args.NewSize.Height);
        }
    }
}
