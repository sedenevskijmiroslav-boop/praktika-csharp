using System;
using System.Collections.Generic;

namespace PriorityQueue
{
    public class MyPriorityQueue<T>
    {
        private List<PriorityItem<T>> items;

        public MyPriorityQueue()
        {
            items = new List<PriorityItem<T>>();
        }

        public int Count => items.Count;

        public void Enqueue(T item, int priority)
        {
            items.Add(new PriorityItem<T>(item, priority));
            items.Sort((x, y) => x.Priority.CompareTo(y.Priority));
        }

        public T Dequeue()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Очередь пуста");

            T item = items[0].Item;
            items.RemoveAt(0);
            return item;
        }

        public T Peek()
        {
            if (items.Count == 0)
                throw new InvalidOperationException("Очередь пуста");

            return items[0].Item;
        }

        public void ShowAll()
        {
            foreach (var item in items)
            {
                Console.WriteLine($"  {item.Item} (приор: {item.Priority})");
            }
        }
    }
}