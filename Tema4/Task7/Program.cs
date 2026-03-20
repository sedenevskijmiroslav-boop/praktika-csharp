using System;

namespace StringLengthReturn;
class Program
{
    static void Main()
    {
        string singleString = "Hello";
        int length1 = GetLength(singleString);
        Console.WriteLine($"Длина строки \"{singleString}\": {length1}");

        string[] stringArray = new string[] { "Hi", "Hello " };
        int length2 = GetLength(stringArray);
        Console.WriteLine($"Общая длина массива [\"Hi\", \"Hello\"]: {length2}");
    }

    static int GetLength(string str)
    {
        return str.Length;
    }

    static int GetLength(string[] strings)
    {
        int total = 0;

        for (int i = 0; i < strings.Length; i++)
        {
            total = total + strings[i].Length;
        }

        return total;
    }
}