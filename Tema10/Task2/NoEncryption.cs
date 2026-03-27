namespace FileEncryption;

public class NoEncryption : IEncryptionStrategy
{
    public string Encrypt(string data)
    {
        return $"[NO_ENC]{data}";
    }

    public string Decrypt(string data)
    {
        if (!data.StartsWith("[NO_ENC]"))
            return data;

        return data.Substring(8);
    }
}