using System;

namespace DuplicateWords;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();

        string[] words = text.Split(' ');

        List<string> unicWords = new List<string>();

        for (int i = 0; i < words.Length; i++)
        {
            if (!unicWords.Contains(words[i]))
            {
                unicWords.Add(words[i]);
            }
        }

        string result = "";
        for (int i = 0; i < unicWords.Count; i++)
        {
            result = result + unicWords[i];
            if (i < unicWords.Count - 1)
            {
                result = result + " ";
            }
        }

        Console.WriteLine($"Исходная строка: {text}");
        Console.WriteLine($"Результат: {result}");
    }
}