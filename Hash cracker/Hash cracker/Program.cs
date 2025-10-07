using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hash_cracker
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = " ~ Anarchy Cracker made by Chefkoch ~ ";

            Console.ForegroundColor = ConsoleColor.DarkRed;
            
            Console.Write("   [!] Do you argee to that you only use this tool for educative Purposes? [y/n] ");
            string tos = Console.ReadLine();
            if(tos.ToLower() == "y")
            {
                goto start;
            }
            else
            {
                Console.WriteLine("   [!] you need to agree to the T.O.S");
                Console.ReadKey();
                Environment.Exit(0);
            }



        start:
            

            Console.Clear();
            
            Console.Write("   [!] Drag and drop your Wordlist ~ ");
            string path = Console.ReadLine().Replace(@"""", "");

            
            Console.Write("   [!] Paste your MD5 hashed String ~ ");
            string hash = Console.ReadLine();


            foreach (var word in File.ReadLines(path))
            {
                try
                {
                    string hashedidk = CreateMD5(word);
                    if(hashedidk.ToLower() == hash.ToLower())
                    {
                        Console.WriteLine($"   [~] Matching String found : {word} : target hash : {hash}");
                        break;
                    }
                    else
                    {
                        Console.WriteLine($"   [-] not matching {word} : {hashedidk}");
                    }
                }
                catch { }
            }

            Console.ReadKey();

        }
        
        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }
    }
}

