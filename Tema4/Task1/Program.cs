using System;

namespace MetodPrime;
public static class PrimeUtility
{
    public static bool IsPrime(int number)
    {
        if (number < 2)
        {
            return false;
        }

        for (int i = 2; i * i <= number; i++)
        {
            if (number % i == 0)
            {
                return false;
            }
        }

        return true;
    }
}
class Program
{
    static void Main()
    {
        Console.Write("Введите число: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (PrimeUtility.IsPrime(number))
        {
            Console.WriteLine($"Число {number} - простое");
        }
        else
        {
            Console.WriteLine($"Число {number} - не простое");
        }
    }
}