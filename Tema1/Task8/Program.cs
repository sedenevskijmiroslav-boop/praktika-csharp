using System;

namespace Degradation;
class Program
{
    static void Main()
    {
        Console.Write("Введите A: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите B: ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine($"Числа между {a} и {b} (не включая {a} и {b}):");

        int n = 0;

        for (int i = b - 1; i > a; i--)
        {
            Console.Write(i + " ");
            n++;
        }

        Console.WriteLine();
        Console.WriteLine($"Количество чисел: {n}");
    }
}