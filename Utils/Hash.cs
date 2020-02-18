using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Text;

namespace CalendarMngt.Utils
{
    public class Hash
    {
        public static string Crear(string value, string salt)
        {
            var valueBytes = KeyDerivation.Pbkdf2(
                password: value,
                salt: Encoding.UTF8.GetBytes(salt),
                prf: KeyDerivationPrf.HMACSHA256,
                iterationCount: 10000,
                numBytesRequested: 256 / 8
                );

            return Convert.ToBase64String(valueBytes);
        }

        public static bool Validar(string value, string salt, string hash) => Crear(value, salt).Equals(hash);
    }
}
