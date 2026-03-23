using System;

namespace NumberConvertion
{
    public class HexConverter
    {
        public string ConvertToHex(int number)
        {
            return Convert.ToString(number, 16).ToUpper();
        }
    }
}