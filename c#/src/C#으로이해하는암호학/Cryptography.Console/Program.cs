using System;

namespace Cryptography.Consoles
{
    class Program
    {
        static void Main(string[] args)
        {
            string message = "ATTACK WEST CASTLE";
            var randomSubstituion = new RandomSubsitution();
            string cipher = randomSubstituion.Encrypt(message);
            string plain = randomSubstituion.Decript(cipher);

            Console.WriteLine($"message\t: {message}");
            Console.WriteLine($"cipher\t: {cipher}");
            Console.WriteLine($"plain\t: {plain}");
        }
    }
}
