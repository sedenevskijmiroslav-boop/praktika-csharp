using System;

namespace SecuritySystem;

public sealed class AlarmSystem
{
    private bool _isActive;

    public void Activate()
    {
        if (_isActive)
        {
            Console.WriteLine("Сигнализация уже активирована.");
            return;
        }

        _isActive = true;
        Console.WriteLine("Сигнализация активирована.");
    }

    public void Deactivate()
    {
        if (!_isActive)
        {
            Console.WriteLine("Сигнализация уже деактивирована.");
            return;
        }

        _isActive = false;
        Console.WriteLine("Сигнализация деактивирована.");
    }

    public bool IsActive()
    {
        return _isActive;
    }
}