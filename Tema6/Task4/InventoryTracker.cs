using System;

namespace Warehouse
{
    public class InventoryTracker
    {
        public InventoryTracker(WarehouseMonitor monitor, InventorySystem inventory, SecuritySystem security)
        {
            monitor.ItemMoved += inventory.UpdateInventory;
            monitor.ItemMoved += security.CheckPermissions;
        }
    }
}