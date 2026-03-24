using System;

namespace Warehouse
{
    public class Warehouse
    {
        private string productName;
        private int quantity;

        public Warehouse(string productName, int quantity)
        {
            this.productName = productName;
            this.quantity = quantity;
        }

        public void CheckStock(int requestedQuantity)
        {
            if (quantity < requestedQuantity)
            {
                throw new OutOfStockException(
                    $"Товар '{productName}' отсутствует. Доступно: {quantity}, запрошено: {requestedQuantity}");
            }

            Console.WriteLine($"Товар '{productName}' в наличии\n");
        }
    }
}