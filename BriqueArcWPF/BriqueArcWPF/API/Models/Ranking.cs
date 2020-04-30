using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API.Models
{
    class Ranking
    {
        private int rankingId;
        private int score;
        private int userId;
        private User user;

        public Ranking(int score, int userId,User user)
        {
            this.score = score;
            this.userId = userId;
            this.user = user;
        }

        [JsonConstructor]
        public Ranking(int rankingId, int score, int userId, User user)
        {
            this.rankingId = rankingId;
            this.score = score;
            this.userId = userId;
            this.user = user;
        }

        public int UserID
        {
            get { return userId; }
        }

        public int Score
        {
            get { return score; }
        }

        public User User
        {
            get { return user; }
            set { user = value; }
        }

        public override string ToString()
        {
            return "[id="+rankingId+"; score="+score+"; userid="+userId+"; user="+user+"]";
        }

        public string ToJSONFormat()
        {
            return "{\"score\":" + score + ", \"userId\" :" + userId + " }";
        }
    }
}
