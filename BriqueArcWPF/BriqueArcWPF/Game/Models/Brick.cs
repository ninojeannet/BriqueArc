using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.Game.Models
{
    class Brick
    {
        private int life;

        public Brick(int life = 1)
        {
            this.life = life;
        }

        public int Life
        {
            get { return life; }
            set { this.life = value; }
        }
    }
}
