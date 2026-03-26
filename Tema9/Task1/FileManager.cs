namespace FileOperations;

public class FileManager
{
    public void CreateFile(string path, string content) => File.WriteAllText(path, content);

    public string ReadFile(string path) => File.Exists(path) ? File.ReadAllText(path) : "Файл не найден";

    public bool DeleteFile(string path)
    {
        if (!File.Exists(path)) return false;
        File.Delete(path);
        return true;
    }

    public bool CopyFile(string source, string dest)
    {
        if (!File.Exists(source)) return false;
        if (File.Exists(dest)) File.Delete(dest);
        File.Copy(source, dest);
        return true;
    }

    public bool MoveFile(string source, string dest)
    {
        if (!File.Exists(source)) return false;
        if (File.Exists(dest)) File.Delete(dest);
        File.Move(source, dest);
        return true;
    }

    public bool RenameFile(string oldPath, string newName)
    {
        if (!File.Exists(oldPath)) return false;
        string newPath = Path.Combine(Path.GetDirectoryName(oldPath), newName);
        if (File.Exists(newPath)) File.Delete(newPath);
        File.Move(oldPath, newPath);
        return true;
    }

    public void DeleteFilesByPattern(string dir, string pattern)
    {
        if (!Directory.Exists(dir)) return;
        foreach (string file in Directory.GetFiles(dir, pattern)) File.Delete(file);
    }

    public void SetReadOnly(string path, bool readOnly)
    {
        if (File.Exists(path)) File.SetAttributes(path, readOnly ? FileAttributes.ReadOnly : FileAttributes.Normal);
    }

    public void EnsureDirectoryExists(string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
    }
}