using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game.Views
{
    class Ball : Button
    {
        Models.Ball model;

        public Ball()
        {
            model = new Models.Ball();

            this.Width = 10;
            this.Height = 10;
        }

        public Vector Direction
        {
            get { return model.Direction; }
            set { model.Direction = value; }
        }

        public Vector Position
        {
            get { return model.Position; }
            set { model.Position = value; }
        }


        public void Refresh()
        {
            Position += Direction;
            Canvas.SetLeft(this, Position.X);
            Canvas.SetTop(this, Position.Y);
        }
    }
}
