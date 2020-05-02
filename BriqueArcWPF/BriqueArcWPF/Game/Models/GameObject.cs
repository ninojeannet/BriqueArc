using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriqueArcWPF.Game.Models
{
    /// <summary>
    /// Objet du jeu
    /// </summary>
    class GameObject
    {
        private Size size;
        private Vector position;
        private Vector direction;

        /// <summary>
        /// Constructeur
        /// </summary>
        public GameObject()
        {
            size = new Size(0, 0);
            position = new Vector(0, 0);
            direction = new Vector(0, 0);
        }

        /// <summary>
        /// Position de l'objet (En haut à gauche)
        /// </summary>
        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        /// <summary>
        /// Direction de l'objet
        /// </summary>
        public Vector Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        /// <summary>
        /// Taille de l'objet
        /// </summary>
        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        /// <summary>
        /// Met à jour l'objet
        /// </summary>
        public void Update()
        {
            this.position += this.direction;
        }
    }
}
