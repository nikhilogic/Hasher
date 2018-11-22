using System;
using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System.Threading.Tasks;

namespace Hasher
{    
    class Program
    {
        //make the app a bit interesting
        static ConsoleColor  GetRandomColor()
        {            
            var v = new []{ConsoleColor.Green,ConsoleColor.Magenta,ConsoleColor.Red,ConsoleColor.Yellow,ConsoleColor.Blue, ConsoleColor.Cyan};
            Random r = new Random();
            return (ConsoleColor)v.GetValue(r.Next(v.Length));
        }
        static void Main(string[] args)
        {   
            Console.WriteLine($"args supplied..");
            for (int i = 0; i < args.Length; i++)
            {
                Console.WriteLine(args[i]);
            }
            if(args.Length != 1) 
            {
                Console.WriteLine("Invalid arguments suppplied");
                Console.ReadLine();
                 return;
            }
            if(!File.Exists(args[0]))
            {
                Console.WriteLine($"File {args[0]} does not exist");
                Console.ReadLine();
                return;
            }
            Console.ForegroundColor = GetRandomColor();
            Console.WriteLine("Paste the Hash for the selected file");
            Console.ForegroundColor = GetRandomColor();
            var websitehash = Console.ReadLine();
            Console.ForegroundColor =GetRandomColor();    
            var sha256hash = GetByteArray(SHA256.Create().ComputeHash(File.ReadAllBytes(args[0])));
            var sha1hash = GetByteArray(SHA1.Create().ComputeHash(File.ReadAllBytes(args[0])));
            var md5hash = GetByteArray(MD5.Create().ComputeHash(File.ReadAllBytes(args[0])));      
            Console.WriteLine($"SHA256: {((string.Compare(websitehash,sha256hash,true)==0) ? "YES" : "NO")}");
            Console.ForegroundColor = GetRandomColor();
            Console.WriteLine($"SHA1: {((string.Compare(websitehash,sha1hash,true)==0) ? "YES" : "NO")}");
            Console.ForegroundColor =GetRandomColor();
            Console.WriteLine($"MD5: {((string.Compare(websitehash,md5hash,true)==0) ? "YES" : "NO")}");
            Console.ResetColor();                                    
        }

        /// converts the bytes to standard uppercase Hexadecimal format
        public static string GetByteArray(byte[] array)
        {
            string ret="";
            int i;
            for (i = 0; i < array.Length; i++)
            {
                ret +=  $"{array[i]:X2}";                
            }
            return ret;            
        }

    }
}
