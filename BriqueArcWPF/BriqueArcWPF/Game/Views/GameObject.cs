using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game.Views
{
    /// <summary>
    /// Vue d'un objet du jeu
    /// </summary>
    class GameObject : Button
    {
        protected Models.GameObject model;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="model">Le modèle de l'objet</param>
        public GameObject(Models.GameObject model)
        {
            this.model = model;
        }

        /// <summary>
        /// La taille
        /// </summary>
        public Size Size
        {
            get { return model.Size; }
            set { model.Size = value; }
        }

        /// <summary>
        /// Modifie la taille
        /// </summary>
        /// <param name="width">Largeur</param>
        /// <param name="height">Hauteur</param>
        public void SetSize(double width, double height)
        {
            Size size = model.Size;
            size.Width = width;
            size.Height = height;
            model.Size = size;
        }

        /// <summary>
        /// La position
        /// </summary>
        public Vector Position
        {
            get { return model.Position; }
            set { model.Position = value; }
        }

        /// <summary>
        /// Modifie la position
        /// </summary>
        /// <param name="x">La coordonnée X</param>
        /// <param name="y">La coordonnée Y</param>
        public void SetPosition(double x, double y)
        {
            Vector position = model.Position;
            position.X = x;
            position.Y = y;
            model.Position = position;
        }

        /// <summary>
        /// La direction
        /// </summary>
        public Vector Direction
        {
            get { return model.Direction; }
            set { model.Direction = value; }
        }

        /// <summary>
        /// Modifie la direction
        /// </summary>
        /// <param name="x">La coordonnée X</param>
        /// <param name="y">La coordonnée Y</param>
        public void SetDirection(double x, double y)
        {
            Vector direction = model.Direction;
            direction.X = x;
            direction.Y = y;
            model.Direction = direction;
        }

        /// <summary>
        /// Met à jour l'objet
        /// </summary>
        public void Update()
        {
            model.Update();
        }

        /// <summary>
        /// Met à jour l'interface graphique
        /// </summary>
        public void Refresh()
        {
            base.Width = Size.Width;
            base.Height = Size.Height;
            Canvas.SetLeft(this, Position.X);
            Canvas.SetTop(this, Position.Y);
        }
    }
}
