using FileDataWriter;

namespace FileDataWriter;

public class SensorDataWriter
{
    private readonly string _filePath;

    public SensorDataWriter(string filePath)
    {
        _filePath = filePath;
    }

    public void ClearAndWrite(List<SensorData> data)
    {
        File.WriteAllText(_filePath, string.Empty);

        using (var writer = new StreamWriter(_filePath))
        {
            foreach (var item in data)
            {
                writer.WriteLine($"{item.Timestamp:yyyy-MM-dd HH:mm:ss};{item.Value}");
            }
        }
    }

    public List<SensorData> ReadAll()
    {
        var result = new List<SensorData>();

        if (!File.Exists(_filePath))
            return result;

        string[] lines = File.ReadAllLines(_filePath);

        foreach (string line in lines)
        {
            if (string.IsNullOrWhiteSpace(line))
                continue;

            string[] parts = line.Split(';');
            if (parts.Length == 2)
            {
                DateTime timestamp = DateTime.Parse(parts[0]);
                double value = double.Parse(parts[1]);
                result.Add(new SensorData(timestamp, value));
            }
        }

        return result;
    }
}