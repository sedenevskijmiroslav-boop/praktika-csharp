using System;

namespace ServerShutdown
{
    public class AlertSystem
    {
        public AlertSystem(ServerShutdownManager manager)
        {
            manager.ServerShuttingDown += NotifyAdmin;
        }

        private void NotifyAdmin(string message)
        {
            Console.WriteLine("[ALERT SYSTEM] Отправка уведомления администратору...");
            Console.WriteLine($"[ALERT SYSTEM] Сообщение: {message}");
            Console.WriteLine("[ALERT SYSTEM] Администратор оповещен\n");
        }
    }
}