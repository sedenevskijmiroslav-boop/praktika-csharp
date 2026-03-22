using System;

namespace RestaurantSystem;
public class Chef
{
    public string Name { get; set; }
    public string Specialty { get; set; }

    public Chef(string name, string specialty)
    {
        Name = name;
        Specialty = specialty;
    }

    public void Cook(string dish)
    {
        Console.WriteLine($"Шеф-повар {Name} готовит: {dish}");
    }
}