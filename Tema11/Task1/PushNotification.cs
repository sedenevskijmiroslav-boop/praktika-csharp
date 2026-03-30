using System;

namespace Notifications;

public sealed class PushNotification : INotification
{
    private readonly string _deviceId;
    private readonly string _message;

    public PushNotification(string deviceId, string message)
    {
        _deviceId = deviceId;
        _message = message;
    }

    public void Send()
    {
        Console.WriteLine("Отправка Push:");
        Console.WriteLine($"  Устройство: {_deviceId}");
        Console.WriteLine($"  Сообщение: {_message}");
    }
}