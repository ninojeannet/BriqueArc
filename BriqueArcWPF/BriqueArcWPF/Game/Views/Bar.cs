
using System;
using System.Net.Http.Headers;
using System.Windows.Controls;
using BriqueArcWPF.Game.Models;

namespace BriqueArcWPF.Game.Views
{
    class Bar : GameObject
    {
        public Bar() : base(new Models.Bar())
        {
            base.SetSize(100, 10);
        }
    }
}
