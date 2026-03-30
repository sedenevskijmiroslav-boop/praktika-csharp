using System;
using Notifications;

internal static class Program
{
    private static void Main()
    {
        NotificationFactory emailFactory = new EmailFactory();
        INotification email = emailFactory.CreateNotification("miroslav@example.com", "Приветствие", "Здравствуйте!");
        email.Send();

        NotificationFactory smsFactory = new SMSFactory();
        INotification sms = smsFactory.CreateNotification("+375331232312", "Ваш код: 7770");
        sms.Send();

        NotificationFactory pushFactory = new PushFactory();
        INotification push = pushFactory.CreateNotification("iphone 13pro", "У вас новое сообщение");
        push.Send();
    }
}