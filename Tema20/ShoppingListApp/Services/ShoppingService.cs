using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public class ShoppingService : IShoppingService
    {
        private readonly List<ShoppingItem> _items;
        private int _nextId = 1;

        public ShoppingService()
        {
            _items = new List<ShoppingItem>
            {
                new() { Id = _nextId++, Name = "Молоко", Quantity = 2, Bought = false },
                new() { Id = _nextId++, Name = "Хлеб", Quantity = 1, Bought = false },
                new() { Id = _nextId++, Name = "Яйца", Quantity = 10, Bought = true },
                new() { Id = _nextId++, Name = "Масло", Quantity = 1, Bought = false }
            };
        }

        public IReadOnlyList<ShoppingItem> GetAll() => _items;

        public void Add(ShoppingItem item)
        {
            item.Id = _nextId++;
            _items.Add(item);
        }

        public bool Delete(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item is null)
            {
                return false;
            }

            _items.Remove(item);
            return true;
        }

        public void MarkAsBought(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item is not null)
            {
                item.Bought = true;
            }
        }

        public void Unmark(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item is not null)
            {
                item.Bought = false;
            }
        }
    }
}
