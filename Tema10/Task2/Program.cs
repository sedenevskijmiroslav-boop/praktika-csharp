namespace FileEncryption;

public class Program
{
    public static void Main()
    {
        string original = "Hello World!";
        Console.WriteLine($"Исходные данные: {original}\n");

        var aes = new AESEncryption();
        var service = new EncryptionService(aes);

        string encryptedAes = service.EncryptData(original);
        Console.WriteLine($"AES зашифровано: {encryptedAes}");
        Console.WriteLine($"AES расшифровано: {service.DecryptData(encryptedAes)}\n");

        var des = new DESEncryption();
        service.SetStrategy(des);

        string encryptedDes = service.EncryptData(original);
        Console.WriteLine($"DES зашифровано: {encryptedDes}");
        Console.WriteLine($"DES расшифровано: {service.DecryptData(encryptedDes)}\n");

        var noEnc = new NoEncryption();
        service.SetStrategy(noEnc);

        string encryptedNone = service.EncryptData(original);
        Console.WriteLine($"Без шифрования: {encryptedNone}");
        Console.WriteLine($"Расшифровано: {service.DecryptData(encryptedNone)}\n");

        Console.WriteLine("Смена стратегии в runtime");
        service.SetStrategy(aes);
        Console.WriteLine($"AES: {service.EncryptData("Test")}");

        service.SetStrategy(des);
        Console.WriteLine($"DES: {service.EncryptData("Test")}");

        service.SetStrategy(noEnc);
        Console.WriteLine($"NO_ENC: {service.EncryptData("Test")}");
    }
}