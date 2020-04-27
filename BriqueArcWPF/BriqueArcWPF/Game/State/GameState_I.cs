using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BriqueArcWPF.Game.State
{
    interface GameState_I
    {
        void Update();
        void KeyDown(Key key);
        void KeyUp(Key key);
    }
}
