using System;

namespace ServerShutdown
{
    public class ServerShutdownManager
    {
        public event ServerShutdownHandler ServerShuttingDown;

        public void Shutdown()
        {
            Console.WriteLine("Инициировано завершение работы сервера\n");

            if (ServerShuttingDown != null)
            {
                ServerShuttingDown("Сервер будет остановлен через 10 секунд");
            }
            else
            {
                Console.WriteLine("Нет подписчиков на событие");
            }

            Console.WriteLine("\nЗавершение работы сервера выполнено");
        }
    }
}