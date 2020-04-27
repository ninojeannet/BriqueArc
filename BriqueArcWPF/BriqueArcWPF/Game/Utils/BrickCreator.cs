using BriqueArcWPF.Game.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace BriqueArcWPF.Game.Utils
{ 
    class BrickCreator
    {
        private static Brush[] brushes = new Brush[] { Brushes.DarkBlue, Brushes.Purple, Brushes.Red, Brushes.Orange, Brushes.Yellow, Brushes.Lime, Brushes.SkyBlue };
        private static int schemaNumber = 0;

        public static List<Brick> NextSchema()
        {
            List<Brick> bricks = new List<Brick>();

            switch(schemaNumber)
            {
                case 0:
                    bricks = SchemaArrow();
                    break;

                case 1:
                    bricks = SchemaOneOnTwo();
                    break;
                case 2:
                    bricks = SchemaBlock();
                    break;
            }

            schemaNumber = (schemaNumber + 1) % 3;
            return bricks;
        }

        public static void ResetSchemeCounter()
        {
            schemaNumber = 0;
        }

        public static List<Brick> SchemaBlock()
        {
            List<Brick> bricks = new List<Brick>();

            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 7; x++)
                    bricks.Add(CreateBrick(x, y));

            return bricks;
        }

        public static List<Brick> SchemaOneOnTwo()
        {
            List<Brick> bricks = new List<Brick>();

            for (int y = 0; y < 10; y++)
                for (int x = 0; x < 7; x++)
                    if((x + y) % 2 == 1)
                        bricks.Add(CreateBrick(x, y));

            return bricks;
        }

        public static List<Brick> SchemaArrow()
        {
            List<Brick> bricks = new List<Brick>();

            for (int x = 0; x < 4; x++)
                for(int y = 0; y < 4; y++)
                {
                    bricks.Add(CreateBrick(x, y + x));
                }

            for (int x = 4; x < 7; x++)
                for (int y = 0; y < 4; y++)
                {
                    bricks.Add(CreateBrick(x, y + (6 - x)));
                }

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
