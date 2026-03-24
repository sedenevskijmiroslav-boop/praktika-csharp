using System;
using System.Collections.Generic;

namespace CollectionHandler
{
    public class ListProcessor
    {
        public int GetElementAt(List<int> list, int index)
        {
            if (index < 0 || index >= list.Count)
            {
                throw new IndexOutOfRangeException($"Индекс {index} вне диапазона");
            }

            return list[index];
        }
    }
}