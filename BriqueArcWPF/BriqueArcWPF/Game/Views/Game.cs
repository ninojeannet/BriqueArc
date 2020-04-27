using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;

namespace BriqueArcWPF.Game.Views
{
    class Game : Canvas
    {
        private Models.Game model;
        private DispatcherTimer timer;

        public Game()
        {
            model = new Models.Game();

            timer = new DispatcherTimer();
            timer.Interval = new TimeSpan(0, 0, 0, 0, 1);

            RegisterEvents();

            timer.Start();
        }

        private void RegisterEvents()
        {
            this.KeyDown += new KeyEventHandler(Game_KeyDown);
            this.KeyUp += new KeyEventHandler(Game_KeyUp);
            this.SizeChanged += new SizeChangedEventHandler(Game_SizeChanged);
            this.timer.Tick += new EventHandler(Game_Update);
        }

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

        private void Game_KeyDown(object sender, KeyEventArgs args)
        {
            model.KeyDown(args.Key);
        }

        private void Game_KeyUp(object sender, KeyEventArgs args)
        {
            model.KeyUp(args.Key);
        }

        private void Game_SizeChanged(object sender, SizeChangedEventArgs args)
        {
            model.ChangeSize(args.NewSize.Width, args.NewSize.Height);
        }
    }
}
