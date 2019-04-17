using NUnit.Framework;
using OneTimePad.Lib;

namespace OneTimePad.Tests
{
    public class Tests
    {
        private OTP otp = null;

        [SetUp]
        public void Setup()
        {
            otp = new OTP();
        }

        [Test]
        public void Generate12ByteKey()
        {
            var keyLenghtInBytes = 12;
            var key = otp.Generate(keyLenghtInBytes);
            Assert.AreEqual(keyLenghtInBytes, key.Length);
        }

        [Test]
        public void EncryptSingleByte()
        {
            var key = "A";
            var message = "A";
            var expected = "\0";
            var cipherText = otp.Encrypt(key, message);
            Assert.AreEqual(expected, cipherText);
        }

        [Test]
        public void DecryptSingleByte()
        {
            var key = "A";
            var message = "\0";
            var expected = "A";
            var cipherText = otp.Decrypt(key, message);
            Assert.AreEqual(expected, cipherText);
        }

        [Test]
        public void Encrypt12BytesAllSameLetter()
        {
            var message = "AAAAAAAAAAAA";
            var key = "AAAAAAAAAAAA";
            var expectecCipherText = "\0\0\0\0\0\0\0\0\0\0\0\0";
            var cipherText = otp.Encrypt(key, message);
            Assert.AreEqual(expectecCipherText, cipherText);
        }

        [Test]
        public void Decrypt12BytesAllSameLetter()
        {
            var cipherText = "\0\0\0\0\0\0\0\0\0\0\0\0";
            var key = "AAAAAAAAAAAA";
            var expectecMessage = "AAAAAAAAAAAA";
            var message = otp.Encrypt(key, cipherText);
            Assert.AreEqual(expectecMessage, message);
        }

        [Test]
        public void EncryptDecryptMessageRandomKey()
        {
            var message = "I am the grand poobah!";
            var key = otp.Generate(message.Length);
            var cipherText = otp.Encrypt(key, message);
            var decryptedMessage = otp.Decrypt(key, cipherText);
            Assert.AreEqual(message, decryptedMessage);
        }


        [Test]
        public void EncryptDecryptEmbeddedCallRandomKey()
        {
            var message = "I am the grand poobah!";
            var key = otp.Generate(message.Length);
            var decryptedMessage = otp.Decrypt(key, otp.Encrypt(key, message));
            Assert.AreEqual(message, decryptedMessage);
        }

    }
}