using BriqueArcWPF.API;
using BriqueArcWPF.Game.Utils;
using System.Net.Security;
using System.Windows.Forms;
using System.Windows.Input;

namespace BriqueArcWPF.Game.State
{
    class EndState : GameState_I
    {
        public EndState(Models.Game context)
        {
            DialogResult result = MessageBox.Show("Voulez-vous enregistrer votre score ?\nScore : " + context.Points, "Perdu !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                API.APIHandler.AddRanking(AuthenticatedUser.GetInstance().Id, context.Points);

            BrickCreator.ResetSchemeCounter();
            context.State = new StartState(context);
            context.Points = 0;
        }

        public void KeyDown(Key key)
        {
            //Rien
        }

        public void KeyUp(Key key)
        {
            //Rien
        }

        public void Update()
        {
            //Rien
        }
    }
}
