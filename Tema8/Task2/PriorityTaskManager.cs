using System;

namespace PriorityQueue
{
    public class PriorityTaskManager
    {
        private MyPriorityQueue<string> taskQueue;

        public PriorityTaskManager()
        {
            taskQueue = new MyPriorityQueue<string>();
        }

        public void AddTask(string task, int priority)
        {
            taskQueue.Enqueue(task, priority);
            Console.WriteLine($"Добавлено: {task} (приор: {priority})");
        }

        public void ExecuteNextTask()
        {
            string task = taskQueue.Dequeue();
            Console.WriteLine($"Выполнено: {task}");
        }

        public void ShowAllTasks()
        {
            Console.WriteLine("Очередь задач:");
            taskQueue.ShowAll();
        }
    }
}