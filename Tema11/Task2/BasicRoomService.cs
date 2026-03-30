namespace HotelServices;

public sealed class BasicRoomService : IRoomService
{
    public string GetServiceDetails()
    {
        return "Базовая уборка номера";
    }

    public double GetCost()
    {
        return 20.0;
    }
}