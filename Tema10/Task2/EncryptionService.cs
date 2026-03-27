namespace FileEncryption;

public class EncryptionService
{
    private IEncryptionStrategy _strategy;

    public EncryptionService(IEncryptionStrategy strategy)
    {
        _strategy = strategy;
    }

    public void SetStrategy(IEncryptionStrategy strategy)
    {
        _strategy = strategy;
    }

    public string EncryptData(string data)
    {
        return _strategy.Encrypt(data);
    }

    public string DecryptData(string data)
    {
        return _strategy.Decrypt(data);
    }
}