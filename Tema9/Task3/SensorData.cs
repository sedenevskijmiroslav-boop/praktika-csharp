namespace FileDataReader;

public class SensorData
{
    public DateTime Timestamp { get; set; }
    public double Value { get; set; }

    public SensorData(DateTime timestamp, double value)
    {
        Timestamp = timestamp;
        Value = value;
    }
}