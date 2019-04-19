using System;
using System.Linq;
using System.Text;

namespace OneTimePad.Lib
{
    public class OTP
    {
        private static Random random = new Random();
        public string Generate(int keyLengthInBytes)
        {
            // Borrowed this code from: https://gist.github.com/khalilovcmd/494988c43b6c205f9d76
            // The important part here is that the key generated has to be a random set of *ASCII characters*, 
            // not just any old bytes (that's why the random.NextBytes() was not working)
            int asciiCharacterStart = 65; // from which ascii character code the generation should start
            int asciiCharacterEnd = 122; // to which ascii character code the generation should end
            return new string(
                Enumerable.Range(0, keyLengthInBytes)
                    .Select(i => (char)(random.Next(asciiCharacterStart, asciiCharacterEnd + 1) % 255))
                    .ToArray());
        }

        public string Encrypt(string key, string message)
        {
            return ExclusiveOr(key, message);
        }

        public string Decrypt(string key, string cipherText)
        {
            return ExclusiveOr(key, cipherText);
        }

        private string ExclusiveOr(string s1, string s2)
        {
            return new string(
                s1.ToCharArray()
                    .Zip(s2.ToCharArray(), (c1, c2) => (char)(c1 ^ c2))
                    .ToArray());
        }
    }
}




