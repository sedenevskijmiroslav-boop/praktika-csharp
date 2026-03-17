using System;

namespace SumOfSquares;
class Program
{
    static void Main()
    {
        Console.WriteLine("А должно быть меньше B");

        Console.Write("Введите A: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите B: ");
        int b = Convert.ToInt32(Console.ReadLine());

        int sum = 0;

        for (int i = a; i <= b; i++)
        {
            sum = sum + i * i;
        }

        Console.WriteLine($"Сумма квадратов от {a} до {b} = {sum}");
    }
}