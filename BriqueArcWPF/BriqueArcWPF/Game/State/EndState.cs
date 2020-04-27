using BriqueArcWPF.Game.Utils;
using System.Windows.Input;

namespace BriqueArcWPF.Game.State
{
    class EndState : GameState_I
    {
        private Models.Game context;

        public EndState(Models.Game context)
        {
            this.context = context;
        }

        public void KeyDown(Key key)
        {
            //Rien
        }

        public void KeyUp(Key key)
        {
            if(key == Key.Up)
            {
                BrickCreator.ResetSchemeCounter();
                context.State = new StartState(context);
            }
        }

        public void Update()
        {
            //Rien
        }
    }
}
