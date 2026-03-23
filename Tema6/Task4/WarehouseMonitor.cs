using System;

namespace Warehouse
{
    public class WarehouseMonitor
    {
        public event EventHandler<ItemMovedEventArgs> ItemMoved;

        public void MoveItem(string itemName, string fromLocation, string toLocation)
        {
            Console.WriteLine($"Перемещение: {itemName} ({fromLocation} -> {toLocation})");
            OnItemMoved(new ItemMovedEventArgs(itemName, fromLocation, toLocation));
        }

        protected virtual void OnItemMoved(ItemMovedEventArgs e)
        {
            ItemMoved?.Invoke(this, e);
        }
    }
}