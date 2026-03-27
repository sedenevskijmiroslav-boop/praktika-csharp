namespace FileObserver;

public interface ISubscriber
{
    void Update(string channelName, string videoTitle);
}