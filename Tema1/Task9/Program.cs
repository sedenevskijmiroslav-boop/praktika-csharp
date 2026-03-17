using System;

namespace TabulFunction;
class Program
{
    static void Main()
    {
        double a = 2;    
        double b = 7;    
        int m = 15;      

        double h = (b - a) / m;
        double x = a;

        Console.WriteLine($"Табулирование функции arctg(x) на отрезке [{a}, {b}] c шагом {h:F4}");
        Console.WriteLine("     x        y");

        for (int i = 0; i <= m; i++)
        {
            double y = Math.Atan(x);
            Console.WriteLine($"{x,8:F4}  {y,8:F4}");
            x = x + h;
        }
    }
}