namespace PriorityQueue
{
    public class PriorityItem<T>
    {
        public T Item { get; set; }
        public int Priority { get; set; }

        public PriorityItem(T item, int priority)
        {
            Item = item;
            Priority = priority;
        }
    }
}