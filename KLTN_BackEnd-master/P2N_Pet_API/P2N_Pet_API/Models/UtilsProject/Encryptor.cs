using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace P2N_Pet_API.Models.UtilsProject
{
    public class Encryptor
    {
        public static string MD5Hash(string data)
        {
            MD5CryptoServiceProvider myMD5 = new MD5CryptoServiceProvider();
            byte[] b = Encoding.UTF8.GetBytes(data);
            b = myMD5.ComputeHash(b);

            StringBuilder s = new StringBuilder();
            foreach (byte p in b)
            {
                s.Append(p.ToString("x").ToLower());
            }

            return s.ToString();
        }
    }
}
