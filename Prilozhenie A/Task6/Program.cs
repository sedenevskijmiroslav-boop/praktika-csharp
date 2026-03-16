using System;

namespace Function;

class Program
{
    static void Main()
    {
        double x = 2.7;

        double y = 3 * x * x + Math.Exp(Math.Sqrt(x)) / (2 * Math.PI) - Math.Log(Math.Sqrt(3 - Math.Pow(Math.Sin(x), 2)));

        Console.WriteLine($"x = {x}");
        Console.WriteLine($"y = {y}");
    }
}