using System;

namespace SmartDevices;

class Program
{
    static void Main()
    {
        SmartDevice[] devices = new SmartDevice[]
        {
            new SmartSpeaker("Echo Dot", "Amazon", 10, 10),
            new Smartphone("iPhone 14", "Apple", 20, "+375 33 682-59-44"),
            new SmartSpeaker("HomePod Mini", "Apple", 15, 12),
            new Smartphone("Galaxy S23", "Samsung", 25, "+375 33 682-59-33"),
            new SmartSpeaker("Yandex Station", "Yandex", 30, 15)
        };

        Console.WriteLine(" Все умные устройства ");
        foreach (SmartDevice device in devices)
        {
            device.ShowInfo();
            Console.WriteLine();
        }

        Console.WriteLine("\n Устройства, которые могут звонить ");
        FindDevicesThatCanMakeCalls(devices);

        Console.WriteLine("\n Демонстрация работы ");
        DemoDevices(devices);
    }

    static void FindDevicesThatCanMakeCalls(SmartDevice[] devices)
    {
        bool found = false;

        foreach (SmartDevice device in devices)
        {
            if (device is ICanMakeCalls callable)
            {
                device.ShowInfo();
                callable.MakeCall("+375 33 682-59-67");
                callable.EndCall();
                Console.WriteLine();
                found = true;
            }
        }

        if (!found)
        {
            Console.WriteLine("Устройства, способные звонить, не найдены");
        }
    }

    static void DemoDevices(SmartDevice[] devices)
    {
        foreach (SmartDevice device in devices)
        {
            if (device is ICanPlayMusic musicPlayer)
            {
                musicPlayer.PlayMusic();
                musicPlayer.SetVolume(7);
                musicPlayer.StopMusic();
                Console.WriteLine();
            }

            if (device is ICanMakeCalls phone)
            {
                phone.MakeCall("+375 29 123-12-34");
                phone.AnswerCall();
                phone.EndCall();
                Console.WriteLine();
            }
        }
    }
}