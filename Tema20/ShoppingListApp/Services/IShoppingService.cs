using ShoppingListApp.Models;

namespace ShoppingListApp.Services
{
    public interface IShoppingService
    {
        IReadOnlyList<ShoppingItem> GetAll();
        void Add(ShoppingItem item);
        bool Delete(int id);
        void MarkAsBought(int id);
        void Unmark(int id);
    }
}
