using System;

namespace MusicalInstruments;
public class Guitar : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Гитара играет: брынь, брынь");
    }
}