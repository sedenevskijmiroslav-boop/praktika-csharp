using System;

namespace MultiplySquares;
class Program
{
    static void Main()
    {
        const int n = 25;

        double[] array = new double[n];
        Random rnd = new();

        for (var i = 0; i < n; i++)
        {
            array[i] = Math.Round(rnd.NextDouble() * 26 - 5, 2);
        }

        Console.WriteLine("Исходный массив:");

        foreach (double item in array)
        {
            Console.WriteLine($"{item:F2}");
        }

        double min = array[0];
        double max = array[0];

        for (var i = 1; i < n; i++)
        {
            if (array[i] < min)
            {
                min = array[i];
            }

            if (array[i] > max)
            {
                max = array[i];
            }
        }

        double minSquare = min * min;
        double maxSquare = max * max;

        for (var i = 0; i < n; i++)
        {
            if (array[i] >= 0)
            {
                array[i] *= minSquare;
            }
            else
            {
                array[i] *= maxSquare;
            }
        }

        Array.Sort(array);

        Console.WriteLine("После преобразования:");

        foreach (double item in array)
        {
            Console.WriteLine($"{item:F2}");
        }

        Console.Write("Введите k: ");
        double k = Math.Round(Convert.ToDouble(Console.ReadLine()), 2);

        double epsilon = 0.01;

        int left = 0;
        int right = n - 1;
        int index = -1;

        while (left <= right)
        {
            int mid = (left + right) / 2;

            if (Math.Abs(array[mid] - k) < epsilon)
            {
                index = mid;
                break;
            }

            if (array[mid] < k)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        Console.WriteLine($"Индекс: {index}");
    }
}