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
            var result = new Char[keyLengthInBytes];
            for(int i = 0; i < keyLengthInBytes; i++)
            {
                result[i] = (char)(random.Next(asciiCharacterStart, asciiCharacterEnd + 1) % 255);
            }

            return new string(result);
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
            var s1Chars = s1.ToCharArray();
            var s2Chars = s2.ToCharArray();
            var result = new Char[s1Chars.Length];
            for (var i = 0; i < s1Chars.Length; i++)
            {
                result[i] = (char)(s2Chars[i] ^ s1Chars[i]);
            }
            return new string(result);
        }
    }
}




