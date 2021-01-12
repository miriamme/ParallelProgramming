using System;

namespace Cryptography
{
    public class CaesarCipher
    {
        private const int DEFAULT_KEY = 3;
        private readonly int key;

        public CaesarCipher(int key = DEFAULT_KEY)
        {
            this.key = key;
        }

        public string Encrypt(string message)
        {
            char[] a = message.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsWhiteSpace(a[i]))
                    continue;

                a[i] = (char)('A' + ((a[i] - 'A' + key) % 26));
            }

            return new string(a);
        }

        public string Decrypt(string message)
        {
            char[] a = message.ToCharArray();

            for (int i = 0; i < a.Length; i++)
            {
                if (char.IsWhiteSpace(a[i]))
                    continue;

                int ch = (a[i] - 'A' - key + 26) % 26;
                a[i] = (char)('A' + ch);
            }

            return new string(a);
        }
    }
}
