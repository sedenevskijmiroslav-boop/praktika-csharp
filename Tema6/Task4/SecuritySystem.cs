using System;

namespace Warehouse
{
    public class SecuritySystem
    {
        public void CheckPermissions(object sender, ItemMovedEventArgs e)
        {
            string status = (e.ToLocation == "Зона А" || e.ToLocation == "Зона Б") ? "разрешено" : "проверка";
            Console.WriteLine($"  Безопасность: перемещение {status}");
        }
    }
}