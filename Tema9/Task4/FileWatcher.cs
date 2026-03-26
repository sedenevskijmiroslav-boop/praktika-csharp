namespace FileArchive;

public class FileWatcher
{
    private FileSystemWatcher _watcher;
    private string _archivePath;

    public FileWatcher(string watchPath, string archivePath)
    {
        _archivePath = archivePath;
        Directory.CreateDirectory(archivePath);

        _watcher = new FileSystemWatcher(watchPath);
        _watcher.Created += OnCreated;
        _watcher.Deleted += OnDeleted;
        _watcher.Changed += OnChanged;
        _watcher.Renamed += OnRenamed;
        _watcher.EnableRaisingEvents = true;
    }

    private void OnCreated(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[СОЗДАН] {e.Name}");
        Log($"{e.Name}");
    }

    private void OnDeleted(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[УДАЛЕН] {e.Name}");
        Log($"{e.Name}");
    }

    private void OnChanged(object sender, FileSystemEventArgs e)
    {
        Console.WriteLine($"[ИЗМЕНЕН] {e.Name}");
        Log($"{e.Name}");
        MoveToArchive(e.FullPath);
    }

    private void OnRenamed(object sender, RenamedEventArgs e)
    {
        Console.WriteLine($"[ПЕРЕИМЕНОВАН] {e.OldName} -> {e.Name}");
        Log($"{e.OldName} -> {e.Name}");
    }

    private void MoveToArchive(string filePath)
    {
        if (!File.Exists(filePath)) return;

        var info = new FileInfo(filePath);
        if ((DateTime.Now - info.LastWriteTime).TotalDays <= 30) return;

        string fileName = Path.GetFileName(filePath);
        string archivePath = Path.Combine(_archivePath, fileName);

        if (File.Exists(archivePath))
        {
            string name = Path.GetFileNameWithoutExtension(fileName);
            string ext = Path.GetExtension(fileName);
            archivePath = Path.Combine(_archivePath, $"{name}_{DateTime.Now:yyyyMMdd_HHmmss}{ext}");
        }

        File.Move(filePath, archivePath);
        Console.WriteLine($"  -> Перемещен в архив: {Path.GetFileName(archivePath)}");
    }

    private void Log(string message)
    {
        string logPath = Path.Combine(_archivePath, "log.txt");
        using (var writer = new StreamWriter(logPath, true))
        {
            writer.WriteLine($"{DateTime.Now:yyyy-MM-dd HH:mm:ss} - {message}");
        }
    }

    public void ArchiveExisting(string watchPath)
    {
        foreach (string file in Directory.GetFiles(watchPath))
        {
            MoveToArchive(file);
        }
    }
}