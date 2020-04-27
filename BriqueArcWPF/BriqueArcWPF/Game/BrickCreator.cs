using BriqueArcWPF.Game.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BriqueArcWPF.Game
{ 
    class BrickCreator
    {
        private static Brush[] brushes = new Brush[] { Brushes.DarkBlue, Brushes.Purple, Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.Lime, Brushes.SkyBlue };

        public static List<Brick> SchemaBlock()
        {
            List<Brick> bricks = new List<Brick>();

            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 7; x++)
                    bricks.Add(CreateBrick(x, y));

            return bricks;
        }

        private static Brick CreateBrick(int x, int y)
        {

            Brick brick = new Brick();

            int marginLeft = Convert.ToInt32(0.5 * brick.Size.Width);

            brick.SetPosition(marginLeft + x * brick.Size.Width, (y + 1) * brick.Size.Height);
            brick.Background = brushes[(x + y) % brushes.Length];

            return brick;
        }
    }
}
