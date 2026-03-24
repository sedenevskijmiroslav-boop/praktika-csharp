using System;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Warehouse laptop = new Warehouse("Ноутбук", 10);
            Warehouse phone = new Warehouse("Телефон", 0);
            
            laptop.CheckStock(5);
            
            try
            {
                phone.CheckStock(1);
            }
            catch (OutOfStockException ex)
            {
                Console.WriteLine($"Ошибка: {ex.Message}");
            }
        }
    }
}