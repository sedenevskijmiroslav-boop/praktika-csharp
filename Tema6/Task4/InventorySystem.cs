using System;

namespace Warehouse
{
    public class InventorySystem
    {
        public void UpdateInventory(object sender, ItemMovedEventArgs e)
        {
            Console.WriteLine($"  Инвентаризация: {e.ItemName} обновлен");
        }
    }
}