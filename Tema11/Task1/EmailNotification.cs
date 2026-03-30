using System;

namespace Notifications;

public sealed class EmailNotification : INotification
{
    private readonly string _to;
    private readonly string _subject;
    private readonly string _body;

    public EmailNotification(string to, string subject, string body)
    {
        _to = to;
        _subject = subject;
        _body = body;
    }

    public void Send()
    {
        Console.WriteLine("Отправка Email:");
        Console.WriteLine($"  Кому: {_to}");
        Console.WriteLine($"  Тема: {_subject}");
        Console.WriteLine($"  Текст: {_body}");
    }
}