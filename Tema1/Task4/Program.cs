using System;

namespace Function;
class Program
{
    static void Main()
    {
        Console.Write("Введите x: ");
        double x = Convert.ToDouble(Console.ReadLine());

        if (x > 2.8 && x < 6)
        {
            double y = (x - 1) / (x + 1);
            Console.WriteLine($"y = {y}");
        }
        else if (x > 6)
        {
            double y = Math.Exp(x) + Math.Sin(x);
            Console.WriteLine($"y = {y}");
        }
    }
}