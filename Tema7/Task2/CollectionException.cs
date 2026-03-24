using System;

namespace CollectionHandler
{
    public class CollectionException : Exception
    {
        public CollectionException() : base("Ошибка при работе с коллекцией")
        {
        }

        public CollectionException(string message, Exception innerException)
            : base(message, innerException)
        {
        }
    }
}