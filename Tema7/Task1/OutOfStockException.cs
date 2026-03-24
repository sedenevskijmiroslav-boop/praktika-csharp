using System;

namespace Warehouse
{
    public class OutOfStockException : Exception
    {
        public OutOfStockException() : base("Товар отсутствует на складе")
        {
        }

        public OutOfStockException(string message) : base(message)
        {
        }

        public OutOfStockException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}