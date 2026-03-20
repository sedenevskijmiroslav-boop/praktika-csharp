using System;

namespace LeftRightNumber;
class Program
{
    static void Main()
    {
        Console.Write("Введите число K: ");
        int k = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите первую цифру D1 (1-9): ");
        int d1 = Convert.ToInt32(Console.ReadLine());

        AddLeftDigit(d1, ref k);
        Console.WriteLine($"После добавления {d1}: {k}");

        Console.Write("Введите вторую цифру D2 (1-9): ");
        int d2 = Convert.ToInt32(Console.ReadLine());

        AddLeftDigit(d2, ref k);
        Console.WriteLine($"После добавления {d2}: {k}");
    }

    static void AddLeftDigit(int d, ref int k)
    {
        int multiplier = 10;

        while (multiplier <= k)
        {
            multiplier *= 10;
        }

        k = d * multiplier + k;
    }
}