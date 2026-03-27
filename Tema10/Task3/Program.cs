namespace FileObserver;

public class Program
{
    public static void Main()
    {
        var channel = new YouTubeChannel("Technical city");

        var user1 = new User("Руслан");
        var user2 = new User("Роман");

        channel.Subscribe(user1);
        channel.Subscribe(user2);

        channel.UploadVideo("Обзор нового Iphone 17pro");

        channel.Unsubscribe(user2);

        channel.UploadVideo("Обзор Samsung Galaxy S23 Ultra");
    }
}