using System;

namespace MusicalInstruments;
public abstract class MusicalInstrument
{
    public abstract void PlaySound();

    public virtual void Tune()
    {
        Console.WriteLine("Настройка музыкального инструмента...");
    }
}