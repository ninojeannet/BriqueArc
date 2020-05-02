using BriqueArcWPF.API;
using BriqueArcWPF.API.Models;
using BriqueArcWPF.Game.Utils;
using System.Net.Security;
using System.Windows.Forms;
using System.Windows.Input;

namespace BriqueArcWPF.Game.State
{
    class EndState : GameState_I
    {
        private Models.Game context;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="context">Le modèle du jeu</param>
        public EndState(Models.Game context)
        {
            this.context = context;

            DialogResult result = MessageBox.Show("Voulez-vous enregistrer votre score ?\nScore : " + context.Points, "Perdu !", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Ranking ranking = new Ranking(context.Points, AuthenticatedUser.GetInstance().Id, null);
                API.APIHandler.StoreRanking(ranking);
            }
        }

        /// <summary>
        /// Touche enfoncée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyDown(Key key)
        {
            //Rien
        }

        /// <summary>
        /// Touche lachée
        /// </summary>
        /// <param name="key">La touche</param>
        public void KeyUp(Key key)
        {
            //Rien
        }

        /// <summary>
        /// Met à jour
        /// </summary>
        public void Update()
        {
            BrickCreator.ResetSchemeCounter();
            context.State = new StartState(context);
            context.Points = 0;
        }
    }
}
