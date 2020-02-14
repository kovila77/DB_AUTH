using Konscious.Security.Cryptography;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

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

        /// <summary>
        /// give password hash, using salt.
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <returns></returns>
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

        /// <summary>
        /// use Zxcvbn to check quality of password. You can add bad words
        /// </summary>
        /// <param name="password"></param>
        /// <param name="badWords"></param>
        /// <returns></returns>
        public static bool IsStrongPassword(string password, List<string> badWords = null)
        {
            var result = Zxcvbn.Zxcvbn.MatchPassword(password.Trim(), badWords);
            if (result.Score > 2) return true;
            return false;
        }
    }
}
