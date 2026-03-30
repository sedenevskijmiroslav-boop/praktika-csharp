using System;
using SecuritySystem;

internal static class Program
{
    private static void Main()
    {
        var alarm = new AlarmSystem();
        var panel = new SecurityPanel();

        var activateCommand = new ActivateAlarmCommand(alarm);
        var deactivateCommand = new DeactivateAlarmCommand(alarm);

        panel.SetAndExecute(activateCommand);
        panel.SetAndExecute(activateCommand);
        panel.SetAndExecute(deactivateCommand);

        Console.WriteLine();
        panel.ShowHistory();

        Console.WriteLine();
        panel.ReexecuteLast();

        Console.WriteLine();
        Console.WriteLine($"Текущее состояние сигнализации: {(alarm.IsActive() ? "Активна" : "Неактивна")}");
    }
}