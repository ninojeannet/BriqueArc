using BriqueArcWPF.API.Models;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace BriqueArcWPF.API
{
    /// <summary>
    /// Classe de liaison avec l'API
    /// </summary>
    class APIHandler
    {
        private static string urlUser = "https://briquearcasp.azurewebsites.net/api/users";
        private static string urlRanking = "https://briquearcasp.azurewebsites.net/api/rankings";

        //private static string urlUser = "https://localhost:44384/api/users";
        //private static string urlRanking = "https://localhost:44384/api/rankings";

        /// <summary>
        /// "Envoie" un URI spécifique par méthode GET
        /// </summary>
        /// <param name="uriString">URI en format String</param>
        /// <returns>Le stream de réponse de l'API</returns>
        private static Stream Send(String uriString)
        { 
            Uri uri = new Uri(uriString);
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);
            request.Method = "GET";
            HttpWebResponse response = (HttpWebResponse) request.GetResponse();
            return response.GetResponseStream();
        }

        /// <summary>
        /// Encode en SHA256 un String
        /// </summary>
        /// <param name="str">La chaîne de charactère à encoder</param>
        /// <returns>Le hash en hexadécimale</returns>
        public static String Encode(String str)
        {
            ASCIIEncoding encoder = new ASCIIEncoding();
            SHA256Managed hash = new SHA256Managed();
            byte[] data = hash.ComputeHash(encoder.GetBytes(str));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < data.Length; i++)
                builder.Append(data[i].ToString("x2"));
            return builder.ToString();
        }

        /// <summary>
        /// Demande à l'API si le nom de compte existe déjà
        /// </summary>
        /// <param name="username">Le nom de compte</param>
        /// <returns>Le nom de compte existe ?</returns>
        public static bool UsernameAlreadyExists(String username)
        {
            Stream receivedStream = Send(urlUser + "/exists/" + username);
            StreamReader streamReader = new StreamReader(receivedStream, Encoding.UTF8);
            return JsonConvert.DeserializeObject<bool>(streamReader.ReadToEnd());
        }

        /// <summary>
        /// Demande à l'API une connexion
        /// </summary>
        /// <param name="username">Le nom de compte</param>
        /// <param name="password">Le mot de passe</param>
        /// <returns>L'utilisateur correspondant au couple nom de compte et mot de passe</returns>
        public static User ConnectUser(String username, String password)
        {
            Stream receivedStream = Send(urlUser + "/connect/" + username + "/" + Encode(password));
            StreamReader streamReader = new StreamReader(receivedStream, Encoding.UTF8);
            return  JsonConvert.DeserializeObject<User>(streamReader.ReadToEnd());
        }

        /// <summary>
        /// Demande à l'API la liste des score triée
        /// </summary>
        /// <returns>La liste des scores triée</returns>
        public static List<Ranking> GetScoreboard()
        {
            Stream receivedStream = Send(urlRanking + "/scoreboard");
            StreamReader streamReader = new StreamReader(receivedStream, Encoding.UTF8);
            List<Ranking> rankings = JsonConvert.DeserializeObject<IEnumerable<Ranking>>(streamReader.ReadToEnd()).ToList();

            Dictionary<int, User> users = new Dictionary<int, User>();
            foreach (Ranking ranking in rankings)
            {
                if (!users.ContainsKey(ranking.UserID))
                    users.Add(ranking.UserID, APIHandler.GetUser(ranking.UserID));

                ranking.User = users[ranking.UserID];
            }

            return rankings;
        }

        /// <summary>
        /// Demande à l'API un utilisateur spécifique
        /// </summary>
        /// <param name="id">L'idientifiant de l'utilisateur</param>
        /// <returns>L'utilisateur recherché</returns>
        private static User GetUser(int id)
        {
            Stream receivedStream = Send(urlUser + "/" + id);
            StreamReader streamReader = new StreamReader(receivedStream, Encoding.UTF8);
            return JsonConvert.DeserializeObject<User>(streamReader.ReadToEnd());
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

        /// <summary>
        /// Envoie un score à ajouter avec la méthode POST
        /// </summary>
        /// <param name="ranking">Le score à envoyé</param>
        /// <returns>False</returns>
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

        /// <summary>
        /// Envoie un utilisatur à ajouter avec la méthode POST
        /// </summary>
        /// <param name="user">L'utilisateur à ajouter</param>
        /// <returns>False</returns>
        public static bool StoreUser(User user)
        {
            user.setPassword(Encode(user.getPassword()));
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
