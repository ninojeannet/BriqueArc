using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.Game.Models
{
    /// <summary>
    /// Modèle d'une brique
    /// </summary>
    class Brick : GameObject
    {
        private int life;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="life">Point de vie de la brique</param>
        public Brick(int life = 1) : base("Brick")
        {
            this.life = life;
        }

        /// <summary>
        /// Points de vie de la brique
        /// </summary>
        public int Life
        {
            get { return life; }
            set { this.life = value; }
        }
    }
}
