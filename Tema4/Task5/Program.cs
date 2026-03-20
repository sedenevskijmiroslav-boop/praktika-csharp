using System;

namespace MusicalInstruments;

class Program
{
    static void Main()
    {
        Guitar guitar = new Guitar();
        Piano piano = new Piano();

        Console.WriteLine("Гитара");
        guitar.Tune();
        guitar.PlaySound();

        Console.WriteLine("\nПианино");
        piano.Tune();
        piano.PlaySound();
    }
}