using System;

namespace Even;
class Program
{
    static void Main()
    {
        Console.Write("Введите двузначное число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        int sum = (number / 10) + (number % 10);

        if (sum % 2 == 0)
        {
            Console.WriteLine("Четное");
        }
        else
        {
            Console.WriteLine("Не четное");
        }
    }
}