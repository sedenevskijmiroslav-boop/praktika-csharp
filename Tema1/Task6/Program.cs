using System;

namespace Monhts;
class Program
{
    static void Main()
    {
        Console.Write("Введите номер месяца: ");
        int month = Convert.ToInt32(Console.ReadLine());

        int monthsLeft = 12 - month;

        Console.WriteLine($"До конца года осталось {monthsLeft} месяцев");
    }
}