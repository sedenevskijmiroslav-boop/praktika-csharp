namespace HotelServices;

public sealed class AirportPickupDecorator : RoomServiceDecorator
{
    private readonly string _pickupDescription;
    private readonly double _pickupCost;

    public AirportPickupDecorator(IRoomService innerService, string pickupDescription = "Трансфер из аэропорта", double pickupCost = 25.0)
        : base(innerService)
    {
        _pickupDescription = pickupDescription;
        _pickupCost = pickupCost;
    }

    public override string GetServiceDetails()
    {
        return $"{_innerService.GetServiceDetails()} + {_pickupDescription}";
    }

    public override double GetCost()
    {
        return _innerService.GetCost() + _pickupCost;
    }
}