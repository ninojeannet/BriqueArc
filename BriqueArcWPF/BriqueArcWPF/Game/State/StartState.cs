using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using BriqueArcWPF.Game.Models;
using BriqueArcWPF.Game.Utils;

namespace BriqueArcWPF.Game.State
{
    class StartState : GameState_I
    {
        private Models.Game context;
        private Views.Ball ball;
        private Views.Bar bar;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Le modèle du jeu</param>
        public StartState(Models.Game context)
        {
            this.context = context;
            this.ball = context.Ball;
            this.bar = context.Bar;

            bar.SetPosition((context.Size.Width / 2) - (bar.Size.Width / 4), bar.Position.Y);
            this.context.Bricks = BrickCreator.NextSchema();
            context.Refresh();
        }

        /// <summary>
        /// Met à jour
        /// </summary>
        public void Update()
        {
            bar.Update();

            CollisionManager.CheckBarBorderCollision(context);

            context.Ball.SetPosition(bar.Position.X + bar.Size.Width / 2 - ball.Size.Width / 2, bar.Position.Y - ball.Size.Height);

            foreach (Views.Brick brick in context.Bricks)
            {
                brick.Refresh();
            }

            context.Bar.Refresh();
            context.Ball.Refresh();
        }

        /// <summary>
        /// Touche enfoncée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyDown(Key key)
        {
            switch(key)
            {
                case Key.Left:
                    bar.SetDirection(-5, 0);
                    break;

                case Key.Right:
                    bar.SetDirection(5, 0);
                    break;

                case Key.Up:
                    context.State = new PlayState(context);
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

    }
}
