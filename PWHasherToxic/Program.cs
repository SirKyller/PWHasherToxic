using System;
using System.Security.Cryptography;
using System.Text;

namespace PWHasherToxic
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please enter the salt.");
            string salt = Console.ReadLine();
            string saltHash = ComputeMd5Hash(salt);

            Console.WriteLine("Please enter the password.");
            string pw = Console.ReadLine();
            string pwHash = ComputeMd5Hash(pw);

            string completeHash = ComputeMd5Hash(pwHash + saltHash);

            Console.WriteLine("This is your hash enter it into your database: " + completeHash);
            Console.ReadLine();
        }

        public static string ComputeMd5Hash(string message)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] input = Encoding.ASCII.GetBytes(message);
                byte[] hash = md5.ComputeHash(input);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hash.Length; i++)
                {
                    sb.Append(hash[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}
