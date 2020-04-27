
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;
using BriqueArcWPF.Game.Models;

namespace BriqueArcWPF.Game.Views
{
    class Bar : GameObject
    {
        private Models.Bar model;

        public Bar() : base(new Models.Bar())
        {
            model = (Models.Bar) base.model;
            base.SetSize(100, 20);
        }
    }
}
