namespace FileEncryption;

public class DESEncryption : IEncryptionStrategy
{
    public string Encrypt(string data)
    {
        char[] encrypted = new char[data.Length];
        for (int i = 0; i < data.Length; i++)
        {
            encrypted[i] = (char)(data[i] ^ 0x5A);
        }
        return $"[DES]{new string(encrypted)}";
    }

    public string Decrypt(string data)
    {
        if (!data.StartsWith("[DES]"))
            return data;

        string encryptedData = data.Substring(5);
        char[] decrypted = new char[encryptedData.Length];
        for (int i = 0; i < encryptedData.Length; i++)
        {
            decrypted[i] = (char)(encryptedData[i] ^ 0x5A);
        }
        return new string(decrypted);
    }
}