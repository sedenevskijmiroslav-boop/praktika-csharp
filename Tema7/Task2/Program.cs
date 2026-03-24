using System;
using System.Collections.Generic;

namespace CollectionHandler
{
    class Program
    {
        static void Main(string[] args)
        {
            CollectionHandler handler = new CollectionHandler();
            List<int> numbers = new List<int> { 10, 20, 30 };

            int result = handler.GetElement(numbers, 1);
            Console.WriteLine($"Элемент: {result}");

            try
            {
                handler.GetElement(numbers, 5);
            }
            catch (CollectionException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
                Console.WriteLine($"Причина: {ex.InnerException.Message}");
            }
        }
    }
}