namespace HotelServices;

public abstract class RoomServiceDecorator : IRoomService
{
    protected readonly IRoomService _innerService;

    protected RoomServiceDecorator(IRoomService innerService)
    {
        _innerService = innerService;
    }

    public virtual string GetServiceDetails()
    {
        return _innerService.GetServiceDetails();
    }

    public virtual double GetCost()
    {
        return _innerService.GetCost();
    }
}