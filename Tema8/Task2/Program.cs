using System;

namespace PriorityQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            PriorityTaskManager manager = new PriorityTaskManager();

            manager.AddTask("Критическая ошибка", 1);
            manager.AddTask("Обновление", 3);
            manager.AddTask("Отчет", 2);

            manager.ShowAllTasks();

            Console.WriteLine("\nВыполняем задачи:");
            manager.ExecuteNextTask();
            manager.ExecuteNextTask();

            Console.WriteLine("\nОсталось:");
            manager.ShowAllTasks();
        }
    }
}