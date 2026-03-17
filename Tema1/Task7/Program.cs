using System;

namespace Diapazon;
class Program
{
    static void Main()
    {
        Console.Write("Введите начало диапазона (A): ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите конец диапазона (B): ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите цифру (X): ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write($"Числа закначивающиеся на {x} в диапазоне: ");

        for (int i = a; i <= b; i++)
        {
            if (i % 10 == x)
            {
                Console.Write(i + " ");
            }
        }
        Console.WriteLine();
    }
}