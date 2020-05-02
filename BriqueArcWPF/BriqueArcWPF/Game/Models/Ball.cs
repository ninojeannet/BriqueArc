using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriqueArcWPF.Game.Models
{
    /// <summary>
    /// Modèle de la balle
    /// </summary>
    class Ball : GameObject
    {
        private int attack;

        /// <summary>
        /// Constructeur
        /// </summary>
        public Ball() : base()
        {
            attack = 1;
        }

        /// <summary>
        /// Dégats de la balle
        /// </summary>
        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
    }
}
