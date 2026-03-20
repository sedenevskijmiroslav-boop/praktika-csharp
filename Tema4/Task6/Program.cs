using System;

namespace TrianglePerim;
class Program
{
    static void Main()
    {
        Console.WriteLine("Введите координаты точки A:");
        Console.Write("xA = ");
        double xA = Convert.ToDouble(Console.ReadLine());
        Console.Write("yA = ");
        double yA = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nВведите координаты точки B:");
        Console.Write("xB = ");
        double xB = Convert.ToDouble(Console.ReadLine());
        Console.Write("yB = ");
        double yB = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nВведите координаты точки C:");
        Console.Write("xC = ");
        double xC = Convert.ToDouble(Console.ReadLine());
        Console.Write("yC = ");
        double yC = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("\nВведите координаты точки D:");
        Console.Write("xD = ");
        double xD = Convert.ToDouble(Console.ReadLine());
        Console.Write("yD = ");
        double yD = Convert.ToDouble(Console.ReadLine());

        double perimABC = Perim(xA, yA, xB, yB, xC, yC);
        double perimABD = Perim(xA, yA, xB, yB, xD, yD);
        double perimACD = Perim(xA, yA, xC, yC, xD, yD);

        Console.WriteLine("\nРезультаты");
        Console.WriteLine($"Периметр треугольника ABC: {perimABC:F2}");
        Console.WriteLine($"Периметр треугольника ABD: {perimABD:F2}");
        Console.WriteLine($"Периметр треугольника ACD: {perimACD:F2}");
    }

    static double Perim(double xA, double yA, double xB, double yB, double xC, double yC)
    {
        double sideAB = Distance(xA, yA, xB, yB);
        double sideBC = Distance(xB, yB, xC, yC);
        double sideAC = Distance(xA, yA, xC, yC);

        return sideAB + sideBC + sideAC;
    }

    static double Distance(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }
}