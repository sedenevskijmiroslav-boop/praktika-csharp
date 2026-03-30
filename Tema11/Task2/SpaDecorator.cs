namespace HotelServices;

public sealed class SpaDecorator : RoomServiceDecorator
{
    private readonly string _spaDescription;
    private readonly double _spaCost;

    public SpaDecorator(IRoomService innerService, string spaDescription = "Спа-процедуры", double spaCost = 30.0)
        : base(innerService)
    {
        _spaDescription = spaDescription;
        _spaCost = spaCost;
    }

    public override string GetServiceDetails()
    {
        return $"{_innerService.GetServiceDetails()} + {_spaDescription}";
    }

    public override double GetCost()
    {
        return _innerService.GetCost() + _spaCost;
    }
}