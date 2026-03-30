using System;
using System.Collections.Generic;

namespace SecuritySystem;

public sealed class SecurityPanel
{
    private readonly List<ICommand> _history = new();
    private ICommand? _lastExecuted;

    public void SetAndExecute(ICommand command)
    {
        command.Execute();
        _history.Add(command);
        _lastExecuted = command;
    }

    public void ShowHistory()
    {
        Console.WriteLine("История команд:");
        if (_history.Count == 0)
        {
            Console.WriteLine("  Нет выполненных команд.");
            return;
        }

        for (var i = 0; i < _history.Count; i++)
        {
            Console.WriteLine($"  {i + 1}. {_history[i].GetType().Name}");
        }
    }

    public void ReexecuteLast()
    {
        if (_lastExecuted is null)
        {
            Console.WriteLine("Нет последней команды для повторного выполнения.");
            return;
        }

        Console.WriteLine("Повторное выполнение последней команды:");
        _lastExecuted.Execute();
        _history.Add(_lastExecuted);
    }
}