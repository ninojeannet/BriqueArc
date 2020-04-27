using BriqueArcWPF.API.Models;
using Newtonsoft.Json;
using RestSharp;
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
            HttpWebRequest request = null;

            Uri uri = new Uri(urlUser);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            List<User> users = JsonConvert.DeserializeObject<List<User>>(readStream.ReadToEnd());
            foreach (User u in users)
            {
                Console.WriteLine(u);
            }
            return users;
        }

        public static User GetUser(string username, string password)
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
                
                if (u.getUsername() == username)
                {
                    if(u.getPassword() == password)
                    {

                        Console.WriteLine(u);
                        return u;
                    }
                }
            }

            return null;
        }

        public static List<Ranking> FetchRankings()
        {
            // A tester 

            ///-----------
            HttpWebRequest request = null;

            Uri uri = new Uri(urlRanking);
            request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream receiveStream = response.GetResponseStream();

            // Pipes the stream to a higher level stream reader with the required encoding format. 
            StreamReader readStream = new StreamReader(receiveStream, Encoding.UTF8);
            List<Ranking> rankings = JsonConvert.DeserializeObject<List<Ranking>>(readStream.ReadToEnd());
            foreach(Ranking r in rankings)
            {
                Console.WriteLine(r);
            }
            return rankings;
        }

        public static bool StoreRanking(Ranking ranking)
        {
            string body = ranking.ToJSONFormat();

            var client = new RestClient(urlRanking);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=ebb396d4f81beeb5fd4bbc63eb7fd56cdbac52e54150918a54705740949cf93d");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            return false;
        }

        public static bool StoreUser(User user)
        {
            string body = user.ToJSONFormat();

            var client = new RestClient(urlUser);
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Content-Type", "application/json");
            request.AddHeader("Cookie", "ARRAffinity=ebb396d4f81beeb5fd4bbc63eb7fd56cdbac52e54150918a54705740949cf93d");
            request.AddParameter("application/json", body, ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);
            //
            //Stream receiveStream = response.GetResponseStream();

            return false;
        }


    }
}
