using System;

namespace SmartDevices;

public class Smartphone : SmartDevice, ICanPlayMusic, ICanMakeCalls
{
    public string PhoneNumber { get; set; }
    private bool isPlaying;
    private bool isOnCall;

    public Smartphone(string name, string brand, int power, string phoneNumber)
        : base(name, brand, power)
    {
        PhoneNumber = phoneNumber;
        isPlaying = false;
        isOnCall = false;
    }

    public void PlayMusic()
    {
        isPlaying = true;
        Console.WriteLine($"{Name} воспроизводит музыку через Spotify");
    }

    public void StopMusic()
    {
        isPlaying = false;
        Console.WriteLine($"{Name} останавливает музыку");
    }

    public void SetVolume(int volume)
    {
        Console.WriteLine($"{Name}: громкость изменена на {volume}");
    }
    public void MakeCall(string number)
    {
        isOnCall = true;
        Console.WriteLine($"{Name} звонит на номер {number}");
    }

    public void AnswerCall()
    {
        isOnCall = true;
        Console.WriteLine($"{Name} отвечает на звонок");
    }

    public void EndCall()
    {
        isOnCall = false;
        Console.WriteLine($"{Name} завершает разговор");
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"  Тип: Смартфон, Номер: {PhoneNumber}");
    }
}