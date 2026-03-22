using System;

namespace SmartDevices;
public class SmartSpeaker : SmartDevice, ICanPlayMusic
{
    public int MaxVolume { get; set; }
    private bool isPlaying;

    public SmartSpeaker(string name, string brand, int power, int maxVolume)
        : base(name, brand, power)
    {
        MaxVolume = maxVolume;
        isPlaying = false;
    }

    public void PlayMusic()
    {
        isPlaying = true;
        Console.WriteLine($"{Name} начинает воспроизведение музыки");
    }

    public void StopMusic()
    {
        isPlaying = false;
        Console.WriteLine($"{Name} останавливает музыку");
    }

    public void SetVolume(int volume)
    {
        if (volume <= MaxVolume)
        {
            Console.WriteLine($"{Name}: громкость установлена на {volume}");
        }
        else
        {
            Console.WriteLine($"{Name}: максимальная громкость {MaxVolume}");
        }
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"  Тип: Умная колонка, Макс. громкость: {MaxVolume}");
    }
}