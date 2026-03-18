using System;

namespace EvenPositions;
class Program
{
    static void Main()
    {
        double[] numbers = { 2.5, 3.7, 1.8, 4.2, 5.1, 6.3, 7.9 };

        Console.Write("Массив: ");
        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write(numbers[i] + " ");
        }
        Console.WriteLine();

        double proizv = 1;

        for (int i = 0; i < numbers.Length; i = i + 2)
        {
            proizv = proizv * numbers[i];
        }

        Console.WriteLine($"Произведение чиесл на чётных позициях = {proizv}");
    }
}