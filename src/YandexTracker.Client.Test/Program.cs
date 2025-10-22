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
            Query = "TIO.tfsId: notEmpty() "
        }, 500, 1).Result;

        foreach (var r in result)
        {
            var transactions = client.GetTransitions(r.Key).Result;

            client.ExecuteTransition(r.Key, transactions[0].Id, new ExecuteTransitionRequest()).Wait();

            _ = client.UpdateIssue(r.Key, new UpdateIssueRequest()
            {
                Deadline = DateTimeOffset.Now,
            }).Result;
        }
    }
}