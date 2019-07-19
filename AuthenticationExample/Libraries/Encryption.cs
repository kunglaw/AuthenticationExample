using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;

namespace AuthenticationExample.Libraries
{
    public class Encryption
    {
        private string key = "";

        public static string md5(string plainText)
        {
            MD5CryptoServiceProvider objCrypt = new MD5CryptoServiceProvider();
            byte[] data = System.Text.Encoding.ASCII.GetBytes(plainText);
            var dt = objCrypt.ComputeHash(data);

            //String md5Hash = System.Text.Encoding.ASCII.GetString(dt);

            StringBuilder stringBuilder = new StringBuilder();

            for(int i = 0; i < dt.Length; i++)
            {
                stringBuilder.Append(dt[i].ToString("x2"));
            }

            return stringBuilder.ToString();
        }
    }
}