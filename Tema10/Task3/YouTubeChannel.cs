namespace FileObserver;

public class YouTubeChannel
{
    private string _name;
    private List<ISubscriber> _subscribers = new List<ISubscriber>();

    public YouTubeChannel(string name)
    {
        _name = name;
    }

    public void Subscribe(ISubscriber subscriber)
    {
        _subscribers.Add(subscriber);
    }

    public void Unsubscribe(ISubscriber subscriber)
    {
        _subscribers.Remove(subscriber);
    }

    public void UploadVideo(string title)
    {
        Console.WriteLine($"Канал {_name} загрузил: {title}");
        foreach (var s in _subscribers)
        {
            s.Update(_name, title);
        }
    }
}