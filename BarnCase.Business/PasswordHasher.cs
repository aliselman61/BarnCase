using System.Security.Cryptography;

namespace BarnCase.Core
{
    public static class PasswordHasher
    { 
        public static byte[] GenerateSalt(int size)
        {
            using (var rng = RandomNumberGenerator.Create())
            {
                byte[] salt = new byte[size];
                rng.GetBytes(salt);
                return salt;
            }
        }

        public static byte[] HashPassword(string password, byte[] salt, int iterations)
        {
            using (var pbkdf2 = new Rfc2898DeriveBytes(password, salt, iterations))
            {
                return pbkdf2.GetBytes(32);
            }
        }

        public static bool VerifyPassword(string password, byte[] salt, int iterations, byte[] expectedHash)
        {
            byte[] computed = HashPassword(password, salt, iterations);

            if (computed.Length != expectedHash.Length)
                return false;

            int diff = 0;
            for (int i = 0; i < computed.Length; i++)
                diff |= computed[i] ^ expectedHash[i];

            return diff == 0;
        }
    }
}
