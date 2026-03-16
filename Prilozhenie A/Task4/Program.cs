using System;

namespace TriChisla;
class Program
{
    static void Main()
    {
        Console.Write("a = ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("b = ");
        int b = Convert.ToInt32(Console.ReadLine());

        Console.Write("c = ");
        int c = Convert.ToInt32(Console.ReadLine());

        int product = a * b * c;

        Console.WriteLine($"{a}*{b}*{c}={c}*{b}*{a}");
    }
}