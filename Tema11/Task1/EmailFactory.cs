namespace Notifications;

public sealed class EmailFactory : NotificationFactory
{
    public override INotification CreateNotification(params object[] args)
    {
        string to = args.Length > 0 && args[0] is string ? (string)args[0] : string.Empty;
        string subject = args.Length > 1 && args[1] is string ? (string)args[1] : string.Empty;
        string body = args.Length > 2 && args[2] is string ? (string)args[2] : string.Empty;

        return new EmailNotification(to, subject, body);
    }
}