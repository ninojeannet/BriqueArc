using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game.Views
{
    class GameObject : Button
    {
        protected Models.GameObject model;

        public GameObject(Models.GameObject model)
        {
            this.model = model;
        }

        public Size Size
        {
            get { return model.Size; }
            set { model.Size = value; }
        }

        public void SetSize(double width, double height)
        {
            Size size = model.Size;
            size.Width = width;
            size.Height = height;
            model.Size = size;
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

        public void SetPosition(double x, double y)
        {
            Vector position = model.Position;
            position.X = x;
            position.Y = y;
            model.Position = position;
        }

        public void SetDirection(double x, double y)
        {
            Vector direction = model.Direction;
            direction.X = x;
            direction.Y = y;
            model.Direction = direction;
        }

        public void Update()
        {
            model.Update();
        }

        public void Refresh()
        {
            base.Width = Size.Width;
            base.Height = Size.Height;
            Canvas.SetLeft(this, Position.X);
            Canvas.SetTop(this, Position.Y);
        }
    }
}
