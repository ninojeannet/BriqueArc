using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API.Models
{
    /// <summary>
    /// Model d'un utilisateur
    /// </summary>
    class User
    {
        private int userId;
        private string username;
        private string password;

        /// <summary>
        /// Constructeur par défaut
        /// </summary>
        public User() { }

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="username">Le nom de compte</param>
        /// <param name="password">Le mot de passe</param>
        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Constructeur par désérialisation
        /// </summary>
        /// <param name="userId">L'dientifiant</param>
        /// <param name="username"></param>
        /// <param name="password"></param>
        [JsonConstructor]
        public User(int userId,string username, string password)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
        }

        /// <summary>
        /// Retourne l'identifiant de l'utilisateur
        /// </summary>
        /// <returns>L'identifiant</returns>
        public int getId()
        {
            return userId;
        }

        /// <summary>
        /// Retourne le nom de compte
        /// </summary>
        /// <returns>Le nom de compte</returns>
        public string getUsername()
        {
            return username;
        }

        /// <summary>
        /// Retourne le mot de passe
        /// </summary>
        /// <returns>Le mto de </returns>
        public string getPassword()
        {
            return password;
        }

        /// <summary>
        /// Modifie le mot de passe
        /// </summary>
        /// <param name="password">Le nouveau mot de passe</param>
        public void setPassword(string password)
        {
            this.password = password;
        }

        public override string ToString()
        {
            return "[id=" + userId + "; username=" + username + "; pwd=" + password + "]";
        }

        /// <summary>
        /// Sérialisation
        /// </summary>
        /// <returns>Objet en format JSON</returns>
        public string ToJSONFormat()
        {
            return "{\"username\":\"" + username + "\", \"password\" :\"" + password + "\" }";
        }
    }
}
