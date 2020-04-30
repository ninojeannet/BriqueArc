using BriqueArcWPF.Game.State;
using BriqueArcWPF.Game.Views;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Input;

namespace BriqueArcWPF.Game.Models
{
    class Game
    {
        private Size size;
        private Views.Ball ball;
        private Views.Bar bar;
        private List<Views.Brick> bricks;
        private GameState_I state;
        private int points;

        public Game()
        {
            size = new Size(500, 500);
            ball = new Views.Ball();
            bar = new Views.Bar();
            state = new StartState(this);
            points = 0;
        }

        public int Points
        {
            get { return points; }
            set 
            {
                points = value;
                OnPropertyChanged("Points");
            }
        }

        public Views.Ball Ball
        {
            get { return this.ball; }
        }

        public Views.Bar Bar
        {
            get { return this.bar; }
        }

        public List<Views.Brick> Bricks
        {
            get { return this.bricks; }
            set { this.bricks = value; }
        }

        public Size Size
        {
            get { return this.size; }
        }

        public GameState_I State
        {
            set { state = value; }
        }

        public void Update()
        {
            bar.Focus();
            state.Update();
        }

        public void KeyDown(Key key)
        {
            state.KeyDown(key);
        }

        public void KeyUp(Key key)
        {
            state.KeyUp(key);
        }

        public void Refresh()
        {
            ChangeSize(size.Width, size.Height);
        }

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
        private void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
