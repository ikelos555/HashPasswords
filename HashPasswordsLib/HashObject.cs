using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashPasswordsLib
{
    /// <summary>
    /// Contains salt and hashed password
    /// </summary>
    public class HashObject
    {
        private byte[] _hash;
        private byte[] _salt;

        public byte[] Hash
        {
            get { return _hash; }
        }

        public byte[] Salt
        {
            get { return _salt; }
        }

        public HashObject(byte[] salt, byte[] hash)
        {
            _salt = salt;
            _hash = hash;
        }
    }
}
