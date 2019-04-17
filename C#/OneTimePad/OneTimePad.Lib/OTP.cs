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
            return "Not a random string";
        }

        public string Encrypt(string key, string message)
        {
            return "Hardly encrypted";
        }

        public string Decrypt(string key, string cipherText)
        {
            return "Wonder what the original message was?";
        }
    }
}




