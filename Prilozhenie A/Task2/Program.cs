using System;

namespace Chislo;

class Program
{
    static void Main()
    {
        Console.Write("Введите трёхзначное число: ");

        int number = Convert.ToInt32(Console.ReadLine());

        int firstNumber = number / 100;

        int lastNumber = number % 10;

        Console.WriteLine("Первая цифра: " + firstNumber);
        Console.WriteLine("Последняя цифра: " + lastNumber);
    }
}