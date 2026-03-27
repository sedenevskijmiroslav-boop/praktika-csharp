namespace FileObserver;

public class User : ISubscriber
{
    private string _name;

    public User(string name)
    {
        _name = name;
    }

    public void Update(string channelName, string videoTitle)
    {
        Console.WriteLine($"{_name} -> новое видео: {videoTitle}");
    }
}