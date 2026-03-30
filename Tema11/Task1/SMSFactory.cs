namespace Notifications;

public sealed class SMSFactory : NotificationFactory
{
    public override INotification CreateNotification(params object[] args)
    {
        string phoneNumber = args.Length > 0 && args[0] is string ? (string)args[0] : string.Empty;
        string message = args.Length > 1 && args[1] is string ? (string)args[1] : string.Empty;

        return new SMSNotification(phoneNumber, message);
    }
}