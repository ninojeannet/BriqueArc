using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.API.Models
{
    class User
    {
        private int userId;
        private string username;
        private string password;
        private ICollection<Ranking> rankings;

        public User(string username, string password)
        {
            this.username = username;
            this.password = password;
        }

        [JsonConstructor]
        public User(int userId,string username, string password, ICollection<Ranking> rankings)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
            this.rankings = rankings;
        }

        public override string ToString()
        {
            return this.username;
        }
    }
}
