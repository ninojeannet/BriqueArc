using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;

namespace BriqueArcWPF.Game.Models
{

    class Bar
    {
        private int position;

        public Bar()
        {
            position = 0;
        }

        public int Position
        {
            get { return position; }
            set { position = value; }
        }
    }
}
