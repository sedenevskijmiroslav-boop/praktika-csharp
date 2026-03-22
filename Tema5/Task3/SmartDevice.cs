namespace SmartDevices;

public abstract class SmartDevice
{
    public string Name { get; set; }
    public string Brand { get; set; }
    public int Power { get; set; } 

    public SmartDevice(string name, string brand, int power)
    {
        Name = name;
        Brand = brand;
        Power = power;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Устройство: {Name}, Бренд: {Brand}, Мощность: {Power} Вт");
    }
}