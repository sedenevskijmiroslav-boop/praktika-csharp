using System;

namespace NumberConvertion
{
    class Program
    {
        static void Main(string[] args)
        {
            BinaryConverter binary = new BinaryConverter();
            HexConverter hex = new HexConverter();

            NumberConverter toBinary = binary.ConvertToBinary;
            NumberConverter toHex = hex.ConvertToHex;

            int number = 255;

            Console.WriteLine($"Число: {number}");
            Console.WriteLine($"Двоичная: {toBinary(number)}");
            Console.WriteLine($"Шестнадцатеричная: {toHex(number)}");
        }
    }
}