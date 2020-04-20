using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriqueArcWPF.Game.Models
{
    class Ball
    {
        private int attack;
        private Vector direction;
        private Vector position;

        public Ball()
        {
            attack = 1;
            direction = new Vector(0, 0);
            position = new Vector(0, 0);
        }

        public Vector Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        public int Attack
        {
            get { return attack; }
            set { attack = value; }
        }
    }
}
