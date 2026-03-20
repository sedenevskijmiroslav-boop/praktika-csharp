using System;

namespace ExtendetMetod;
public static class DoubleExtensions
{
    public static double RoundTo(this double number, int decimals)
    {
        return Math.Round(number, decimals);
    }
}
class Program
{
    static void Main()
    {
        double number = 8.7908374859;

        Console.WriteLine($"Исходное число: {number}");
        Console.WriteLine($"Округление до 2 знаков: {number.RoundTo(2)}");
        Console.WriteLine($"Округление до 3 знаков: {number.RoundTo(3)}");
        Console.WriteLine($"Округление до 4 знаков: {number.RoundTo(4)}");
    }
}