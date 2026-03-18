using System;

namespace SumElements;
class Program
{
    static void Main()
    {
        int[,] matrix = {
            { 12, 25, 33 },
            { 41, 50, 19 },
            { 28, 32, 40 }
        };

        Console.WriteLine("Исходная матрица:");
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }

        int rowNumber = 1; 

        int sum = 0;
        for (int j = 0; j < 3; j++)
        {
            sum = sum + matrix[rowNumber, j];
        }

        Console.WriteLine($"\nСумма элементов в строке {rowNumber}: {sum}");

        if (sum % 10 == 0)
        {
            Console.WriteLine("Верно: сумма оканчивается цифрой 0");
        }
        else
        {
            Console.WriteLine("Неверно: сумма оканчивается цифрой {0}", sum % 10);
        }
    }
}