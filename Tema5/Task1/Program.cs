using System;

namespace MusicalInstruments;
class Program
{
    static void Main()
    {
        MusicalInstrument[] instruments = new MusicalInstrument[]
        {
            new Guitar(),
            new Piano(),
            new Drum()
        };

        Console.WriteLine("Инструменты играют\n");

        foreach (var instrument in instruments)
        {
            instrument.PlaySound();
        }
    }
}