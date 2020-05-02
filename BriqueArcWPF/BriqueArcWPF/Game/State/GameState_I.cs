using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BriqueArcWPF.Game.State
{
    /// <summary>
    /// Interface permettant d'utiliser le pattern State
    /// </summary>
    interface GameState_I
    {
        /// <summary>
        /// Met à jour le jeu
        /// </summary>
        void Update();

        /// <summary>
        /// Touche enfoncée
        /// </summary>
        /// <param name="key">La touche</param>
        void KeyDown(Key key);

        /// <summary>
        /// Touche lachée
        /// </summary>
        /// <param name="key">La touche</param>
        void KeyUp(Key key);
    }
}
