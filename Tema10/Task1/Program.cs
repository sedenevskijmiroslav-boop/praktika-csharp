using System;

namespace FileSessionManager;

public class Program
{
    public static void Main()
    {
        SessionManager session1 = SessionManager.GetInstance();
        SessionManager session2 = SessionManager.GetInstance();

        session1.Login("Швед Руслан");

        Console.WriteLine($"Текущий пользователь (session1): {session1.GetCurrentUser()}");
        Console.WriteLine($"Текущий пользователь (session2): {session2.GetCurrentUser()}\n");

        session2.Logout();

        Console.WriteLine($"Текущий пользователь: {session1.GetCurrentUser()}\n");

    }
}