namespace FileOperations;

public class FileInfoProvider
{
    public long GetFileSize(string path)
    {
        if (File.Exists(path))
        {
            var info = new FileInfo(path);
            return info.Length;
        }
        return -1;
    }

    public DateTime GetCreationTime(string path)
    {
        if (File.Exists(path))
        {
            var info = new FileInfo(path);
            return info.CreationTime;
        }
        return DateTime.MinValue;
    }

    public DateTime GetLastWriteTime(string path)
    {
        if (File.Exists(path))
        {
            var info = new FileInfo(path);
            return info.LastWriteTime;
        }
        return DateTime.MinValue;
    }

    public bool CompareFileSize(string path1, string path2)
    {
        if (File.Exists(path1) && File.Exists(path2))
        {
            var info1 = new FileInfo(path1);
            var info2 = new FileInfo(path2);
            return info1.Length == info2.Length;
        }
        return false;
    }

    public void ListFiles(string dir)
    {
        if (Directory.Exists(dir))
        {
            string[] files = Directory.GetFiles(dir);
            foreach (string file in files)
            {
                Console.WriteLine(Path.GetFileName(file));
            }
        }
    }

    public void CheckPermissions(string path)
    {
        if (File.Exists(path))
        {
            var attrs = File.GetAttributes(path);
            bool isReadOnly = (attrs & FileAttributes.ReadOnly) != 0;
            Console.WriteLine($"Чтение: Разрешено");
            Console.WriteLine($"Запись: {(isReadOnly ? "Запрещено" : "Разрешено")}");
        }
    }
}