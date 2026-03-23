using System;

namespace Warehouse
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("СИСТЕМА КОНТРОЛЯ ДВИЖЕНИЯ НА СКЛАДЕ\n");

            WarehouseMonitor warehouse = new WarehouseMonitor();

            InventorySystem inventory = new InventorySystem();
            SecuritySystem security = new SecuritySystem();

            InventoryTracker tracker = new InventoryTracker(warehouse, inventory, security);

            Console.WriteLine();

            warehouse.MoveItem("Ноутбук", "Стеллаж 1", "Зона А");
            warehouse.MoveItem("Телефон", "Стеллаж 2", "Зона Б");
            warehouse.MoveItem("Монитор", "Стеллаж 1", "Зона С");
        }
    }
}