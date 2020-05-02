using BriqueArcWPF.Game.State;
using BriqueArcWPF.Game.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace BriqueArcWPF.Game.Models
{
    /// <summary>
    /// Modèle du jeu
    /// </summary>
    class Game
    {
        private Size size;
        private Views.Ball ball;
        private Views.Bar bar;
        private List<Views.Brick> bricks;
        private GameState_I state;
        private int points;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Game()
        {
            size = new Size(500, 500);
            ball = new Views.Ball();
            bar = new Views.Bar();
            state = new StartState(this);
            points = 0;
        }

        /// <summary>
        /// Score actuel
        /// </summary>
        public int Points
        {
            get { return points; }
            set 
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        /// <summary>
        /// Vue de la balle
        /// </summary>
        public Views.Ball Ball
        {
            get { return this.ball; }
        }

        /// <summary>
        /// Vue de la barre
        /// </summary>
        public Views.Bar Bar
        {
            get { return this.bar; }
        }

        public List<Views.Brick> Bricks
        {
            get { return this.bricks; }
            set { this.bricks = value; }
        }

        /// <summary>
        /// Vues des briques
        /// </summary>
        public Size Size
        {
            get { return this.size; }
        }

        /// <summary>
        /// Etat actuel de la partie
        /// </summary>
        public GameState_I State
        {
            set { state = value; }
        }

        /// <summary>
        /// Met à jour la partie
        /// </summary>
        public void Update()
        {
            bar.Focus();
            state.Update();
        }

        /// <summary>
        /// Touche enfoncée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyDown(Key key)
        {
            state.KeyDown(key);
        }

        /// <summary>
        /// Touche lâchée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyUp(Key key)
        {
            state.KeyUp(key);
        }

        /// <summary>
        /// Met à jour l'interface graphique
        /// </summary>
        public void Refresh()
        {
            ChangeSize(size.Width, size.Height);
        }

        /// <summary>
        /// Modifie la taille des éléments
        /// </summary>
        /// <param name="width">La nouvelle largeur</param>
        /// <param name="height">La nouvelle hauteur</param>
        public void ChangeSize(double width, double height)
        {
            double widthDiff = width / size.Width;
            double heightDiff = height / size.Height;

            double brickWidth = width / 8;
            double brickHeight = height / 20;

            double ballSize = (width < height) ? width / 100 : height / 100;
            double ballPositionX = ball.Position.X * widthDiff;
            double ballPositionY = ball.Position.Y * heightDiff;

            double barWidth = width / 10;
            double barHeight = height / 50;
            double barPositionX = bar.Position.X * widthDiff;
            double barPositionY = height - (2 * barHeight);

            foreach (Views.Brick brick in bricks)
            {
                double brickPositionX = brick.Position.X * (brickWidth / brick.Size.Width);
                double brickPositionY = brick.Position.Y * (brickHeight / brick.Size.Height);

                brick.SetPosition(brickPositionX, brickPositionY);
                brick.SetSize(brickWidth, brickHeight);
                brick.Refresh();
            }

            ball.SetSize(ballSize, ballSize);
            ball.SetPosition(ballPositionX, ballPositionY);
            ball.Direction = new Vector(ball.Direction.X * widthDiff, ball.Direction.Y * heightDiff);
            ball.Refresh();

            bar.SetSize(barWidth, barHeight);
            bar.SetPosition(barPositionX, barPositionY);
            bar.SetDirection(bar.Direction.X * widthDiff, bar.Direction.Y * heightDiff);
            bar.Refresh();

            size = new Size(width, height);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        /// <summary>
        /// Lève l'évènement PropertyChanged
        /// </summary>
        /// <param name="name"></param>
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
