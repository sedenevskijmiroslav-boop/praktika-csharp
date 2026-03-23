using System;

namespace UserManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            UserManager manager = new UserManager();

            int userId = 123;

            manager.PerformUserAction(userId, manager.BlockUser);

            manager.PerformUserAction(userId, manager.UnblockUser);
        }
    }
}