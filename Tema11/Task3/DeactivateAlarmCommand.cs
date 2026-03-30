namespace SecuritySystem;

public sealed class DeactivateAlarmCommand : ICommand
{
    private readonly AlarmSystem _alarmSystem;

    public DeactivateAlarmCommand(AlarmSystem alarmSystem)
    {
        _alarmSystem = alarmSystem;
    }

    public void Execute()
    {
        _alarmSystem.Deactivate();
    }
}