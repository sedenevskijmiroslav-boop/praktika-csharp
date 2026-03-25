using System;

namespace LoggingSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Logger logger = new Logger();

            logger.AddLog("Приложение запущено");
            logger.AddLog("Пользователь вошел");
            logger.AddLog("Ошибка подключения");

            logger.ShowAllLogs();

            Console.WriteLine($"\nВсего записей: {logger.GetCount()}");

            logger.RemoveLastLog();

            Console.WriteLine($"\nОсталось записей: {logger.GetCount()}");
        }
    }
}