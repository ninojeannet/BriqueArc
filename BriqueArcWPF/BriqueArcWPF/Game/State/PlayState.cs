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

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Le modèle du jeu</param>
        public PlayState(Models.Game context)
        {
            this.context = context;
            ball = context.Ball;
            bar = context.Bar;
            bricks = context.Bricks;

            ball.SetDirection(0, context.Size.Height / 100);
        }

        //// <summary>
        /// Touche enfoncée
        /// </summary>
        /// <param name="key">La touche</param>
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

        /// <summary>
        /// Touche lachée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyUp(Key key)
        {
            bar.SetDirection(0, 0);
        }

        /// <summary>
        /// Met à jour
        /// </summary>
        public void Update()
        {
            ball.Update();
            bar.Update();

            CollisionManager.CheckAllCollision(context);

            if (ball.Position.Y + ball.Size.Height >= context.Size.Height)
                context.State = new EndState(context);

            if (bricks.Count == 0)
                context.State = new StartState(context);

            ball.Refresh();
            bar.Refresh();
        }
    }
}
