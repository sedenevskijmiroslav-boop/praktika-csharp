using System;

namespace FileInterfaces;
public class FileManager : IReadFile, IWriteFile
{
    void IReadFile.AccessFile(string fileName)
    {
        Console.WriteLine($"Чтение файла: {fileName}");
        Console.WriteLine($"Содержимое файла '{fileName}' успешно прочитано");
    }

    void IWriteFile.AccessFile(string fileName)
    {
        Console.WriteLine($"Запись в файл: {fileName}");
        Console.WriteLine($"Данные успешно записаны в файл '{fileName}'");
    }

    public void ShowInfo()
    {
        Console.WriteLine("FileManager - менеджер для работы с файлами");
    }
}