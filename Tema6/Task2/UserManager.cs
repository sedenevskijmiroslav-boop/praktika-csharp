using System;

namespace UserManagement
{
    public class UserManager
    {
        public void PerformUserAction(int userId, UserAction action)
        {
            Console.Write($"Выполняем действие для пользователя {userId}: ");
            action(userId);
        }

        public void BlockUser(int userId)
        {
            Console.WriteLine($"Пользователь {userId} заблокирован");
        }

        public void UnblockUser(int userId)
        {
            Console.WriteLine($"Пользователь {userId} разблокирован");
        }
    }
}