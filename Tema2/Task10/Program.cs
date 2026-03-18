using System;
using System.Text.RegularExpressions;

namespace RegularCheck;
class Program
{
    static void Main()
    {
        Console.Write("Введите строку: ");
        string text = Console.ReadLine();

        Regex regex = new Regex(@"^[A-ZА-Я]");

        bool startsCapital = regex.IsMatch(text);

        if (startsCapital)
        {
            Console.WriteLine("Строка с заглавной буквы");
        }
        else
        {
            Console.WriteLine("Строка не с заглавной буквы");
        }
    }
}