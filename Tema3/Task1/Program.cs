using System;

namespace Metods;
class Privates
{
    int a;
    int b;
    public Privates(int aSquSum, int bSquSum)
    {
        a = aSquSum;
        b = bSquSum;
    }
    public double FirstMetod()
    {
        return b * b * b - 4 * Math.Sqrt(a);
    }
    public double SecondMetod()
    {
        return (double)a / b * ((double)a / b);
    }
    public void Show()
    {
        Console.WriteLine($"a = {a}, b = {b}");
    }
}
class Program
{
    static void Main()
    {
        Privates obj = new Privates(12, 4);

        obj.Show();
        Console.WriteLine($"Метод 1: {obj.FirstMetod()}");
        Console.WriteLine($"Метод 2: {obj.SecondMetod()}");
    }
}