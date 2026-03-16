using System;

namespace Rasstojanie;

class Program
{
    static void Main()
    {
        Console.WriteLine("Вычисление расстояния между населенными пунктами.");
        Console.WriteLine("Введите исходные данные:");

        Console.Write("Масштаб карты (количество километров в одном сантиметре) --> ");
        double mashtab = Convert.ToDouble(Console.ReadLine());

        Console.Write("Расстояние между точками, изображающими населенные пункты (см) --> ");
        double rasstOnMap = Convert.ToDouble(Console.ReadLine());

        double realRasst = mashtab * rasstOnMap;

        Console.WriteLine("Расстояние между населенными пунктами " + realRasst + " км.");

        Console.ReadKey();
    }
}