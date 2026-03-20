using System;

namespace DegreeRecursion;
class Program
{
    static void Main()
    {
        Console.Write("Введите основание: ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Введите показатель: ");
        int n = Convert.ToInt32(Console.ReadLine());

        double result = Power(a, n);
        Console.WriteLine($"{a}^{n} = {result}");
    }
    static double Power(int a, int n)
    {
        if (n == 0)
        {
            return 1;
        }

        if (n < 0)
        {
            return 1.0 / Power(a, -n);
        }

        return a * Power(a, n - 1);
    }
}