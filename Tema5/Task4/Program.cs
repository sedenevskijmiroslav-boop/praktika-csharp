using System;

namespace FileInterfaces;

class Program
{
    static void Main()
    {
        FileManager manager = new FileManager();

        Console.WriteLine(" Обычный метод ");
        manager.ShowInfo();
        Console.WriteLine();

        IReadFile reader = manager;
        IWriteFile writer = manager;

        Console.WriteLine(" Доступ через IReadFile ");
        reader.AccessFile("document.txt");
        Console.WriteLine();

        Console.WriteLine(" Доступ через IWriteFile ");
        writer.AccessFile("document.txt");
        Console.WriteLine();

        Console.WriteLine("Примечание: Метод AccessFile недоступен напрямую через FileManager");
        Console.WriteLine("Доступ возможен только через ссылки на интерфейсы");
    }
}