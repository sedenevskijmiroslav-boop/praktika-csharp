using System;

namespace Naselenie;
class City
{
    public string Name { get; set; }
    public int Population { get; set; }
    public City(string name, int population)
    {
        Name = name;
        Population = population;
    }
}

static class CityFinder
{
    public static City FindMostPopularCity(City[] cities)
    {
        City best = cities[0];

        for (int i = 1; i < cities.Length; i++)
        {
            if (cities[i].Population > best.Population)
            {
                best = cities[i];
            }
        }

        return best;
    }
}

class Program
{
    static void Main()
    {
        City[] cities = new City[]
        {
            new City("Гродно", 374000),
            new City("Минск", 2007000),
            new City("Витебск", 361000),
            new City("Брест", 346000),
            new City("Гомель", 480000),
            new City("Могилев", 385000)
        };

        City best = CityFinder.FindMostPopularCity(cities);

        Console.WriteLine($"Самый популярный город: {best.Name}");
        Console.WriteLine($"Население: {best.Population} человек");
    }
}