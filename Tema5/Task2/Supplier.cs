using System;

namespace RestaurantSystem;

public class Supplier
{
    public string Name { get; set; }
    public string Product { get; set; }

    public Supplier(string name, string product)
    {
        Name = name;
        Product = product;
    }

    public void Deliver()
    {
        Console.WriteLine($"Поставщик {Name} доставил: {Product}");
    }
}