using BriqueArcWPF.Game.Views;
using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Threading;

namespace BriqueArcWPF.Game
{
    /// <summary>
    /// Logique d'interaction pour Game.xaml
    /// </summary>
    public partial class Game : UserControl
    {
        private DispatcherTimer refreshTimer;
        private List<Brick> bricks;

        public Game()
        {
            InitializeComponent();

            refreshTimer = new DispatcherTimer();
            refreshTimer.Interval = new TimeSpan(0, 0, 0, 0, 1000 / 60);
            refreshTimer.Tick += new EventHandler(RefreshTimer_Elapsed);

            bricks = BrickCreator.SchemaBlock();
            foreach (Brick brick in bricks)
            {
                this.canvas.Children.Add(brick);
            }
        }

        private void UserControl_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
            bar.SetPosition((canvas.ActualWidth / 2) - (bar.ActualWidth / 2), canvas.ActualHeight - 30);
            ball.SetPosition((canvas.ActualWidth / 2) - (ball.ActualWidth / 2), (canvas.ActualHeight / 2) - (ball.ActualHeight / 2));
            ball.SetDirection(3, 3);

            this.Focus();
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
                        bar.SetDirection(-5, 0);
                        break;

                    case System.Windows.Input.Key.Right:
                    case System.Windows.Input.Key.D:
                        bar.SetDirection(5, 0);
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
                    case System.Windows.Input.Key.Right:
                    case System.Windows.Input.Key.D:
                        bar.SetDirection(0, 0);
                        break;
                }
            }
        }

        private void RefreshTimer_Elapsed(object sender, EventArgs args)
        {
            bar.Update();
            ball.Update();

            foreach (Brick brick in bricks)
            {
                brick.Update();
            }

            CollisionManager.CheckCollision(canvas, bar, ball, bricks, this.ActualHeight, this.ActualWidth);

            foreach (Brick brick in bricks)
            {
                brick.Refresh();
            }

            bar.Refresh();
            ball.Refresh();
        }

        private void canvas_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double brickWidth = this.ActualWidth / 8;
            double brickHeight = this.ActualHeight / 20;
            double ballSize = (ActualWidth < ActualHeight) ? ActualWidth / 100 : ActualHeight / 100;
            double barWidth = this.ActualWidth / 10;
            double barHeight = this.ActualHeight / 20;
            double barPositionX = this.ActualWidth * (barWidth / bar.Size.Width);
            double barPositionY = this.ActualHeight - (2 * barHeight);

            foreach (Brick brick in bricks)
            {
                double widthDiff = brickWidth / brick.Size.Width;
                double heigthDiff = brickHeight / brick.Size.Height;

                brick.SetSize(brickWidth, brickHeight);
                brick.SetPosition(brick.Position.X * widthDiff, brick.Position.Y * heigthDiff);
            }

            ball.SetSize(ballSize, ballSize);

            bar.SetSize(barWidth, barHeight);
            bar.SetPosition(barPositionX, barPositionY);
        }
    }
}
