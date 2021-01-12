using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptography
{
    public class RandomSubsitution
    {
        private readonly char[] table;

        public RandomSubsitution(string keyTable = null)
        {
            if (keyTable != null)
            {
                table = keyTable.ToCharArray();
            }
            else
            {
                table = CreateRandomTable();
            }
        }

        private char[] CreateRandomTable()
        {
            List<char> randomTable = new List<char>();
            var alphabet = "abcdefghijklmnopqrstuvwxyz".ToUpper().ToList();
            Random random = new Random();

            while (alphabet.Count > 0)
            {
                int rand = random.Next(0, alphabet.Count - 1);
                randomTable.Add(alphabet[rand]);
                alphabet.RemoveAt(rand);
            }

            return randomTable.ToArray();
        }

        public string Encrypt(string message)
        {
            char[] a = message.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                a[i] = a[i] == ' ' ? ' ' : table[a[i] - 'A'];
            }
            return new string(a);
        }

        public string Decript(string cipher)
        {
            char[] a = cipher.ToCharArray();
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] != ' ')
                {
                    for (int j = 0; j < table.Length; j++)
                    {
                        if (a[i] == table[j])
                        {
                            a[i] = (char)('A' + j);
                            break;
                        }
                    }
                }
            }
            return new string(a);
        }
    }
}
