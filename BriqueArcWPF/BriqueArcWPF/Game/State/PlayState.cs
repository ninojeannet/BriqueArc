using System;
using System.Collections.Generic;
using System.Windows.Input;
using BriqueArcWPF.Game.Utils;

namespace BriqueArcWPF.Game.State
{
    class PlayState : GameState_I
    {
        private Models.Game context;
        private Views.Ball ball;
        private Views.Bar bar;
        private List<Views.Brick> bricks;

        public PlayState(Models.Game context)
        {
            this.context = context;
            ball = context.Ball;
            bar = context.Bar;
            bricks = context.Bricks;

            ball.SetDirection(0, context.Size.Height / 100);
        }

        public void KeyDown(Key key)
        {
            switch (key)
            {
                case Key.Left:
                    bar.SetDirection(context.Size.Width / -100, 0);
                    break;

                case Key.Right:
                    bar.SetDirection(context.Size.Width / 100, 0);
                    break;
            }
        }

        public void KeyUp(Key key)
        {
            bar.SetDirection(0, 0);
        }

        public void Update()
        {
            ball.Update();
            bar.Update();

            CollisionManager.CheckAllCollision(bar, ball, bricks, context.Size.Width, context.Size.Height);

            if (ball.Position.Y + ball.Size.Height >= context.Size.Height)
                context.State = new EndState(context);

            if (bricks.Count == 0)
                context.State = new StartState(context);

            ball.Refresh();
            bar.Refresh();
        }
    }
}
