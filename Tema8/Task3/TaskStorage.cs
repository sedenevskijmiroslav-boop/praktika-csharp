using System.Collections.Generic;
using System.Linq;

namespace TaskManagement
{
    public class TaskStorage<T>
    {
        private List<T> tasks;

        public TaskStorage()
        {
            tasks = new List<T>();
        }

        public void Add(T task)
        {
            tasks.Add(task);
        }

        public bool Remove(T task)
        {
            return tasks.Remove(task);
        }

        public List<T> GetAll()
        {
            return tasks;
        }

        public T Find(System.Func<T, bool> predicate)
        {
            return tasks.FirstOrDefault(predicate);
        }

        public int Count => tasks.Count;
    }
}