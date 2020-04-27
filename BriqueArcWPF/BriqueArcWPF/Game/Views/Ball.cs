using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace BriqueArcWPF.Game.Views
{
    class Ball : GameObject
    {
        Models.Ball model;

        public Ball() : base(new Models.Ball())
        {
            model = (Models.Ball) base.model;
            this.SetSize(5, 5);
        }
    }
}
