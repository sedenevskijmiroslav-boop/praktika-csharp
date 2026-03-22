namespace SmartDevices;

public interface ICanPlayMusic
{
    void PlayMusic();
    void StopMusic();
    void SetVolume(int volume);
}