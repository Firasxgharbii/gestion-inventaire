using System;
using System.Security.Cryptography;

namespace renaissanceproject
{
    public static class PasswordHelper
    {
        private const int SaltSize = 16;
        private const int HashSize = 32;
        private const int Iterations = 100_000;

        // Hash PBKDF2 → "iterations.salt.hash"
        public static string HashPassword(string password)
        {
            // 1) sel
            byte[] salt = new byte[SaltSize];
            using (var rng = RandomNumberGenerator.Create())
                rng.GetBytes(salt);

            // 2) derive
            byte[] hash;
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, Iterations, HashAlgorithmName.SHA256))
            {
                hash = pbkdf2.GetBytes(HashSize);
            }

            // 3) concat
            return string.Format("{0}.{1}.{2}",
                Iterations,
                Convert.ToBase64String(salt),
                Convert.ToBase64String(hash));
        }

        // Vérifie le mot de passe par recalcul
        public static bool VerifyPassword(string password, string stored)
        {
            var parts = stored.Split(new[] { '.' }, 3);
            if (parts.Length != 3) return false;

            int iter = int.Parse(parts[0]);
            byte[] salt = Convert.FromBase64String(parts[1]);
            byte[] hash = Convert.FromBase64String(parts[2]);

            byte[] candidate;
            using (var pbkdf2 = new Rfc2898DeriveBytes(
                password, salt, iter, HashAlgorithmName.SHA256))
            {
                candidate = pbkdf2.GetBytes(hash.Length);
            }

            if (candidate.Length != hash.Length) return false;
            int diff = 0;
            for (int i = 0; i < hash.Length; i++)
                diff |= candidate[i] ^ hash[i];
            return diff == 0;
        }
    }
}
