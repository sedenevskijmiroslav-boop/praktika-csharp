namespace FileDataReader;

public class SensorProcessor
{
    public double GetAverageValue(List<SensorData> data)
    {
        if (data == null || data.Count == 0)
            return 0;

        double sum = 0;
        foreach (var item in data)
        {
            sum += item.Value;
        }
        return sum / data.Count;
    }

    public List<SensorData> FilterByMinValue(List<SensorData> data, double minValue)
    {
        var result = new List<SensorData>();

        foreach (var item in data)
        {
            if (item.Value >= minValue)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public List<SensorData> FilterByMaxValue(List<SensorData> data, double maxValue)
    {
        var result = new List<SensorData>();

        foreach (var item in data)
        {
            if (item.Value <= maxValue)
            {
                result.Add(item);
            }
        }
        return result;
    }

    public List<SensorData> SortByValue(List<SensorData> data, bool ascending = true)
    {
        var result = new List<SensorData>(data);

        for (int i = 0; i < result.Count - 1; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                bool needSwap = ascending ? result[i].Value > result[j].Value : result[i].Value < result[j].Value;
                if (needSwap)
                {
                    var temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    public List<SensorData> SortByTimestamp(List<SensorData> data, bool ascending = true)
    {
        var result = new List<SensorData>(data);

        for (int i = 0; i < result.Count - 1; i++)
        {
            for (int j = i + 1; j < result.Count; j++)
            {
                bool needSwap = ascending ? result[i].Timestamp > result[j].Timestamp : result[i].Timestamp < result[j].Timestamp;
                if (needSwap)
                {
                    var temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }
            }
        }
        return result;
    }

    public SensorData FindMaxValue(List<SensorData> data)
    {
        if (data == null || data.Count == 0)
            return null;

        var max = data[0];
        foreach (var item in data)
        {
            if (item.Value > max.Value)
            {
                max = item;
            }
        }
        return max;
    }

    public SensorData FindMinValue(List<SensorData> data)
    {
        if (data == null || data.Count == 0)
            return null;

        var min = data[0];
        foreach (var item in data)
        {
            if (item.Value < min.Value)
            {
                min = item;
            }
        }
        return min;
    }
}