namespace FileArchive;

public class Program
{
    public static void Main()
    {
        string watchFolder = Path.Combine(Directory.GetCurrentDirectory(), "WatchFolder");
        string archiveFolder = Path.Combine(Directory.GetCurrentDirectory(), "Archive");

        Directory.CreateDirectory(watchFolder);

        var watcher = new FileWatcher(watchFolder, archiveFolder);
        watcher.ArchiveExisting(watchFolder);

        Console.WriteLine($"Наблюдение за: {watchFolder}");
        Console.WriteLine($"Архив: {archiveFolder}");
        Console.WriteLine("Нажмите Enter для выхода...\n");

        string oldFile = Path.Combine(watchFolder, "old_file.txt");
        File.WriteAllText(oldFile, "Старый файл");
        File.SetLastWriteTime(oldFile, DateTime.Now.AddDays(-31));
        Console.WriteLine($"Создан старый файл (изменен {DateTime.Now.AddDays(-31):dd.MM.yyyy})");

        Thread.Sleep(1000);

        File.WriteAllText(oldFile, "Изменение файла");
        Console.WriteLine("Файл изменен, проверка возраста...");

        Thread.Sleep(2000);

        string newFile = Path.Combine(watchFolder, "new_file.txt");
        File.WriteAllText(newFile, "Новый файл");
        Console.WriteLine("Создан новый файл");

        Thread.Sleep(1000);

        string renamed = Path.Combine(watchFolder, "renamed.txt");
        File.Move(newFile, renamed);

        Thread.Sleep(1000);

        File.Delete(renamed);

        Console.ReadLine();
    }
}