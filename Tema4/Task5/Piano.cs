using System;

namespace MusicalInstruments;

public class Piano : MusicalInstrument
{
    public override void PlaySound()
    {
        Console.WriteLine("Piano is playing");
    }

    public override void Tune()
    {
        Console.WriteLine("Настройка пианино: настраиваем клавиши");
    }
}