using System;
using System.Collections;

namespace LoggingSystem
{
    public class Logger
    {
        private Stack logStack;

        public Logger()
        {
            logStack = new Stack();
        }

        public void AddLog(string message)
        {
            logStack.Push(new LogEntry(message));
            Console.WriteLine($"Добавлено: {message}");
        }

        public void RemoveLastLog()
        {
            if (logStack.Count > 0)
            {
                LogEntry removed = (LogEntry)logStack.Pop();
                Console.WriteLine($"Удалено: {removed.Message}");
            }
        }

        public void ShowAllLogs()
        {
            Console.WriteLine("\nВсе логи");
            foreach (LogEntry entry in logStack)
            {
                Console.WriteLine(entry);
            }
        }

        public int GetCount()
        {
            return logStack.Count;
        }
    }
}