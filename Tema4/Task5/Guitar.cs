using System;

namespace MusicalInstruments;
public class Guitar : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Guitar is playing");
    }

    public override void Tune()
    {
        Console.WriteLine("Настройка гитары: подтягиваем струны");
    }
}