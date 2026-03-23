using System;

namespace NumberConvertion
{
    public class BinaryConverter
    {
        public string ConvertToBinary(int number)
        {
            return Convert.ToString(number, 2);
        }
    }
}