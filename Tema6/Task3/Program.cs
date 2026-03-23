using System;

namespace ServerShutdown
{
    class Program
    {
        static void Main(string[] args)
        {
            ServerShutdownManager server = new ServerShutdownManager();

            BackupService backup = new BackupService(server);
            AlertSystem alert = new AlertSystem(server);

            Console.WriteLine("СИСТЕМА УПРАВЛЕНИЯ СЕРВЕРОМ\n");

            server.Shutdown();
        }
    }
}