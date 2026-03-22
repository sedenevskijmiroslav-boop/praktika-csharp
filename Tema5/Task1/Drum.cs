using System;

namespace MusicalInstruments;
public class Drum : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Барабаны играют: бам бам бам");
    }
}