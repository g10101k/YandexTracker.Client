using Microsoft.Extensions.Configuration;


namespace YandexTracker.Client.Test.Configuration;

public class AppSettings
{
    public static AppSettings Instance { get; set; } = new();
    public YandexApiSettings YandexApi { get; set; } = new();
    public static void InitFromFile(string[] args)
    {
        new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddUserSecrets<AppSettings>()
            .AddCommandLine(args)
            .Build()
            .Bind(Instance);
    }
}
