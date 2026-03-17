using System;

namespace SumOfNumbers;
class Program
{
    static void Main()
    {
        Console.Write("Введите четырёхзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sumFirstTwo = number / 1000 + (number / 100) % 10;
        int sumLastTwo = (number / 10) % 10 + number % 10;

        if (sumFirstTwo == sumLastTwo)
        {
            Console.WriteLine("Сумма равна");
        }
        else
        {
            Console.WriteLine("Сумма не равна");
        }
    }
}