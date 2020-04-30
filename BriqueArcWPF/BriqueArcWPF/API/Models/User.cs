using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
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

        public User() { }

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

        public int getId()
        {
            return userId;
        }

        public string getUsername()
        {
            return username;
        }

        public string getPassword()
        {
            return password;
        }

        public override string ToString()
        {
            return "[id=" + userId + "; username=" + username + "; pwd=" + password + "; rankings=" + rankings + "]";
        }

        public string ToJSONFormat()
        {
            return "{\"username\":\"" + username + "\", \"password\" :\"" + password + "\" }";
        }
    }
}
