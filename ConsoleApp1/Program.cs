using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using WebApplication2.Models;
using Microsoft.Security.Application;



namespace ConsoleApp1
{
    class Program
    {
        private static string SecurityKey = "b14ca5898a4e4133bbce2ea2315a1916";

        private static RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();
        // Main method.
        public static void Main()
        {
            DeleteFile(@"c:\\newfolder\\abc.txt");
            

            //SymmetricAlgorithm symmetricAlgorithm = AesCryptoServiceProvider.Create();

            //string encrypted_hamid = Encrypt("hamid");
            //string encrypted_shahid = Encrypt("shahid");

            //string decrypted_hamid = Decrypt("d+z4MP8i91RryjxUksN6NQ==");
            //string decrypted_shahid = Decrypt("dit8og8rofi39sxrsaOVyw==");


            //Console.ReadLine();
            ////string decryptedData = Decrypt("4SPJ08RTqY0fz75i/zfi1g==");
        }
        
        static void DeleteFile(string path)
        {
            if (System.IO.File.Exists(path))
            {
                System.IO.File.Delete(path);
            }
        }

        static string Encrypt(string TextToEncrypt)
        {
            byte[] iv = new byte[16];
            byte[] encrypted;

            SHA256 sHA256 = SHA256Managed.Create();
            byte[] SecurityKeyInBytes = sHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            sHA256.Clear();

            var hashString = Convert.ToBase64String(SecurityKeyInBytes, 0, SecurityKeyInBytes.Length);

            // Create a new AesManaged.    
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = SecurityKeyInBytes;
                aes.IV = iv;
                // Create encryptor    
                ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV);
                // Create MemoryStream    
                using (MemoryStream ms = new MemoryStream())
                {
                    // Create crypto stream using the CryptoStream class. This class is the key to encryption    
                    // and encrypts and decrypts data from any given stream. In this case, we will pass a memory stream    
                    // to encrypt    
                    using (CryptoStream cs = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
                    {
                        // Create StreamWriter and write data to a stream    
                        using (StreamWriter sw = new StreamWriter(cs))
                            sw.Write(TextToEncrypt);
                        encrypted = ms.ToArray();
                    }
                }
            }

            // Return encrypted data    
            return Convert.ToBase64String(encrypted, 0, encrypted.Length);
            //return encrypted;
        }
        static string Decrypt(string TextToDecrypt)
        {
            byte[] iv = new byte[16];
            string plaintext = null;

            byte[] cipherText = Convert.FromBase64String
               (TextToDecrypt);

            SHA256 sHA256 = SHA256Managed.Create();
            byte[] SecurityKeyInBytes = sHA256.ComputeHash(UTF8Encoding.UTF8.GetBytes(SecurityKey));
            sHA256.Clear();

            var hashString = Convert.ToBase64String(SecurityKeyInBytes, 0, SecurityKeyInBytes.Length);

            // Create AesManaged    
            using (AesManaged aes = new AesManaged())
            {
                aes.Key = SecurityKeyInBytes;
                aes.IV = iv;

                // Create a decryptor    
                ICryptoTransform decryptor = aes.CreateDecryptor(aes.Key, aes.IV);
                // Create the streams used for decryption.    
                using (MemoryStream ms = new MemoryStream(cipherText))
                {
                    // Create crypto stream    
                    using (CryptoStream cs = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    {
                        // Read crypto stream    
                        using (StreamReader reader = new StreamReader(cs))
                            plaintext = reader.ReadToEnd();
                    }
                }
            }
            return plaintext;
        }
        public static string sha1_hash(string input)
        {
            var hash = new SHA1Managed().ComputeHash(Encoding.UTF8.GetBytes(input));
            return string.Concat(hash.Select(b => b.ToString("x2")));
        }

        public void test()
        {
            const int totalRolls = 25000;
            int[] results = new int[1];

            // Roll the dice 25000 times and display
            // the results to the console.
            for (int x = 0; x < totalRolls; x++)
            {
                byte roll = RollDice((byte)results.Length);
                results[roll - 1]++;
            }
            for (int i = 0; i < results.Length; ++i)
            {
                Console.WriteLine("{0}: {1} ({2:p1})", i + 1, results[i], (double)results[i] / (double)totalRolls);
            }
            Console.ReadLine();
            rngCsp.Dispose();
        }

        // This method simulates a roll of the dice. The input parameter is the
        // number of sides of the dice.

        public static byte RollDice(byte numberSides)
        {
            if (numberSides <= 0)
                throw new ArgumentOutOfRangeException("numberSides");

            // Create a byte array to hold the random value.
            byte[] randomNumber = new byte[1];
            do
            {
                // Fill the array with a random value.
                rngCsp.GetBytes(randomNumber);
            }
            while (!IsFairRoll(randomNumber[0], numberSides));
            // Return the random number mod the number
            // of sides.  The possible values are zero-
            // based, so we add one.
            return (byte)((randomNumber[0] % numberSides) + 1);
        }

        private static bool IsFairRoll(byte roll, byte numSides)
        {
            // There are MaxValue / numSides full sets of numbers that can come up
            // in a single byte.  For instance, if we have a 6 sided die, there are
            // 42 full sets of 1-6 that come up.  The 43rd set is incomplete.
            int fullSetsOfValues = Byte.MaxValue / numSides;

            // If the roll is within this range of fair values, then we let it continue.
            // In the 6 sided die case, a roll between 0 and 251 is allowed.  (We use
            // < rather than <= since the = portion allows through an extra 0 value).
            // 252 through 255 would provide an extra 0, 1, 2, 3 so they are not fair
            // to use.
            return roll < numSides * fullSetsOfValues;
        }
    }
}
