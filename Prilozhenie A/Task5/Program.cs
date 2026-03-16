using System;

namespace Perestanovka;
class Program
{
    static void Main()
    {
        Console.Write("Введите трёхзначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int hundreds = number / 100;
        int tens = (number / 10) % 10;        
        int ones = number % 10;         

        int result = hundreds * 100 + ones * 10 + tens;

        Console.WriteLine($"Результат: {result}");
    }
}