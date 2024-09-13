using YandexTracker.Client.Api;
using YandexTracker.Client.Models;
using YandexTracker.Client.Test.Configuration;

namespace YandexTracker.Client.Test;

public static class Program
{
    public static void Main(string[] args)
    {
        AppSettings.InitFromFile(args);

        using var client = new YandexTrackerClient(AppSettings.Instance.YandexApi);
        var result = client.GetIssues(new GetIssueRequest()
        {
            Filter = new Filter()
            {
                Status = new Status() { Id = "3" }
            }
        }, 500, 1).Result;

        foreach (var r in result)
        {
            Console.WriteLine(r.Summary);
        }
    }
}