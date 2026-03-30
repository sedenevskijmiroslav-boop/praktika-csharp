namespace Notifications;

public abstract class NotificationFactory
{
    public abstract INotification CreateNotification(params object[] args);
}