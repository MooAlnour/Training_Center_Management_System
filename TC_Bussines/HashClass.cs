using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace TC_Bussines
{
   public class HashClass
    {
       
            public static string HashMethod(string input)
            {
                using (SHA256 sHA256 = SHA256.Create())
                {
                    byte[] hashby = sHA256.ComputeHash(Encoding.UTF8.GetBytes(input));

                    return BitConverter.ToString(hashby).Replace("-", "").ToLower();
                }
            }
    }
}
