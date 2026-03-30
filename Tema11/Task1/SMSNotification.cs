using System;

namespace Notifications;

public sealed class SMSNotification : INotification
{
    private readonly string _phoneNumber;
    private readonly string _message;

    public SMSNotification(string phoneNumber, string message)
    {
        _phoneNumber = phoneNumber;
        _message = message;
    }

    public void Send()
    {
        Console.WriteLine("Отправка SMS:");
        Console.WriteLine($"  Номер: {_phoneNumber}");
        Console.WriteLine($"  Сообщение: {_message}");
    }
}