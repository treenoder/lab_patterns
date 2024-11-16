namespace VideoPlayer;

// Цільовий інтерфейс, який очікує медіаплеєр
public interface IVideoPlayer
{
    void Play(string filename);
}

// Оригінальний інтерфейс MediaPlayer
public class MediaPlayer
{
    public void PlayVideo(string filename, string format)
    {
        Console.WriteLine($"Playing {format} video: {filename}");
    }
}

// Адаптер для підтримки різних форматів
public class VideoFormatAdapter : IVideoPlayer
{
    private MediaPlayer _mediaPlayer;

    public VideoFormatAdapter(MediaPlayer mediaPlayer)
    {
        _mediaPlayer = mediaPlayer;
    }

    public void Play(string filename)
    {
        string format = GetFormat(filename);
        if (IsSupported(format))
        {
            _mediaPlayer.PlayVideo(filename, format);
        }
        else
        {
            Console.WriteLine($"Format {format} is not supported.");
        }
    }

    private string GetFormat(string filename)
    {
        int dotIndex = filename.LastIndexOf('.');
        if (dotIndex == -1 || dotIndex == filename.Length - 1)
            return string.Empty;
        return filename.Substring(dotIndex + 1).ToUpper();
    }

    private bool IsSupported(string format)
    {
        return format == "AVI" || format == "MP4" || format == "WMV";
    }
}

public class VideoClient
{
    private IVideoPlayer _player;

    public VideoClient(IVideoPlayer player)
    {
        _player = player;
    }

    public void PlayVideo(string filename)
    {
        _player.Play(filename);
    }
}

public class Program
{
    public static void Main()
    {
        MediaPlayer mediaPlayer = new MediaPlayer();
        IVideoPlayer adapter = new VideoFormatAdapter(mediaPlayer);
        VideoClient client = new VideoClient(adapter);

        client.PlayVideo("movie.avi");
        client.PlayVideo("clip.mp4");
        client.PlayVideo("trailer.wmv");
        client.PlayVideo("documentary.mkv"); // Непідтримуваний формат
    }
}

// Output:
// Playing AVI video: movie.avi
// Playing MP4 video: clip.mp4
// Playing WMV video: trailer.wmv
// Format MKV is not supported.