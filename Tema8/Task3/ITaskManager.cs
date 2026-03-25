namespace TaskManagement
{
    public interface ITaskManager<T>
    {
        void AddTask(T task);
        void CompleteTask(T task);
    }
}