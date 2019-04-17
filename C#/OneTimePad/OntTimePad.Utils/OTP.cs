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
            return "Here's a string. Not so random.";
        }

        public string Encrypt(string key, string message)
        {
            return "This is not encrypted";
        }

        public string Decrypt(string key, string cipherText)
        {
            return "I wonder what the original message was?";
        }
    }
}




