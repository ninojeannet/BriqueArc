
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;
using BriqueArcWPF.Game.Models;

namespace BriqueArcWPF.Game.Views
{
    /// <summary>
    /// Vue d'une barre
    /// </summary>
    class Bar : GameObject
    {
        /// <summary>
        /// Constructeur
        /// </summary>
        public Bar() : base(new Models.Bar())
        {
            base.SetSize(100, 10);
        }
    }
}
