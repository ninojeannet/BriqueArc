using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API.Models
{
    /// <summary>
    /// Score réalisé par un utilisateur
    /// </summary>
    class Ranking
    {
        private int rankingId;
        private int score;
        private int userId;
        private User user;

        /// <summary>
        /// Constructeur
        /// </summary>
        /// <param name="score">Le score réalisé</param>
        /// <param name="userId">L'identifiant de l'utilisateur ayant réalisé le score</param>
        /// <param name="user">L'utilisateur ayant réalisé le score</param>

        public Ranking(int score, int userId,User user)
        {
            this.score = score;
            this.userId = userId;
            this.user = user;
        }

        /// <summary>
        /// Constructeur par désérialisation
        /// </summary>
        /// <param name="rankingId">L'identifiant du score</param>
        /// <param name="score">Le score réalisé</param>
        /// <param name="userId">L'identifiant de l'utilisateur ayant réalisé le score</param>
        /// <param name="user">L'utilisateur ayant réalisé le score</param>
        [JsonConstructor]
        public Ranking(int rankingId, int score, int userId, User user)
        {
            this.rankingId = rankingId;
            this.score = score;
            this.userId = userId;
            this.user = user;
        }

        /// <summary>
        /// L'identifiant de l'utilisateur
        /// </summary>
        public int UserID
        {
            get { return userId; }
        }

        /// <summary>
        /// Le score
        /// </summary>
        public int Score
        {
            get { return score; }
        }

        /// <summary>
        /// L'utilisateur ayant réalisé le score
        /// </summary>
        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public override string ToString()
        {
            return "[id="+rankingId+"; score="+score+"; userid="+userId+"; user="+user+"]";
        }

        /// <summary>
        /// Sérialisation
        /// </summary>
        /// <returns>Objet en format JSON</returns>
        public string ToJSONFormat()
        {
            return "{\"score\":" + score + ", \"userId\" :" + userId + " }";
        }
    }
}
