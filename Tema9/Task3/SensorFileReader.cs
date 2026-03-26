namespace FileDataReader;

public class SensorFileReader
{
    private readonly string _filePath;

    public SensorFileReader(string filePath)
    {
        _filePath = filePath;
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