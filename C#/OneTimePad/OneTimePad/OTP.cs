using System;
using OneTimePad.Lib;

namespace OneTimePad
{
    public static class OTP
    {
        private static Lib.OTP otp = null;
        public static void Main(string[] args)
        {
            otp = new OneTimePad.Lib.OTP();

            Console.Write("Enter a string to encrypt: ");
            var message = Console.ReadLine();
            var key = otp.Generate(message.Length);
            var cipherText = otp.Encrypt(key, message);
            Console.WriteLine();
            Console.WriteLine($"Cipher Text = {cipherText}");
            var decryptedMessage = otp.Decrypt(key, cipherText);

            Console.WriteLine();
            Console.WriteLine($"Decrypted Message = {decryptedMessage}");


            Console.ReadLine();
        }
    }
}
