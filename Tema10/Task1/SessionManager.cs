namespace FileSessionManager;

public class SessionManager
{
    private static SessionManager _instance;
    private string _currentUser;

    private SessionManager() { }

    public static SessionManager GetInstance()
    {
        if (_instance == null)
        {
            _instance = new SessionManager();
        }
        return _instance;
    }

    public void Login(string user)
    {
        _currentUser = user;
        Console.WriteLine($"Пользователь {user} вошел в систему");
    }

    public void Logout()
    {
        if (_currentUser != null)
        {
            Console.WriteLine($"Пользователь {_currentUser} вышел из системы");
            _currentUser = null;
        }
        else
        {
            Console.WriteLine("Нет активной сессии");
        }
    }

    public string GetCurrentUser()
    {
        if (_currentUser == null)
        {
            return "Сессия не активна";
        }
        return _currentUser;
    }
}