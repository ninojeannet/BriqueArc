using BriqueArcWPF.Game.Views;
using System;
using System.Collections.Generic;
using System.Windows;

namespace BriqueArcWPF.Game.Utils
{
    class CollisionManager
    {
        public static void CheckBarBorderCollision(Models.Game game)
        {
            Bar bar = game.Bar;
            if (bar.Position.X < 0)
            {
                bar.SetPosition(0, bar.Position.Y);
                bar.SetDirection(0, 0);
            }
            else if (bar.Position.X + bar.Size.Width > game.Size.Width)
            {
                bar.SetPosition(game.Size.Width - bar.Size.Width, bar.Position.Y);
                bar.SetDirection(0, 0);
            }
        }

        public static void CheckBallBorderCollision(Models.Game game)
        {
            Ball ball = game.Ball;
            if (ball.Position.Y <= 0)
                ball.SetDirection(ball.Direction.X, ball.Direction.Y * -1);
            if (ball.Position.X + ball.Size.Width >= game.Size.Width || ball.Position.X <= 0)
                ball.SetDirection(ball.Direction.X * -1, ball.Direction.Y);
        }

        public static void CheckBallBarCollision(Models.Game game)
        {
            Ball ball = game.Ball;
            Bar bar = game.Bar;

            if (ball.Position.Y + ball.Size.Height >= bar.Position.Y && ball.Position.X <= bar.Position.X + bar.Size.Width && ball.Position.X + ball.Size.Width >= bar.Position.X && ball.Position.Y <= bar.Position.Y + bar.Size.Height)
            {
                double height = (bar.Position.Y + bar.Size.Height / 2) - (ball.Position.Y + ball.Size.Height / 2);
                double width = (bar.Position.X + bar.Size.Width / 2) - (ball.Position.X + ball.Size.Width / 2);
                double angle = Math.Atan2(width, height) - Math.PI / 2;
                if (angle < 0)
                    angle += 2 * Math.PI;

                ball.Direction = new Vector(Math.Cos(angle) * ball.Direction.Length * -1, Math.Sin(angle) * ball.Direction.Length);
            }
        }

        public static void CheckBallBricksCollision(Models.Game game)
        {
            Ball ball = game.Ball;
            List<Brick> bricks = game.Bricks;

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

                    bricks.Remove(brick);
                    game.Points += 100;
                }
            }
        }

        public static void CheckAllCollision(Models.Game game)
        {
            CheckBallBarCollision(game);
            CheckBallBorderCollision(game);
            CheckBallBricksCollision(game);
            CheckBarBorderCollision(game);
        }
    }
}
