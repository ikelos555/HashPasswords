using System;
using System.Collections.Generic;
using System.Security;
using System.Security.Cryptography;
using System.Text;

namespace HashPasswordsLib
{
    /// <summary>
    /// Provide all functions to hash cleartext passwords with SHA256 and a 32 bit salt.
    /// </summary>
    public static class HashPasswords
    {
        private static RNGCryptoServiceProvider rndm = new RNGCryptoServiceProvider();
        private static SHA256 sha  = SHA256.Create();

        private static byte[] Salt = new byte[32];

        /// <summary>
        /// Hash a cleartext password with SHA256 bit
        /// </summary>
        /// <param name="password"></param>
        /// <returns>HashObject</returns>
        public static HashObject HashPassword(string password)
        {
            var hashedPass = new List<byte>();

            rndm.GetBytes(Salt);
            var clearTextPass = Encoding.ASCII.GetBytes(password);

            hashedPass.AddRange(Salt);
            hashedPass.AddRange(clearTextPass);

            return new HashObject(Salt, sha.ComputeHash(hashedPass.ToArray()));
        }
            
    }
}
