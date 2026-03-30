namespace SecuritySystem;

public sealed class ActivateAlarmCommand : ICommand
{
    private readonly AlarmSystem _alarmSystem;

    public ActivateAlarmCommand(AlarmSystem alarmSystem)
    {
        _alarmSystem = alarmSystem;
    }

    public void Execute()
    {
        _alarmSystem.Activate();
    }
}