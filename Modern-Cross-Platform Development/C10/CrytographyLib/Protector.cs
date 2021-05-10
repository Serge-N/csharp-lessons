using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using System.Xml.Linq;
using static System.Convert;

namespace Packt.Shared
{
    public static class Protector
    {
        //16 -bit salt
        private static readonly byte[] salt = Encoding.Unicode.GetBytes("7BANANAS");
        //Iterations must at least be 1000
        private static readonly int iterations = 2000;

        private static Dictionary<string, User> Users = new Dictionary<string, User>();

        public static User Register(string username, string password, string[] roles = null)
        {
            // generate a random salt
            var rng = RandomNumberGenerator.Create();
            var saltBytes = new byte[16];
            rng.GetBytes(saltBytes);
            var saltText = Convert.ToBase64String(saltBytes);

            // generate the salted and hashed password
            var saltedHashedPassword = SaltedHashedPassword(password, saltText);

            var user = new User
            {
                Name = username,
                Salt = saltText,
                SaltedHashedPassword = saltedHashedPassword,
                Roles = roles
            };

            Users.Add(user.Name, user);

            return user;
        }

        public static bool CheckPassword(string username, string password)
        {
            if (!Users.ContainsKey(username))
            {
                return false;
            }

            var user = Users[username];

            // regenerate the salted and hashed password
            var saltedhashedPassword = SaltedHashedPassword(password, user.Salt);

            return (saltedhashedPassword == user.SaltedHashedPassword);
        }

        private static string SaltedHashedPassword(string password, string salt)
        {
            var sha = SHA256.Create();
            var saltedPassword = password + salt;
            return Convert.ToBase64String(sha.ComputeHash(Encoding.Unicode.GetBytes(saltedPassword)));
        }
        public static string Encrypt(string plainText, string password)
        {
            byte[] encrytedBytes;
            byte[] plainBytes = Encoding.Unicode.GetBytes(plainText);

            var aes = Aes.Create(); //abtsract factory method

            var pdkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);

            aes.Key = pdkdf2.GetBytes(32);
            aes.IV = pdkdf2.GetBytes(16);

            //stream
            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                ms, aes.CreateEncryptor(),
                CryptoStreamMode.Write))
                {
                    cs.Write(plainBytes, 0, plainBytes.Length);
                }
                encrytedBytes = ms.ToArray();
            }
            return Convert.ToBase64String(encrytedBytes);
        }
        public static string Decrypt(string cryptoText, string password)
        {
            byte[] plainBytes;
            byte[] cryptoBytes = Convert.FromBase64String(cryptoText);

            var aes = Aes.Create();

            var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations);

            aes.Key = pbkdf2.GetBytes(32);
            aes.IV = pbkdf2.GetBytes(16);

            using (var ms = new MemoryStream())
            {
                using (var cs = new CryptoStream(
                ms, aes.CreateDecryptor(),
                CryptoStreamMode.Write))
                {
                    cs.Write(cryptoBytes, 0, cryptoBytes.Length);
                }
                plainBytes = ms.ToArray();
            }
            return Encoding.Unicode.GetString(plainBytes);
        }

        public static void LogIn(string username, string password)
        {
            if (CheckPassword(username, password))
            {
                var identity = new GenericIdentity(
                username, "PacktAuth");
                var principal = new GenericPrincipal(
                identity, Users[username].Roles);
                System.Threading.Thread.CurrentPrincipal = principal;
            }
        }
    }
}
