namespace FileOperations;

public class Program
{
    public static void Main()
    {
        string fileName = "sedenevskij.mm";
        string dir = Directory.GetCurrentDirectory();
        string filePath = Path.Combine(dir, fileName);

        var fm = new FileManager();
        var fip = new FileInfoProvider();

        fm.CreateFile(filePath, "Тестовый текст для файла");
        Console.WriteLine(fm.ReadFile(filePath));

        if (File.Exists(filePath))
            Console.WriteLine("Файл существует");

        Console.WriteLine($"Размер: {fip.GetFileSize(filePath)} байт");
        Console.WriteLine($"Создан: {fip.GetCreationTime(filePath)}");
        Console.WriteLine($"Изменен: {fip.GetLastWriteTime(filePath)}");

        string copyPath = Path.Combine(dir, "copy_" + fileName);
        fm.CopyFile(filePath, copyPath);
        Console.WriteLine($"Копия существует: {File.Exists(copyPath)}");

        string newDir = Path.Combine(dir, "NewFolder");
        fm.EnsureDirectoryExists(newDir);
        string movedPath = Path.Combine(newDir, fileName);
        fm.MoveFile(filePath, movedPath);

        string renamedPath = Path.Combine(newDir, "familiya.io");
        fm.RenameFile(movedPath, "familiya.io");

        try
        {
            File.Delete("ne_sushestvuet.txt");
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }

        bool equal = fip.CompareFileSize(renamedPath, copyPath);
        Console.WriteLine($"Файлы {(equal ? "одинаковые" : "разные")} по размеру");

        fm.DeleteFilesByPattern(dir, "*.mm");

        fip.ListFiles(dir);

        fm.SetReadOnly(renamedPath, true);
        try
        {
            File.WriteAllText(renamedPath, "новая запись");
            Console.WriteLine("Запись удалась");
        }
        catch (UnauthorizedAccessException)
        {
            Console.WriteLine("Нет прав на запись");
        }

        fip.CheckPermissions(renamedPath);

        fm.SetReadOnly(renamedPath, false);
    }
}