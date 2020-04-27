using BriqueArcWPF.Game.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game
{
    class CollisionManager
    {
        public static void CheckCollision(Canvas canvas, Bar bar, Ball ball, List<Brick> bricks, double gameHeight, double gameWidth)
        {
            if (ball.Position.Y + ball.Size.Height >= gameHeight || ball.Position.Y <= 0)
                ball.SetDirection(ball.Direction.X, ball.Direction.Y * -1);
            if (ball.Position.X + ball.Size.Width >= gameWidth || ball.Position.X <= 0)
                ball.SetDirection(ball.Direction.X * -1, ball.Direction.Y);

            if (ball.Position.Y + ball.Size.Height >= bar.Position.Y && ball.Position.X <= bar.Position.X + bar.Size.Width && ball.Position.X + ball.Size.Width >= bar.Position.X && ball.Position.Y <= bar.Position.Y + bar.Size.Height)
            {
                double height = (bar.Position.Y + bar.Size.Height / 2) - (ball.Position.Y + ball.Size.Height / 2);
                double width = (bar.Position.X + bar.Size.Width / 2) - (ball.Position.X + ball.Size.Width / 2);
                double angle = Math.Atan2(width, height) - Math.PI / 2;
                if (angle < 0)
                    angle += 2 * Math.PI;

                ball.Direction = new Vector(Math.Cos(angle) * ball.Direction.Length * -1, Math.Sin(angle) * ball.Direction.Length);
            }

            if (bar.Position.X < 0)
            {
                bar.SetPosition(0, bar.Position.Y);
                bar.SetDirection(0, 0);
            }
            else if (bar.Position.X + bar.Size.Width > gameWidth)
            {
                bar.SetPosition(gameWidth - bar.Size.Width, bar.Position.Y);
                bar.SetDirection(0, 0);
            }

            for (int i = 0; i < bricks.Count; i++)
            {
                Brick brick = bricks[i];
                if (ball.Position.X + ball.Size.Width >= brick.Position.X && ball.Position.X <= brick.Position.X + brick.Size.Width && ball.Position.Y + ball.Size.Width >= brick.Position.Y && ball.Position.Y <= brick.Position.Y + brick.Size.Height)
                {
                    double height = (brick.Position.Y + brick.Size.Height / 2) - (ball.Position.Y + ball.Size.Height / 2);
                    double width = (brick.Position.X + brick.Size.Width / 2) - (ball.Position.X + ball.Size.Width / 2);
                    double angle = Math.Atan(height / width);
                    double angleBox = Math.Atan(brick.Size.Height / brick.Size.Width);

                    if (Math.Abs(angle) > angleBox)
                        ball.SetDirection(ball.Direction.X, ball.Direction.Y * -1);
                    else
                        ball.SetDirection(ball.Direction.X * -1, ball.Direction.Y);

                    canvas.Children.Remove(brick);
                    bricks.Remove(brick);
                }
            }
        }
    }
}
