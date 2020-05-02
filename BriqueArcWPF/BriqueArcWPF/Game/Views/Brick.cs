using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.Game.Views
{
    /// <summary>
    /// Vue d'une brique
    /// </summary>
    class Brick : GameObject
    {

        /// <summary>
        /// Constructeur
        /// </summary>
        public Brick() : base(new Models.Brick())
        {
            this.SetSize(100, 20);
        }
    }
}
