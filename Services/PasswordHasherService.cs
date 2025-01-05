using ExpenseApp.Models.Entity;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace ExpenseApp.Services
{
    public class PasswordHasherService : IPasswordHasherService
    {
        private const int SaltSize = 16; // Size of the salt in bytes
        private const int HashSize = 32; // Size of the hash in bytes
        private const int Iterations = 10000; // Iteration count for PBKDF2

        public string SavePassword(string password)
        {
            if (string.IsNullOrEmpty(password))
                throw new ArgumentNullException(nameof(password));

            // Generate a random salt
            byte[] salt = new byte[SaltSize];
            RandomNumberGenerator.Fill(salt);

            // Hash the password with the salt using PBKDF2
            byte[] hash = KeyDerivation.Pbkdf2(
                password,
                salt,
                KeyDerivationPrf.HMACSHA256,
                Iterations,
                HashSize
            );

            // Combine the salt and the hash and return as a base64 string
            byte[] hashBytes = new byte[SaltSize + HashSize];
            Buffer.BlockCopy(salt, 0, hashBytes, 0, SaltSize);
            Buffer.BlockCopy(hash, 0, hashBytes, SaltSize, HashSize);

            return Convert.ToBase64String(hashBytes);
        }

        public bool ValidatePassword(UserDetails userDetails, string passwordToVerify)
        {
            if (string.IsNullOrEmpty(userDetails.Password) || string.IsNullOrEmpty(passwordToVerify))
                throw new ArgumentNullException();

            // Decode the stored hash
            byte[] hashBytes = Convert.FromBase64String(userDetails.Password);

            // Extract the salt and the hash from the stored hash
            byte[] salt = new byte[SaltSize];
            byte[] storedHash = new byte[HashSize];
            Buffer.BlockCopy(hashBytes, 0, salt, 0, SaltSize);
            Buffer.BlockCopy(hashBytes, SaltSize, storedHash, 0, HashSize);

            // Hash the input password with the extracted salt
            byte[] computedHash = KeyDerivation.Pbkdf2(
                passwordToVerify,
                salt,
                KeyDerivationPrf.HMACSHA256,
                Iterations,
                HashSize
            );

            // Compare the computed hash with the stored hash
            for (int i = 0; i < HashSize; i++)
            {
                if (computedHash[i] != storedHash[i])
                    return false;
            }

            return true;
        }
    }
}
