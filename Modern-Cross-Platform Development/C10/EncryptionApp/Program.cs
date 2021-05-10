using System;
using Packt.Shared;
using static System.Console;
using System.Security.Cryptography;

namespace EncryptionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            WriteLine("Enter a message that you want to encrypt : ");
            string messsage = ReadLine();

            Write("Enter a password : ");
            string password = ReadLine();

            string cryptoText = Protector.Encrypt(messsage, password);

            WriteLine($"Encrpted Text : {cryptoText}");

            Write("Enter a password : ");
            string passwordTwo = ReadLine();

            try
            {
                string clearText = Protector.Decrypt(cryptoText, passwordTwo);
                WriteLine($"Decrypted Text : {clearText}");
            }
            catch (CryptographicException ex)
            {
                WriteLine("{0}\nMore details: {1}",
                arg0: "You entered the wrong password!",
                arg1: ex.Message);

            }
            catch (Exception ex)
            {
                WriteLine("Non-cryptographic exception: {0}, {1}",
                arg0: ex.GetType().Name,
                arg1: ex.Message);
            }
        }
    }
}
