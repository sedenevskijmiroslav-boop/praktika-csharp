namespace HotelServices;

public sealed class BreakfastDecorator : RoomServiceDecorator
{
    private readonly string _breakfastDescription;
    private readonly double _breakfastCost;

    public BreakfastDecorator(IRoomService innerService, string breakfastDescription = "Континентальный завтрак", double breakfastCost = 10.0)
        : base(innerService)
    {
        _breakfastDescription = breakfastDescription;
        _breakfastCost = breakfastCost;
    }

    public override string GetServiceDetails()
    {
        return $"{_innerService.GetServiceDetails()} + {_breakfastDescription}";
    }

    public override double GetCost()
    {
        return _innerService.GetCost() + _breakfastCost;
    }
}