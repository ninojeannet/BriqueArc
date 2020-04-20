using System;
using System.Data.SqlTypes;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace BriqueArcWPF.Game
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        private Timer gameUser;
        private DispatcherTimer refreshTimer;
        private bool moveRight;
        private bool moveLeft;

        public Game()
        {
            InitializeComponent();

            gameUser = new Timer();
            gameUser.Interval = 1;
            gameUser.Elapsed += new ElapsedEventHandler(GameTimer_Elapsed);

            refreshTimer = new DispatcherTimer();
            refreshTimer.Interval = new TimeSpan(1000 / 30); //30 FPS
            refreshTimer.Tick += new EventHandler(RefreshTimer_Elapsed);

            moveRight = false;
            moveLeft = false;
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            Canvas.SetTop(bar, canvas.ActualHeight - 30);

            bar.Position = Convert.ToInt32((canvas.ActualWidth / 2) - (bar.ActualWidth / 2));

            Vector pos = ball.Position;
            pos.X = (canvas.ActualWidth / 2) - (ball.ActualWidth / 2);
            pos.Y = (canvas.ActualHeight / 2) - (ball.ActualHeight / 2);
            ball.Position = pos;

            this.Focus();
            gameUser.Start();
            refreshTimer.Start();
        }

        private void UserControl_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if(bar != null)
            {
                switch(e.Key)
                {
                    case System.Windows.Input.Key.Left:
                    case System.Windows.Input.Key.A:
                        moveLeft = true;
                        break;

                    case System.Windows.Input.Key.Right:
                    case System.Windows.Input.Key.D:
                        moveRight = true;
                        break;
                }
            }
        }

        private void UserControl_KeyUp(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (bar != null)
            {
                switch (e.Key)
                {
                    case System.Windows.Input.Key.Left:
                    case System.Windows.Input.Key.A:
                        moveLeft = false;
                        break;

                    case System.Windows.Input.Key.Right:
                    case System.Windows.Input.Key.D:
                        moveRight = false;
                        break;
                }
            }
        }

        private void GameTimer_Elapsed(object sender, ElapsedEventArgs args)
        {
            if (moveLeft)
                bar.Position -= 5;
            else if (moveRight)
                bar.Position += 5;


        }

        private void RefreshTimer_Elapsed(object sender, EventArgs args)
        {
            bar.Refresh();
            ball.Refresh();
        }
    }
}
