using System;

namespace FactorialCalculator;

class Program
{
    static void Main()
    {
        int number1 = 5;
        double number2 = 3.0;

        CalculateFactorial(in number1, out long factLong);
        Console.WriteLine($"Факториал 5 = {factLong}");

        CalculateFactorial(in number2, out double factDouble);
        Console.WriteLine($"Факториал 3.0 = {factDouble}");
    }

    static void CalculateFactorial(in int number, out long result)
    {
        if (number < 0)
        {
            throw new ArgumentException("Факториал отрицательного числа не определен");
        }

        long fact = 1;
        for (int i = 2; i <= number; i++)
        {
            fact *= i;
        }

        result = fact;
    }

    static void CalculateFactorial(in double number, out double result)
    {
        if (number < 0)
        {
            throw new ArgumentException("Факториал отрицательного числа не определен");
        }

        int n = (int)Math.Round(number);

        long fact = 1;
        for (int i = 2; i <= n; i++)
        {
            fact *= i;
        }

        result = fact;
    }
}