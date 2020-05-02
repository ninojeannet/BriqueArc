using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BriqueArcASP.Models
{
    public class User
    {
        /// <summary>
        /// Identifiant de l'utilisateur
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Nom de compte
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Mot de passe hashé
        /// </summary>
        public string Password { get; set; }
    }
}
