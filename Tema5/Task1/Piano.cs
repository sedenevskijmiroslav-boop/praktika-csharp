using System;

namespace MusicalInstruments;
public class Piano : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Пианино играет: бэм бэм бэм");
    }
}