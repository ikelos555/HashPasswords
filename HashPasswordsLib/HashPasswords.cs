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
        private  static RNGCryptoServiceProvider rndm = new RNGCryptoServiceProvider();
        private static byte[] _salt = new byte[32];

        public static HashObject HashPassword(string password)
        {
            var sha = SHA256.Create();
            var hashedPass = new List<byte>();

            rndm.GetBytes(_salt);
            var clearTextPass = Encoding.ASCII.GetBytes(password);

            hashedPass.AddRange(_salt);
            hashedPass.AddRange(clearTextPass);

            return new HashObject(_salt, sha.ComputeHash(hashedPass.ToArray()));
        }

        public static HashObject HashPasswordKeyStretched(string password, int iterations)
        {
            rndm.GetBytes(_salt);

            using (var rfc = new Rfc2898DeriveBytes(password, _salt, iterations))
            {
                var hashValue = rfc.GetBytes(32);
                return new HashObject(_salt, hashValue);
            }
        }
    }
}
