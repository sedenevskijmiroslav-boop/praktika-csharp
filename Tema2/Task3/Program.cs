using System;

namespace MatrixSquares;
class Program
{
    static void Main()
    {
        Console.WriteLine("Enter n: ");
        int n = Convert.ToInt16(Console.ReadLine());

        int[,] arr = new int[n, n];

        Console.WriteLine("Enter a: ");
        int a = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Enter b: ");
        int b = Convert.ToInt16(Console.ReadLine());

        Random r = new Random();
        Console.WriteLine("Array: \n");

        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                arr[i, j] = r.Next(a, b + 1);
                Console.Write(arr[i, j] + " ");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nEnter E: ");
        int e = Convert.ToInt16(Console.ReadLine());

        Console.WriteLine("Enter F: ");
        int f = Convert.ToInt16(Console.ReadLine());

        int sumSquares = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                int element = arr[i, j];
                if (element > e && element <= f)
                {
                    sumSquares = sumSquares + element * element;
                }
            }
        }

        Console.WriteLine($"Sum squares of elements in ({e}, {f}] = {sumSquares}");

        Console.WriteLine("\nEnter k: ");
        int k = Convert.ToInt16(Console.ReadLine());

        int sumColumn = 0;
        for (int i = 0; i < n; i++)
        {
            sumColumn = sumColumn + arr[i, k];
        }

        Console.WriteLine($"Sum of {k} column = {sumColumn}");
    }
}