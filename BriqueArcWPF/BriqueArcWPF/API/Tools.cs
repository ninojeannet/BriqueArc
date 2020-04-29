using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BriqueArcWPF.APIHandler
{
    class Tools
    {
        
        public static string Encrypt(string message)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            //return as base64 string
            return Convert.ToBase64String(md5.ComputeHash(Encoding.Unicode.GetBytes(message)));
        }

        public static string Decrypt(string message)
        {
            return "";
        }
    }
}
