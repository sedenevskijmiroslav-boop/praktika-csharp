using System;

namespace TaskManagement
{
    public class TaskManager<T> : ITaskManager<T> where T : Task
    {
        private TaskStorage<T> storage;

        public TaskManager()
        {
            storage = new TaskStorage<T>();
        }

        public void AddTask(T task)
        {
            storage.Add(task);
            Console.WriteLine($"Добавлена задача: {task.Name}");
        }

        public void CompleteTask(T task)
        {
            T existingTask = storage.Find(t => t.Name == task.Name);

            if (existingTask != null)
            {
                existingTask.IsCompleted = true;
                Console.WriteLine($"Завершена задача: {existingTask.Name}");
            }
            else
            {
                Console.WriteLine($"Задача '{task.Name}' не найдена");
            }
        }

        public void PrintTasks()
        {
            Console.WriteLine("\nСписок задач");
            foreach (var task in storage.GetAll())
            {
                Console.WriteLine(task);
            }
            Console.WriteLine();
        }

        public int GetTaskCount()
        {
            return storage.Count;
        }
    }
}