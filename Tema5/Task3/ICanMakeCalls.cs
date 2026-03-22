namespace SmartDevices;

public interface ICanMakeCalls
{
    void MakeCall(string number);
    void AnswerCall();
    void EndCall();
}