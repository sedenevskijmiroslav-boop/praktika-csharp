namespace RestaurantSystem;

public class Menu
{
    public string[] Dishes { get; set; }

    public Menu(string[] dishes)
    {
        Dishes = dishes;
    }

    public void Show()
    {
        Console.WriteLine("Меню:");
        foreach (string dish in Dishes)
        {
            Console.WriteLine($"  - {dish}");
        }
    }
}