using System;

namespace RestaurantSystem;

class Program
{
    static void Main()
    {
        Chef[] chefs1 = new Chef[]
        {
            new Chef("Швед Руслан", "Итальянская кухня"),
            new Chef("Петров Егор", "Японская кухня"),
            new Chef("Шубзда Ярослав", "Французская кухня")
        };

        Chef[] chefs2 = new Chef[]
        {
            new Chef("Мосевич Артур", "Русская кухня"),
            new Chef("Петров Роман", "Европейская кухня")
        };

        Supplier[] suppliers1 = new Supplier[]
        {
            new Supplier("Овощник", "Овощи"),
            new Supplier("Жар птица", "Мясо")
        };

        Supplier[] suppliers2 = new Supplier[]
        {
            new Supplier("Ни рыба Ни мясо", "Рыба"),
            new Supplier("Молочный мир", "Молочные продукты")
        };

        Restaurant[] restaurants = new Restaurant[]
        {
            new Restaurant("Итальянский дворик",
                new string[] { "Пицца", "Паста", "Тирамису" },
                chefs1, suppliers1),

            new Restaurant("Уютное кафе",
                new string[] { "Борщ", "Пельмени", "Блины" },
                chefs2, suppliers2)
        };

        foreach (Restaurant r in restaurants)
        {
            r.ShowInfo();
        }

        Console.WriteLine("\nГОТОВИМ БЛЮДА ");
        foreach (Restaurant r in restaurants)
        {
            r.PrepareDishes();
        }
    }
}