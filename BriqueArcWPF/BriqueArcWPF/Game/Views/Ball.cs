using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game.Views
{
    /// <summary>
    /// Vue d'une balle
    /// </summary>
    class Ball : GameObject
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Ball() : base(new Models.Ball())
        {
            this.SetSize(5, 5);
        }
    }
}
