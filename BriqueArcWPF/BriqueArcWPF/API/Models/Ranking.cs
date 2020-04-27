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

        public int GetScore()
        {
            return score;
        }

        public int getUserId()
        {
            return userId;
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
