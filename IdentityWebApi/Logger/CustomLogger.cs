using Microsoft.Extensions.Options;

namespace IdentityWebApi.Logger;

public class CustomLogger : ILogger
{
    public IDisposable? BeginScope<TState>(TState state) where TState : notnull
    {
        return null;
    }

    public bool IsEnabled(LogLevel logLevel)
    {
        return true;
    }

    public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception? exception,
        Func<TState, Exception?, string> formatter)
    {
        Console.WriteLine($"Logging for {exception!.Message}");
        Console.WriteLine($"Following data {exception!.Data}");
    }

    public void LogNoArgs()
    {
        Console.WriteLine("I am working!!!");
    }
}

public class CustomLoggerSettings
{
    public string ProviderInfo { get; set; }
}

public class CustomProvider : ILoggerProvider
{
    public CustomLoggerSettings CustomCustomLoggerSettings { get; init; }

    public CustomProvider(IOptions<CustomLoggerSettings> myLoggerInfo)
    {
        CustomCustomLoggerSettings = myLoggerInfo.Value;
    }

    public void Dispose()
    {
        throw new NotImplementedException();
    }

    public ILogger CreateLogger(string categoryName)
    {
        return new CustomLogger();
    }
}