using System;

namespace Diametr;
class Program
{
    static void Main()
    {
        Console.Write("Введите радиус окружности: ");
        double radius = Convert.ToDouble(Console.ReadLine());

        double diametr = 2 * radius;

        Console.WriteLine($"Диаметр окружности = {diametr}");
    }
}