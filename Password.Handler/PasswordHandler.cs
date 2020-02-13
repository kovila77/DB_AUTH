using Konscious.Security.Cryptography;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PasswordHandler
{
    public static class PasswordHandler
    {

        public static byte[] CreateSalt()
        {
            var buffer = new byte[16];
            var rng = new RNGCryptoServiceProvider();
            rng.GetBytes(buffer);
            return buffer;
        }

        public static byte[] HashPassword(string password, byte[] salt)
        {
            var argon2 = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = 8, // four cores
                Iterations = 2,
                MemorySize = 1024 * 64, // 64 MB
            };
            return argon2.GetBytes(32);
        }

        public static bool VerifyHash(string password, byte[] salt, byte[] hash)
        {
            var newHash = HashPassword(password, salt);
            return hash.SequenceEqual(newHash);
        }

        /// <summary>
        /// use Zxcvbn to check password. You can add bad words
        /// </summary>
        /// <param name="password"></param>
        /// <param name="badWords"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(string password, List<string> badWords = null)
        {
            var result = Zxcvbn.Zxcvbn.MatchPassword(password, badWords);
            if (result.Score > 2) return true;
            return false;
        }
    }
}
