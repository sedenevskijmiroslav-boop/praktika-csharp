using System;

namespace LatniLetters;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();

        string[] words = text.Split(' ');

        int count = 0;

        for (int i = 0; i < words.Length; i++)
        {
            bool Latin = true;

            for (int j = 0; j < words[i].Length; j++)
            {
                char ch = words[i][j];

                bool orLatin = (ch >= 'a' && ch <= 'z') || (ch >= 'A' && ch <= 'Z');

                if (!orLatin)
                {
                    Latin = false;
                    break; 
                }
            }

            if (words[i].Length > 0 && Latin)
            {
                count++;
            }
        }

        Console.WriteLine($"Количество слов, содержащих только латинские буквы: {count}");
    }
}