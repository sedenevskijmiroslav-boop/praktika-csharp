namespace FileDataReader;

public class Program
{
    public static void Main()
    {
        string filePath = "D:/Задания практика (КПиЯП)/Tema9/Task2/bin/Debug/net8.0/file.data";

        var reader = new SensorFileReader(filePath);
        var processor = new SensorProcessor();

        List<SensorData> data = reader.ReadAll();

        if (data.Count == 0)
        {
            Console.WriteLine("Файл пуст или не содержит данных");
            return;
        }

        Console.WriteLine($"Загружено записей: {data.Count}\n");

        Console.WriteLine("Все данные:");
        foreach (var item in data)
        {
            Console.WriteLine($"{item.Timestamp:yyyy-MM-dd HH:mm:ss} - {item.Value}°C");
        }

        double average = processor.GetAverageValue(data);
        Console.WriteLine($"\nСреднее значение: {average:F2}°C");

        var filteredByMin = processor.FilterByMinValue(data, 26);
        Console.WriteLine($"\nЗначения >= 26°C: {filteredByMin.Count} записей");

        var filteredByMax = processor.FilterByMaxValue(data, 25);
        Console.WriteLine($"Значения <= 25°C: {filteredByMax.Count} записей");

        var sortedByValue = processor.SortByValue(data, true);
        Console.WriteLine("\nСортировка по значению (по возрастанию):");
        foreach (var item in sortedByValue)
        {
            Console.WriteLine($"{item.Value}°C - {item.Timestamp:HH:mm:ss}");
        }

        var sortedByTime = processor.SortByTimestamp(data, false);
        Console.WriteLine("\nСортировка по времени (по убыванию):");
        foreach (var item in sortedByTime)
        {
            Console.WriteLine($"{item.Timestamp:HH:mm:ss} - {item.Value}°C");
        }

        var max = processor.FindMaxValue(data);
        var min = processor.FindMinValue(data);

        Console.WriteLine($"\nМаксимальное значение: {max.Value}°C в {max.Timestamp:HH:mm:ss}");
        Console.WriteLine($"Минимальное значение: {min.Value}°C в {min.Timestamp:HH:mm:ss}");
    }
}