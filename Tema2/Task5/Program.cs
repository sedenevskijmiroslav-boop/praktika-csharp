using System;

namespace UnicElements;
class Program
{
    static void Main()
    {
        int[][] numbers = new int[4][];

        numbers[0] = new int[] { 1, 2, 2, 3, 3 };
        numbers[1] = new int[] { 5, 5, 5, 5 };
        numbers[2] = new int[] { 7, 8, 9, 7, 8 };
        numbers[3] = new int[] { 4, 4, 5, 6, 8, 9 };

        for (int i = 0; i < numbers.Length; i++)
        {
            Console.Write($"Строка {i}: ");
            for (int j = 0; j < numbers[i].Length; j++)
            {
                Console.Write(numbers[i][j] + " ");
            }
            Console.WriteLine();
        }

        int bestRow = 0;
        int maxUnic = 0;

        for (int i = 0; i < numbers.Length; i++)
        {
            List<int> uniques = new List<int>();

            for (int j = 0; j < numbers[i].Length; j++)
            {
                int currentNumber = numbers[i][j];
                bool found = false;

                for (int k = 0; k < uniques.Count; k++)
                {
                    if (uniques[k] == currentNumber)
                    {
                        found = true;
                        break;
                    }
                }

                if (!found)
                {
                    uniques.Add(currentNumber);
                }
            }

            int uniqueCount = uniques.Count;
            Console.WriteLine($"Строка {i}: {uniqueCount} уникальных");

            if (uniqueCount > maxUnic)
            {
                maxUnic = uniqueCount;
                bestRow = i;
            }
        }

        Console.WriteLine($"\nЛучшая строка: {bestRow}");
        Console.WriteLine($"Уникальных элементов: {maxUnic}");

        Console.Write("Элементы строки: ");
        for (int j = 0; j < numbers[bestRow].Length; j++)
        {
            Console.Write(numbers[bestRow][j] + " ");
        }
    }
}