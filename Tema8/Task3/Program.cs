using System;

namespace TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            TaskManager<Task> manager = new TaskManager<Task>();

            manager.AddTask(new Task("Убрать дома"));
            manager.AddTask(new Task("Купить продукты"));
            manager.AddTask(new Task("Позвонить маме"));

            manager.PrintTasks();

            manager.CompleteTask(new Task("Купить продукты"));

            manager.PrintTasks();
        }
    }
}