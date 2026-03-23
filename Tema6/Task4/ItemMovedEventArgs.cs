using System;

namespace Warehouse
{
    public class ItemMovedEventArgs : EventArgs
    {
        public string ItemName { get; }
        public string FromLocation { get; }
        public string ToLocation { get; }

        public ItemMovedEventArgs(string itemName, string fromLocation, string toLocation)
        {
            ItemName = itemName;
            FromLocation = fromLocation;
            ToLocation = toLocation;
        }
    }
}