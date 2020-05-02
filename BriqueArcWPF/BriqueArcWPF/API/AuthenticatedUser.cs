using BriqueArcWPF.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API
{
    /// <summary>
    /// Classe singleton contenant l'utilisateur authentifié
    /// </summary>
    class AuthenticatedUser
    {
        private static AuthenticatedUser instance;
        private User user;

        /// <summary>
        /// Récupère l'instance unique de cet objet
        /// </summary>
        /// <returns>L'instance de l'objet</returns>
        public static  AuthenticatedUser GetInstance()
        {
            if (instance == null)
                instance = new AuthenticatedUser();

            return instance;
        }

        /// <summary>
        /// Y'a il quelque de connecté ?
        /// </summary>
        /// <returns>Connecté ?</returns>
        public bool Authenticated()
        {
            return (user != null);
        }

        /// <summary>
        /// Déconnecte l'utilisateur
        /// </summary>
        public void Disconnect()
        {
            user = null;
        }

        /// <summary>
        /// Ajoute l'utilisateur connecté
        /// </summary>
        /// <param name="user"></param>
        public void SetUser(User user)
        {
            this.user = user;
        }

        /// <summary>
        /// Identifiant de l'utilisateur connecté
        /// </summary>
        public int Id
        {
            get { return user.getId(); }
        }

        /// <summary>
        /// Nom de compte de l'utilisateur connecté
        /// </summary>
        public String Username
        {
            get { return user.getUsername(); }
        }
    }
}
