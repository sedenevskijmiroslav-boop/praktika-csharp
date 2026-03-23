using System;

namespace ServerShutdown
{
    public class BackupService
    {
        public BackupService(ServerShutdownManager manager)
        {
            manager.ServerShuttingDown += CreateBackup;
        }

        private void CreateBackup(string message)
        {
            Console.WriteLine("[BACKUP SERVICE] Создание резервной копии...");
            Console.WriteLine($"[BACKUP SERVICE] Сообщение: {message}");
            Console.WriteLine("[BACKUP SERVICE] Резервная копия успешно создана\n");
        }
    }
}