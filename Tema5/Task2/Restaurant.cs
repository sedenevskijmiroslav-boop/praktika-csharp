using System;

namespace RestaurantSystem;
public class Restaurant
{
    public string Name { get; set; }

    public Menu RestaurantMenu { get; private set; }

    public Chef[] Chefs { get; set; }

    public Supplier[] Suppliers { get; set; }

    public Restaurant(string name, string[] dishes, Chef[] chefs, Supplier[] suppliers)
    {
        Name = name;

        RestaurantMenu = new Menu(dishes);

        Chefs = chefs;
        Suppliers = suppliers;
    }

    public void PrepareDishes()
    {
        Console.WriteLine($"\nРесторан {Name} ");

        Console.WriteLine("Поставка продуктов:");
        foreach (Supplier s in Suppliers)
        {
            s.Deliver();
        }

        Console.WriteLine("\nПриготовление блюд:");
        for (int i = 0; i < Chefs.Length && i < RestaurantMenu.Dishes.Length; i++)
        {
            Chefs[i].Cook(RestaurantMenu.Dishes[i]);
        }
    }

    public void ShowInfo()
    {
        Console.WriteLine($"\nРесторан: {Name}");
        RestaurantMenu.Show();

        Console.WriteLine("\nПовара:");
        foreach (Chef c in Chefs)
        {
            Console.WriteLine($"  - {c.Name} ({c.Specialty})");
        }

        Console.WriteLine("\nПоставщики:");
        foreach (Supplier s in Suppliers)
        {
            Console.WriteLine($"  - {s.Name} ({s.Product})");
        }
    }
}