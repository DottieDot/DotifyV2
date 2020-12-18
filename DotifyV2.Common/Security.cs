using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace DotifyV2.Common
{
    public static class Security
    {
        public static string RandomCryptographicString(int length)
        {
            const string charset = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890";

			using var rng = new RNGCryptoServiceProvider();
			byte[] buffer = new byte[length];
			rng.GetBytes(buffer);

			var charArray = buffer.Select(val => charset[val % charset.Length]).ToArray();
			return new string(charArray);
		}
    }
}
