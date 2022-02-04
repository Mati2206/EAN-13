using System;

namespace Obliczanie_liczby_kontrolnej_EAN_13
{
    class Program
    {
        static void Main()
        {
            string EAN = Console.ReadLine();
            int checkDigit = EAN[EAN.Length - 1] - '0';
            string test = EAN.Remove(EAN.Length - 1);
            int sum = 0;
            for (int i = 0; i < test.Length; i++)
            {
                if (i % 2 == 0)
                {
                    sum += test[i] - '0';
                }
                else
                {
                    sum += 3 * (test[i] - '0');
                }
            }
            if (10 - (sum%10) == checkDigit)
            {
                Console.WriteLine("Kod EAN-13 jest poprawny");
            }
            else
            {
                Console.WriteLine("Kod EAN-13 jest niepoprawny");
            }
        }
    }
}
