using System;
using HotelServices;

internal static class Program
{
    private static void Main()
    {
        IRoomService service = new BasicRoomService();

        Console.WriteLine("Базовый сервис:");
        Console.WriteLine($"{service.GetServiceDetails()} | {service.GetCost():F2}");
        Console.WriteLine();

        while (true)
        {
            Console.WriteLine("Выберите позиции для добавления:");
            Console.WriteLine("1 - Добавить завтрак");
            Console.WriteLine("2 - Добавить спа");
            Console.WriteLine("3 - Добавить трансфер из аэропорта");
            Console.WriteLine("4 - Показать текущий пакет и выйти");
            Console.Write("Введите номер действия: ");

            string? input = Console.ReadLine();
            Console.WriteLine();

            if (string.IsNullOrWhiteSpace(input))
            {
                Console.WriteLine("Некорректный ввод. Попробуйте снова.");
                Console.WriteLine();
                continue;
            }

            switch (input.Trim())
            {
                case "1":
                    service = new BreakfastDecorator(service);
                    Console.WriteLine("Завтрак добавлен.");
                    Console.WriteLine($"{service.GetServiceDetails()} | {service.GetCost():F2}");
                    Console.WriteLine();
                    break;

                case "2":
                    service = new SpaDecorator(service);
                    Console.WriteLine("Спа добавлено.");
                    Console.WriteLine($"{service.GetServiceDetails()} | {service.GetCost():F2}");
                    Console.WriteLine();
                    break;

                case "3":
                    service = new AirportPickupDecorator(service);
                    Console.WriteLine("Трансфер из аэропорта добавлен.");
                    Console.WriteLine($"{service.GetServiceDetails()} | {service.GetCost():F2}");
                    Console.WriteLine();
                    break;

                case "4":
                    Console.WriteLine("Итоговый пакет услуг:");
                    Console.WriteLine($"{service.GetServiceDetails()} | {service.GetCost():F2}");
                    return;

                default:
                    Console.WriteLine("Неизвестная команда. Попробуйте снова.");
                    Console.WriteLine();
                    break;
            }
        }
    }
}