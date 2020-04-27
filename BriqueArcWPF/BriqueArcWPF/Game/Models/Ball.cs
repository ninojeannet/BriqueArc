using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriqueArcWPF.Game.Models
{
    class Ball : GameObject
    {
        private int attack;

        public Ball() : base("Ball")
        {
            attack = 1;
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
    }
}
