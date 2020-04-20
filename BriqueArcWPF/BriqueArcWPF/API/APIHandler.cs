using BriqueArcWPF.API.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

namespace BriqueArcWPF.API
{
    class APIHandler
    {
        private static string urlUser = "https://briquearcasp.azurewebsites.net/api/users";
        private static string urlRanking = "https://briquearcasp.azurewebsites.net/api/rankings";
          
        public static List<User> FetchUsers()
        {
            return null;
        }

        public static bool UserExists(User user)
        {
            HttpWebRequest request = null;

            Uri uri = new Uri(urlUser);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(readStream.ReadToEnd());
            foreach(User u in users)
            {
                Console.WriteLine(u.ToString());

            }

            return false;
        }

        public static List<Ranking> FetchRankings()
        {
            return null;
        }

        public static bool StoreRanking()
        {
            return false;
        }

        public static bool StoreUser()
        {
            return false;
        }


    }
}
