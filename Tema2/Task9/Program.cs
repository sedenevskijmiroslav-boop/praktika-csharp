using System;
using System.Text;

namespace EndStringBuilder;
class Program
{
    static void Main()
    {
        StringBuilder sb = new StringBuilder();

        sb.Append("Сегодня очень даже неплохой день");
        Console.WriteLine($"Текст: {sb}");

        Console.Write("Введите подстроку для проверки: ");
        string podstroka = Console.ReadLine();

        bool End = false;

        string text = sb.ToString();

        if (podstroka.Length <= text.Length)
        {
            string endOfText = text.Substring(text.Length - podstroka.Length);

            if (endOfText == podstroka)
            {
                End = true;
            }
        }

        if (End)
        {
            Console.WriteLine($"Да, текст заканчивается на '{podstroka}'");
        }
        else
        {
            Console.WriteLine($"Нет, текст не заканчивается на '{podstroka}'");
        }
    }
}