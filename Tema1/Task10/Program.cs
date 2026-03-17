using System;

namespace Deliteli;
class Program
{
    static void Main()
    {
        Console.Write("Введите число n: ");
        int n = Convert.ToInt32(Console.ReadLine());

        int count = 0;

        for (int i = 1; i <= n; i++)
        {
            if (n % i == 0)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество делителей числа {n} = {count}");
    }
}