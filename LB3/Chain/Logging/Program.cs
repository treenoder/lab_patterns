namespace Logging;

// Абстрактний клас логера
public abstract class Logger
{
    protected Logger _nextLogger;

    public void SetNext(Logger nextLogger)
    {
        _nextLogger = nextLogger;
    }

    public abstract void LogMessage(int level, string message);
}

// Конкретний логер для інформаційних повідомлень
public class InfoLogger : Logger
{
    private const int INFO = 1;

    public override void LogMessage(int level, string message)
    {
        if (level == INFO)
        {
            Console.WriteLine($"INFO: {message}");
        }
        else if (_nextLogger != null)
        {
            _nextLogger.LogMessage(level, message);
        }
    }
}

// Конкретний логер для попереджувальних повідомлень
public class WarningLogger : Logger
{
    private const int WARNING = 2;

    public override void LogMessage(int level, string message)
    {
        if (level == WARNING)
        {
            Console.WriteLine($"WARNING: {message}");
        }
        else if (_nextLogger != null)
        {
            _nextLogger.LogMessage(level, message);
        }
    }
}

// Конкретний логер для критичних повідомлень
public class ErrorLogger : Logger
{
    private const int ERROR = 3;

    public override void LogMessage(int level, string message)
    {
        if (level == ERROR)
        {
            Console.WriteLine($"ERROR: {message}");
        }
        else if (_nextLogger != null)
        {
            _nextLogger.LogMessage(level, message);
        }
    }
}

public class LoggerClient
{
    private Logger _loggerChain;

    public LoggerClient()
    {
        // Створюємо ланцюг логерів
        _loggerChain = new InfoLogger();
        Logger warningLogger = new WarningLogger();
        Logger errorLogger = new ErrorLogger();

        _loggerChain.SetNext(warningLogger);
        warningLogger.SetNext(errorLogger);
    }

    public void Log(int level, string message)
    {
        _loggerChain.LogMessage(level, message);
    }
}

public class Program
{
    public static void Main()
    {
        LoggerClient client = new LoggerClient();

        client.Log(1, "Це інформаційне повідомлення.");
        client.Log(2, "Це попереджувальне повідомлення.");
        client.Log(3, "Це критичне повідомлення.");
        client.Log(4, "Це повідомлення невідомого рівня."); // Невизначений рівень
    }
}

// Output:
// INFO: Це інформаційне повідомлення.
// WARNING: Це попереджувальне повідомлення.
// ERROR: Це критичне повідомлення.