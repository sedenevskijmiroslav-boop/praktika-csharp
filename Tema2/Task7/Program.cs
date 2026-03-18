using System;

namespace PodstrokaPosition;
class Program
{
    static void Main()
    {
        Console.Write("Введите исходную строку: ");
        string text = Console.ReadLine();

        Console.Write("Введите подстроку для вставки: ");
        string substring = Console.ReadLine() + " ";

        Console.Write("Введите позицию для вставки (от 0 до " + text.Length + "): ");
        int position = Convert.ToInt32(Console.ReadLine());

        string result = text.Insert(position, substring);

        Console.WriteLine($"\nИсходная строка: {text}");
        Console.WriteLine($"Вставка: '{substring}' на позицию {position}");
        Console.WriteLine($"Результат: {result}");
    }
}