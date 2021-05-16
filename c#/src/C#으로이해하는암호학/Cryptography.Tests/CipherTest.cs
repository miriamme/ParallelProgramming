using System;
using System.Diagnostics;

using Xunit;

namespace Cryptography.Tests
{
    public class CipherTest
    {
        [Fact]
        public void CaesarCipherTest()
        {
            string message = "ATTACK WEST CASTLE";
            var caesar = new CaesarCipher();
            string cipher = caesar.Encrypt(message);
            string plain = caesar.Decrypt(cipher);

            Debug.Assert(cipher == "DWWDFN ZHVW FDVWOH");
            Assert.Equal("DWWDFN ZHVW FDVWOH", cipher);

            Debug.Assert(plain == message);
            Assert.Equal(plain, message);
        }

        [Fact]
        public void RandomSubsituionTest()
        {
            string message = "ATTACK WEST CASTLE";
            var randomSubstituion = new RandomSubsitution();
            string cipher = randomSubstituion.Encrypt(message);
            string plain = randomSubstituion.Decript(cipher);

            Assert.Equal(message, plain);
        }
    }
}
