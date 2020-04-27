using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace BriqueArcWPF.Game.Models
{
    class GameObject
    {
        private String name;
        private Size size;
        private Vector position;
        private Vector direction;

        public GameObject(String name)
        {
            this.name = name;

            size = new Size(0, 0);
            position = new Vector(0, 0);
            direction = new Vector(0, 0);
        }

        public String Name
        {
            get { return name; }
        }

        public Vector Position
        {
            get { return position; }
            set { position = value; }
        }

        public Vector Direction
        {
            get { return direction; }
            set { direction = value; }
        }

        public Size Size
        {
            get { return size; }
            set { size = value; }
        }

        public void Update()
        {
            this.position += this.direction;
        }
    }
}
