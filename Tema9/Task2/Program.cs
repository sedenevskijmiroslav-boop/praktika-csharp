using System;

namespace FileDataWriter;

public class Program
{
    public static void Main()
    {
        string filePath = "file.data";

        var writer = new SensorDataWriter(filePath);

        var data = new List<SensorData>
        {
            new SensorData(DateTime.Now, 25.5),
            new SensorData(DateTime.Now.AddMinutes(1), 26.1),
            new SensorData(DateTime.Now.AddMinutes(2), 24.8),
            new SensorData(DateTime.Now.AddMinutes(3), 27.3)
        };

        writer.ClearAndWrite(data);
        Console.WriteLine("Данные записаны в файл");

        var readData = writer.ReadAll();
        Console.WriteLine("\nПрочитанные данные:");

        foreach (var item in readData)
        {
            Console.WriteLine($"{item.Timestamp:HH:mm:ss} - {item.Value}°C");
        }
    }
}