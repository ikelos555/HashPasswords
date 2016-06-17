using System;
using HashPasswordsLib;

namespace HashPasswords
{
    class Program
    {
        static void Main(string[] args)
        {
            var hash = HashPasswordsLib.HashPasswords.HashPasswordKeyStretched("hello", 1);

            Console.WriteLine("Hashed password: \n");
            foreach (var s in hash.Hash)
            {
                Console.Write(s);
            }

            Console.WriteLine("\n\nSalt: \n");
            foreach (var f in hash.Salt)
            {
                Console.Write(f);
            }

            Console.Read();
        }
    }
}
