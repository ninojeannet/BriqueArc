using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.Game.Views
{
    class Brick : GameObject
    {

        public Brick() : base(new Models.Brick())
        {
            this.SetSize(100, 20);
        }
    }
}
