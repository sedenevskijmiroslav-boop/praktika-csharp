using System.ComponentModel.DataAnnotations;

namespace ShoppingListApp.Models
{
    public class ShoppingItemViewModel
    {
        [Required(ErrorMessage = "Введите название товара.")]
        public string Name { get; set; } = string.Empty;

        [Range(1, 100, ErrorMessage = "Количество должно быть от 1 до 100.")]
        public int Quantity { get; set; } = 1;
    }
}
