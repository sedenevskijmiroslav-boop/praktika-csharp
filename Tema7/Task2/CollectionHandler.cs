using System;
using System.Collections.Generic;

namespace CollectionHandler
{
    public class CollectionHandler
    {
        private ListProcessor processor = new ListProcessor();

        public int GetElement(List<int> list, int index)
        {
            try
            {
                return processor.GetElementAt(list, index);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine($"Лог: {ex.Message}");

                throw new CollectionException("Ошибка получения элемента", ex);
            }
        }
    }
}