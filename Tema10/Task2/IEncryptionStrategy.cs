namespace FileEncryption;

public interface IEncryptionStrategy
{
    string Encrypt(string data);
    string Decrypt(string data);
}